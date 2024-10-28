using Absence.Domain.Dtos.Entities;

namespace Absence.Domain.Interfaces.Repositories;

public interface ISubstitutionsRepository
{
    Task<SubstitutionDto> Get(string employeePId, string deputyPId);
    Task<List<SubstitutionDto>> GetCurrentByDeputyPId(string pId);
    Task<SubstitutionDto> Create(SubstitutionDto dto);
}
