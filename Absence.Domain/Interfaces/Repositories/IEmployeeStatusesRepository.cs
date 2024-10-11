using Vacations.Domain.Dtos.Entities;

namespace Vacations.Domain.Interfaces.Repositories;

public interface IEmployeeStagesRepository
{
    Task<EmployeeStageDto> GetById(int id);
    Task<EmployeeStageDto> GetLastStage(string employeeTabNumber, int year);
    Task<EmployeeStageDto> Create(EmployeeStageDto status);
    void DeactivateStatus(EmployeeStageDto status);
    EmployeeStageDto Update(EmployeeStageDto status);
    EmployeeStageDto CloseStatus(EmployeeStageDto status);
}