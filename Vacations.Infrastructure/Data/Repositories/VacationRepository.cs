using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Dtos.Queries;
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

    public async Task<IEnumerable<VacationDto>> GetByQuery(VacationQueryDto query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var vacations = _vacationsDbContext.Vacations
            .AsNoTracking()
            .ProjectTo<VacationDto>(_mapper.ConfigurationProvider);

        if (query.Years.Count != 0 && !query.Years.Contains(0))
        {
            vacations = vacations.Where(x => query.Years.Contains(x.DateStart.Year));
        }

        if (query.EntityStatuses.Count != 0 && !query.EntityStatuses.Contains(0))
        {
            vacations = vacations.Where(x => query.EntityStatuses.Contains(x.EntityStatusId));
        }

        var result = await vacations.ToListAsync();

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

    public void Update(VacationDto vacationDto)
    {
        ArgumentNullException.ThrowIfNull(vacationDto);

        Vacation vacation;

        if (vacationDto.EntityStatusId == (int)EntityStatuses.CompletedAndApproved)
        {
            vacation = new Vacation
            {
                DateStart = vacationDto.DateStart,
                DateEnd = vacationDto.DateEnd,
                EntityStatusId = (int)EntityStatuses.ActiveDraft
            };
        }
        else 
        {
            vacation = new Vacation
            {
                DateStart = vacationDto.DateStart,
                DateEnd = vacationDto.DateEnd,
            };
        }

        _vacationsDbContext.Vacations.Update(vacation);
    }
}