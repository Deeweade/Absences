using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Models.Enums;
using AutoMapper;
using Absence.Application.Models.Actions;
using Absence.Domain.Dtos.Queries;

namespace Absence.Application.Services;

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

        var lastStage = await _unitOfWork.EmployeeStagesRepository.GetLast(pId, year);

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

                await _unitOfWork.EmployeeStagesRepository.Update(lastStage);
            }
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateStagesBulk(UpdateStagesBulkView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var employeesStages = await _unitOfWork.EmployeeStagesRepository.GetLastByQuery(new EmployeeStagesQueryDto
            {
                PIds = view.PIds,
                Year = view.Year
            });

        foreach(var employeeStage in employeesStages)
        {
            if (view.AbsenceStatusId == (int)AbsenceStatuses.Approved)
            {
                employeeStage.StageId = employeeStage.Stage.ProcessId == (int)SystemProcesses.VacationsCorrection ?
                    (int)ProcessStages.CorrectionApproved
                    : (int)ProcessStages.YearPlanningApproved;
            }
            else if (view.AbsenceStatusId == (int)AbsenceStatuses.Rejected)
            {
                employeeStage.StageId = employeeStage.Stage.ProcessId == (int)SystemProcesses.VacationsCorrection ?
                    (int)ProcessStages.Correction
                    : (int)ProcessStages.YearPlanning;
            }
            else
            {
                throw new ArgumentException($"Impossible to set absence status with Id='{view.AbsenceStatusId}'");
            }
        }
        
        await _unitOfWork.EmployeeStagesRepository.UpdateBulk(employeesStages);

        await _unitOfWork.SaveChangesAsync();
    }
}