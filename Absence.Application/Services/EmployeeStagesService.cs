using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Actions;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Models.Enums;
using Absence.Domain.Dtos.Queries;
using Absence.Application.Helpers;

namespace Absence.Application.Services;

public class EmployeeStagesService : IEmployeeStagesService
{
    private readonly INotificationSenderFacade _sender;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeStagesService(IUnitOfWork unitOfWork, INotificationSenderFacade sender)
    {
        _unitOfWork = unitOfWork;
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
            await SetFirstStatus(pId, year);
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task SetFirstStatus(string pId, int year)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(pId);
        ArgumentOutOfRangeException.ThrowIfLessThan(year, 2024);

        var lastStage = await _unitOfWork.EmployeeStagesRepository.GetLast(pId, year);

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

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateBulk(UpdateStagesBulkView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var employeesStages = await _unitOfWork.EmployeeStagesRepository.GetLastByQuery(new EmployeeStagesQueryDto
            {
                PIds = view.PIds.Distinct().ToList(),
                Year = view.Year
            });

        employeesStages = employeesStages.GroupBy(x => x.PId)
            .ToDictionary(x => x.Key, x => x.OrderBy(stage => stage.Id).LastOrDefault())
            .Select(x => x.Value)
            .ToList();

        foreach(var employeeStage in employeesStages)
        {
            if (view.AbsenceStatusId == (int)AbsenceStatuses.Approval)
            {
                employeeStage.StageId = employeeStage.Stage.ProcessId == (int)SystemProcesses.VacationsCorrection ?
                    (int)ProcessStages.CorrectionApproval
                    : (int)ProcessStages.YearPlanningApproval;

                await _sender.Send_AbsencesRequireApproval(employeeStage.PId);
            }
            else if (view.AbsenceStatusId == (int)AbsenceStatuses.Approved)
            {
                employeeStage.StageId = employeeStage.Stage.ProcessId == (int)SystemProcesses.VacationsCorrection ?
                    (int)ProcessStages.CorrectionApproved
                    : (int)ProcessStages.YearPlanningApproved;

                await _sender.Send_AllAbsencesApproved(employeeStage.PId);
            }
            else if (view.AbsenceStatusId == (int)AbsenceStatuses.Rejected)
            {
                employeeStage.StageId = employeeStage.Stage.ProcessId == (int)SystemProcesses.VacationsCorrection ?
                    (int)ProcessStages.Correction
                    : (int)ProcessStages.YearPlanning;

                await _sender.Send_AllAbsencesRejected(employeeStage.PId);
            }
            else
            {
                throw new ArgumentException($"Impossible to set absence status with Id = {view.AbsenceStatusId}");
            }
        }
        
        await _unitOfWork.EmployeeStagesRepository.UpdateBulk(employeesStages);

        await _unitOfWork.SaveChangesAsync();
    }
}