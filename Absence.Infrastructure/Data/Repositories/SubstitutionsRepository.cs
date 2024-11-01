using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Models.Entities;
using Absence.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
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

    public async Task<SubstitutionDto> GetById(int substitutionId)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(substitutionId, 0);

        return await _context.Substitutions
            .AsNoTracking()
            .ProjectTo<SubstitutionDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == substitutionId);
    }
    
    public async Task<SubstitutionDto> Get(string employeePId, string deputyPId)
    {
        ArgumentNullException.ThrowIfNull(employeePId);
        ArgumentNullException.ThrowIfNull(deputyPId);

        return await _context.Substitutions
            .AsNoTracking()
            .ProjectTo<SubstitutionDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.EmployeePId.Equals(employeePId)
                && x.DeputyPId.Equals(deputyPId));
    }

    public async Task<List<SubstitutionDto>> GetCurrentByDeputyPId(string deputyPId)
    {
        ArgumentNullException.ThrowIfNull(deputyPId);

        return await _context.Substitutions
            .AsNoTracking()
            .ProjectTo<SubstitutionDto>(_mapper.ConfigurationProvider)
            .Where(x => x.DeputyPId.Equals(deputyPId)
                && x.DateStart <= DateTime.Now
                && x.DateEnd >= DateTime.Now)
            .ToListAsync();
    }

    public async Task<List<SubstitutionDto>> GetCurrentByEmployeeId(string employeeId)
    {
        ArgumentNullException.ThrowIfNull(employeeId);

        return await _context.Substitutions
            .AsNoTracking()
            .ProjectTo<SubstitutionDto>(_mapper.ConfigurationProvider)
            .Where(x => x.EmployeePId.Equals(employeeId)
                && x.DateStart <= DateTime.Now
                && x.DateEnd >= DateTime.Now)
            .ToListAsync();
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