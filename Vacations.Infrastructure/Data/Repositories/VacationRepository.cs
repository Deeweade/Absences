using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Dtos.Filters;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Domain.Models.Entities;
using Vacations.Domain.Models.Enums;
using Vacations.Infrastructure.Data.Contexts;

namespace Vacations.Infrastructure.Data.Repositories;

public class VacationRepository : IVacationRepository
{
    private readonly VacationsDbContext _vacationsDbContext;
    private readonly IMapper _mapper;

    public VacationRepository(VacationsDbContext vacationsDbContext, IMapper mapper)
    {
        _vacationsDbContext = vacationsDbContext;
        _mapper = mapper;
    }

    public async Task<VacationDto> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        return await _vacationsDbContext.Vacations
                .AsNoTracking()
                .ProjectTo<VacationDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<VacationDto>> GetByFilter(VacationFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        var query = _vacationsDbContext.Vacations
            .AsNoTracking()
            .ProjectTo<VacationDto>(_mapper.ConfigurationProvider);

        if (filter.Years.Count != 0 && !filter.Years.Contains(0))
        {
            query = query.Where(x => filter.Years.Contains(x.DateStart.Year));
        }

        if (filter.EntityStatuses.Count != 0 && !filter.EntityStatuses.Contains(0))
        {
            query = query.Where(x => filter.EntityStatuses.Contains(x.EntityStatusId));
        }

        var result = await query.ToListAsync();

        return result;
    } 
    
    public async Task<VacationDto> Create(VacationDto vacationDto)
    {
        ArgumentNullException.ThrowIfNull(vacationDto);

        vacationDto.EntityStatusId = (int)EntityStatuses.ActiveDraft;

        var vacation = _mapper.Map<Vacation>(vacationDto);

        _vacationsDbContext.Vacations.Add(vacation);
        await _vacationsDbContext.SaveChangesAsync();

        return await GetById(vacation.Id);
    }
}