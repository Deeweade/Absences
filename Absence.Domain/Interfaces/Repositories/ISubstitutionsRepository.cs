using Absence.Domain.Dtos.Entities;

namespace Absence.Domain.Interfaces.Repositories;

public interface ISubstitutionsRepository
{
    Task<SubstitutionDto> Create(SubstitutionDto dto);
    Task<List<SubstitutionDto>> GetByDeputyPId(string pId);
}
