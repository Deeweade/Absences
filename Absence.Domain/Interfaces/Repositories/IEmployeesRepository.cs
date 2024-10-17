using Absence.Domain.Dtos.Entities;
using System;

namespace Absence.Domain.Interfaces.Repositories;

public interface IEmployeesRepository
{
    Task<PositionAndEmployeesDto> GetByPId(string pId);
    Task<PositionAndEmployeesDto> GetByLogin(string login);
}