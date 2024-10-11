using Vacations.Application.Interfaces.Services;
using Vacations.Domain.Interfaces.Repositories;
using Absence.Application.Interfaces.Services;
using Vacations.Application.Models.Views;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Models.Enums;
using Absence.Domain.Models.Enums;
using AutoMapper;

namespace Vacations.Application.Services;

public class EmployeeStagesService : IEmployeeStagesService
{
    private readonly INotificationSenderFacade _sender;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeStagesService(IUnitOfWork unitOfWork, IMapper mapper, 
        INotificationSenderFacade sender)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _sender = sender;
    }

    public async Task CreateOrSetFirstStatus(string pId, int year)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(pId);
        ArgumentOutOfRangeException.ThrowIfLessThan(year, 2024);

        var lastStage = await _unitOfWork.EmployeeStagesRepository.GetLastStage(pId, year);

        //если нет этапа на год отпуска, создаем первый этап годового планирования
        if (lastStage is null)
        {
            var stage = new EmployeeStageDto
            {
                PId = pId,
                StageId = (int)ProcessStages.YearPlanning
            };

            await _unitOfWork.EmployeeStagesRepository.Create(stage);
        }
        //если есть
        else
        {
            //если процесс планирования и статус "Согласовано", создаем первый этап корректировки
            if (lastStage.Stage.ProcessId == (int)SystemProcesses.VacationsYearPlanning
                && lastStage.StageId == (int)ProcessStages.YearPlanningApproved)
            {
                var stage = new EmployeeStageDto
                {
                    PId = pId,
                    StageId = (int)ProcessStages.Correction
                };

                await _unitOfWork.EmployeeStagesRepository.Create(stage);
            }
            //если этап на любом процессе не "Черновик", переводим на черновик
            else if (lastStage.StageId != (int)ProcessStages.YearPlanning
                && lastStage.StageId != (int)ProcessStages.Correction)
            {
                if (lastStage.Stage.ProcessId == (int)SystemProcesses.VacationsYearPlanning)
                {
                    lastStage.StageId = (int)ProcessStages.YearPlanning;
                }
                else if (lastStage.Stage.ProcessId == (int)SystemProcesses.VacationsCorrection)
                {
                    lastStage.StageId = (int)ProcessStages.Correction;
                }

                _unitOfWork.EmployeeStagesRepository.Update(lastStage);
            }
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<EmployeeStatusView> ChangeStatus(EmployeeStatusView status)
    {
        ArgumentNullException.ThrowIfNull(status);

        var statusDto = _mapper.Map<EmployeeStageDto>(status);

        var currentStage = await _unitOfWork.EmployeeStagesRepository.GetById(status.Id);

        if (!currentStage.PId.Equals(status.PId) && currentStage.Stage.Year != status.Year)
        {
            throw new InvalidOperationException();
        }   
            
        _unitOfWork.EmployeeStagesRepository.DeactivateStatus(currentStage);
        await _unitOfWork.SaveChangesAsync();

        var changedStatus = await _unitOfWork.EmployeeStagesRepository.Create(statusDto);
    
        return _mapper.Map<EmployeeStatusView>(changedStatus);
    }
}