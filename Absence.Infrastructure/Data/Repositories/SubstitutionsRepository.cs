using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Models.Entities;
using Absence.Domain.Dtos.Entities;
using AutoMapper;

namespace Absence.Infrastructure.Data.Repositories;

public class SubstitutionsRepository : ISubstitutionsRepository
{
    private readonly AbsenceDbContext _context;
    private readonly IMapper _mapper;

    public SubstitutionsRepository(AbsenceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SubstitutionDto> Create(SubstitutionDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = _mapper.Map<Substitution>(dto);

        _context.Substitutions.Add(entity);

        await _context.SaveChangesAsync();

        return _mapper.Map<SubstitutionDto>(entity);
    }
}