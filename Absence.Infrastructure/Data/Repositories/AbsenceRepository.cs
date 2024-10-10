using Vacations.Domain.Interfaces.Repositories;
using Vacations.Infrastructure.Data.Contexts;
using Vacations.Domain.Models.Entities;
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

        if (query.PIds.Count != 0 && !query.PIds.Contains(0))
        {
            vacations = vacations.Where(x => query.PIds.Contains(x.PId));
        }

        var result = await vacations.ToListAsync();

        return result;
    } 
    
    public async Task<AbsenceDto> Create(AbsenceDto vacationDto)
    {
        ArgumentNullException.ThrowIfNull(vacationDto);

        vacationDto.AbsenceStatusId = (int)EntityStatuses.ActiveDraft;

        var vacation = _mapper.Map<Absence>(vacationDto);

        _context.Absences.Add(vacation);
        await _context.SaveChangesAsync();

        return await GetById(vacation.Id);
    }

    public AbsenceDto Update(AbsenceDto vacationDto)
    {
        ArgumentNullException.ThrowIfNull(vacationDto);

        var vacation = _mapper.Map<Absence>(vacationDto);

        vacation.EntityStatusId = (int)EntityStatuses.ActiveDraft;

        var newVacation = _context.Absences.Update(vacation);

        return _mapper.Map<AbsenceDto>(newVacation);
    }
}