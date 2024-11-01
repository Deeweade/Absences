using Absence.Domain.Dtos.Entities;
using Absence.Domain.Dtos.Queries;
using System.Linq.Expressions;

namespace Absence.Domain.Interfaces.Repositories;

public interface IEmployeesRepository
{
    Task<PositionAndEmployeesDto> GetByPId(string pId);
    Task<PositionAndEmployeesDto> GetByLogin(string login);
    Task<List<PositionAndEmployeesDto>> GetSubordinates(string managerPId);
    Task<List<TResult>> GetByQuery<TResult>(EmployeesQueryDto employeesQueryDto, Expression<Func<PositionAndEmployeesDto, TResult>> select = null);
}