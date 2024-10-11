using Vacations.Domain.Interfaces.Repositories;
using Vacations.Infrastructure.Data.Contexts;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Dtos.Queries;
using Vacations.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Vacations.Infrastructure.Data.Repositories;

public class AbsenceRepository : IAbsenceRepository
{
    private readonly AbsenceDbContext _context;
    private readonly IMapper _mapper;

    public AbsenceRepository(AbsenceDbContext vacationsDbContext, IMapper mapper)
    {
        _context = vacationsDbContext;
        _mapper = mapper;
    }

    public async Task<AbsenceDto> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        return await _context.Absences
                .AsNoTracking()
                .ProjectTo<AbsenceDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<AbsenceDto>> GetByQuery(AbsenceQueryDto query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var vacations = _context.Absences
            .AsNoTracking()
            .ProjectTo<AbsenceDto>(_mapper.ConfigurationProvider);

        if (query.Years.Count != 0 && !query.Years.Contains(0))
        {
            vacations = vacations.Where(x => query.Years.Contains(x.DateStart.Year));
        }

        if (query.EntityStatuses.Count != 0 && !query.EntityStatuses.Contains(0))
        {
            vacations = vacations.Where(x => query.EntityStatuses.Contains(x.AbsenceStatusId));
        }

        if (query.PIds.Count != 0)
        {
            vacations = vacations.Where(x => query.PIds.Contains(x.PId));
        }

        var result = await vacations.ToListAsync();

        return result;
    } 
    
    public async Task<AbsenceDto> Create(AbsenceDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        dto.AbsenceStatusId = (int)EntityStatuses.ActiveDraft;

        var absence = _mapper.Map<Absence.Domain.Models.Entities.Absence>(dto);

        _context.Absences.Add(absence);
        await _context.SaveChangesAsync();

        return await GetById(absence.Id);
    }

    public AbsenceDto Update(AbsenceDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var absence = _mapper.Map<Absence.Domain.Models.Entities.Absence>(dto);

        absence.AbsenceStatusId = (int)EntityStatuses.ActiveDraft;

        var newVacation = _context.Absences.Update(absence);

        return _mapper.Map<AbsenceDto>(newVacation);
    }
}