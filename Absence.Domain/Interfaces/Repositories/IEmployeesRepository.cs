using Absence.Domain.Dtos.Entities;

namespace Absence.Domain.Interfaces.Repositories;

public interface IEmployeesRepository
{
    Task<PositionAndEmployeesDto> GetByPId(string pId);
    Task<PositionAndEmployeesDto> GetByLogin(string login);
    Task<List<PositionAndEmployeesDto>> GetSubordinates(string managerPId);
}