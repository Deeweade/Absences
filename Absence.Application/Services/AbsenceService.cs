using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Actions;
using Absence.Application.Models.Queries;
using Absence.Application.Models.Views;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Models.Enums;
using Absence.Application.Helpers;
using Absence.Domain.Dtos.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

namespace Absence.Application.Services;

public class AbsenceService : IAbsenceService
{
    private readonly IEmployeeStagesService _employeeStagesService;
    private readonly INotificationSenderFacade _sender;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AbsenceService(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeStagesService employeeStagesService, 
        INotificationSenderFacade sender)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _employeeStagesService = employeeStagesService;
        _sender = sender;
    }

    public async Task<List<AbsenceView>> GetByQuery(AbsenceQueryView query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var queryDto = _mapper.Map<AbsenceQueryDto>(query);

        var absences = await _unitOfWork.AbsencesRepository.GetByQuery(queryDto);

        return _mapper.Map<List<AbsenceView>>(absences);
    }

    public async Task<AbsenceView> Create(CreateAbsenceView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var dto = _mapper.Map<AbsenceDto>(view);

        await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            dto = await _unitOfWork.AbsencesRepository.Create(dto);

            //проставляем этап сотруднику
            await _employeeStagesService.CreateOrSetFirstStatus(dto.PId, dto.DateStart.Year);
        });

        return _mapper.Map<AbsenceView>(dto);
    }

    public async Task ChangeStatus(ChangeAbsenceStatusView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var changedAbsence = await _unitOfWork.AbsencesRepository.GetById(view.AbsenceId);

        changedAbsence.AbsenceStatusId = view.NewAbsenceStatusId;

        try
        {
            //меняем статусы сотруднику
            var absences = await _unitOfWork.AbsencesRepository.GetByQuery(new AbsenceQueryDto
            {
                Years = new List<int> { changedAbsence.DateStart.Year },
                PIds = new List<string> { changedAbsence.PId },
                AbsenceStatuses = new List<int> { (int)AbsenceStatuses.ActiveDraft, (int)AbsenceStatuses.Approval, (int)AbsenceStatuses.Approved }
            });

            var currentAbsence = absences.FirstOrDefault(x => x.Id == view.AbsenceId);
            absences.Remove(currentAbsence);

            var updateStagesView = new UpdateStagesBulkView
            {
                PIds = new List<string> { changedAbsence.PId },
                Year = changedAbsence.DateStart.Year,
                AbsenceStatusId = view.NewAbsenceStatusId
            };

            bool allowedUpdateStage = false;

                //если финальный статус и остальные отсутствия согласованы
            if ((view.NewAbsenceStatusId == (int)AbsenceStatuses.Approved
                    && absences.All(x => x.AbsenceStatusId == (int)AbsenceStatuses.Approved)
                    && currentAbsence.AbsenceStatusId == (int)AbsenceStatuses.Approval)
                //или если "На согласовании" и остальные отсутсвия не в черновике 
                || (view.NewAbsenceStatusId == (int)AbsenceStatuses.Approval
                    && absences.All(x => x.AbsenceStatusId != (int)AbsenceStatuses.ActiveDraft))
                //или если "Отклонен"
                || view.NewAbsenceStatusId == (int)AbsenceStatuses.Rejected)
            {
                //разрешаем обновление статуса сотрудника
                allowedUpdateStage = true;
            }
            //иначе не разрешаем

            await _unitOfWork.ExecuteInTransactionAsync(async () => 
            {
                await _unitOfWork.AbsencesRepository.Update(changedAbsence);

                if (allowedUpdateStage)
                    await _employeeStagesService.UpdateBulk(updateStagesView);
            });

            //отправляем уведомление
            switch (view.NewAbsenceStatusId)
            {
                case (int)AbsenceStatuses.Approval:
                    await _sender.Send_AbsencesRequireApproval(changedAbsence.PId);
                    break;
                case (int)AbsenceStatuses.Rejected:
                    await _sender.Send_AbsenceRejected(changedAbsence);
                    break;
                case (int)AbsenceStatuses.Approved:
                    await _sender.Send_AbsenceApproved(changedAbsence);
                    break;
            }
        }
        catch
        {
            throw;
        }
    }

    public async Task ChangeStatusesBulk(UpdateAbsencesBulkView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        try
        {
            //проставляем статусы отсутствиям
            var absences = await _unitOfWork.AbsencesRepository.GetByQuery(new AbsenceQueryDto
            {
                Ids = view.AbsencesIds
            });

            foreach (var absence in absences)
            {
                absence.AbsenceStatusId = view.AbsenceStatusId;
            }

            await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                _unitOfWork.AbsencesRepository.UpdateBulk(absences);

                //проставляем этапы сотрудникам в зависимости от статусов отсутствий и типов процессов
                await _employeeStagesService.UpdateBulk(new UpdateStagesBulkView
                {
                    PIds = absences.Select(x => x.PId).Distinct().ToList(),
                    Year = absences.FirstOrDefault().DateStart.Date.Year,
                    AbsenceStatusId = view.AbsenceStatusId
                });
            });

            var pIds = absences.Select(x => x.PId).Distinct().ToList();

            foreach (var pId in pIds)
            {
                switch (view.AbsenceStatusId)
                {
                    case (int)AbsenceStatuses.Approval:
                        await _sender.Send_AbsencesRequireApproval(pId);
                        break;
                    case (int)AbsenceStatuses.Rejected:
                        await _sender.Send_AllAbsencesRejected(pId);
                        break;
                    case (int)AbsenceStatuses.Approved:
                        await _sender.Send_AllAbsencesApproved(pId);
                        break;
                }
            }
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<AbsenceView>> Reschedule(RescheduleAbsenceView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var cancelledAbsence = await _unitOfWork.AbsencesRepository.GetById(view.CancelledAbsenceId);

        cancelledAbsence.AbsenceStatusId = (int)AbsenceStatuses.Cancelled;

        var newAbsences = _mapper.Map<List<AbsenceDto>>(view.NewAbsences);

        foreach (var absence in newAbsences)
        {
            absence.ParentAbsenceId = cancelledAbsence.Id;
        }

        var absences = new List<AbsenceDto>();

        await _unitOfWork.ExecuteInTransactionAsync(async () => 
        {
            await _unitOfWork.AbsencesRepository.Update(cancelledAbsence);

            absences = await _unitOfWork.AbsencesRepository.CreateBulk(newAbsences);

            await _employeeStagesService.SetFirstStatus(cancelledAbsence.PId, cancelledAbsence.DateStart.Date.Year);
        });

        return _mapper.Map<List<AbsenceView>>(absences);
    }
    
    public async Task<AbsenceView> Update(UpdateAbsenceView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var dto = _mapper.Map<AbsenceDto>(view);

        await _unitOfWork.ExecuteInTransactionAsync(async () =>
        {
            var absence = await _unitOfWork.AbsencesRepository.GetById(dto.Id);

            absence.DateStart = dto.DateStart;
            absence.DateEnd = dto.DateEnd;
            absence.AbsenceStatusId = (int)AbsenceStatuses.ActiveDraft;
            
            dto = await _unitOfWork.AbsencesRepository.Update(absence);

            //проставляем этап сотруднику
            await _employeeStagesService.CreateOrSetFirstStatus(absence.PId, absence.DateStart.Date.Year);
        });

        return _mapper.Map<AbsenceView>(dto);
    }

    public async Task Delete(int id)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(id, 1);

        var absence = await _unitOfWork.AbsencesRepository.GetById(id);

        if (absence.AbsenceStatusId != (int)AbsenceStatuses.ActiveDraft)
            ExceptionHelper.ThrowContextualException<InvalidOperationException>(ExceptionalEvents.RemovingNotDraftAbsence);

        await _unitOfWork.AbsencesRepository.Delete(id);
        await _unitOfWork.SaveChangesAsync();
    }
}