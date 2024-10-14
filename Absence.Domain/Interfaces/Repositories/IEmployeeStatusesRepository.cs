using Absence.Domain.Dtos.Entities;
using Absence.Domain.Dtos.Queries;

namespace Absence.Domain.Interfaces.Repositories;

public interface IEmployeeStagesRepository
{
    Task<EmployeeStageDto> GetById(int id);
    Task<EmployeeStageDto> GetLast(string employeeTabNumber, int year);
    Task<List<EmployeeStageDto>> GetLastByQuery(EmployeeStagesQueryDto employeeStagesQueryDto);
    Task<EmployeeStageDto> Create(EmployeeStageDto status);
    Task<EmployeeStageDto> Update(EmployeeStageDto status);
    Task UpdateBulk(List<EmployeeStageDto> employeesStages);
}