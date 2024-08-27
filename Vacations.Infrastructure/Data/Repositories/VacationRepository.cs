using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Domain.Models.Entities;
using Vacations.Domain.Models.Filters;
using Vacations.Infrastructure.Data.Contexts;

namespace Vacations.Infrastructure.Data.Repositories;

public class VacationRepository(VacationsDbContext vacationsDbContext, IMapper mapper) : IVacationRepository
{
    private readonly VacationsDbContext _vacationDbContext = vacationsDbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<VacationDto> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        return await _vacationDbContext.Vacations
                .AsNoTracking()
                .ProjectTo<VacationDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<VacationDto>> GetByFilter(VacationFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        var query = _vacationDbContext.Vacations
            .AsNoTracking();

        if (filter.Years.Any() && !filter.Years.Contains(0))
        {
            query = query.Where(x => filter.Years.Contains(x.DateStart.Year));
        }

        if (filter.EntityStatuses.Any() && !filter.EntityStatuses.Contains(0))
        {
            query = query.Where(x => filter.EntityStatuses.Contains(x.EntityStatusId));
        }

        var result = await query.ToListAsync();

        return _mapper.Map<IEnumerable<VacationDto>>(result);
    } 
    
    public async Task<VacationDto> Create(VacationDto vacationDto)
    {
        ArgumentNullException.ThrowIfNull(vacationDto);

        var vacation = new Vacation
        {
            EmployeeTabNumber = vacationDto.EmployeeTabNumber,
            VacationTypeId = vacationDto.VacationTypeId,
            DateStart = vacationDto.DateStart,
            DateEnd = vacationDto.DateEnd,
            EntityStatusId = vacationDto.EntityStatusId,
            ParentVacationId = vacationDto.ParentVacationId
        };

        _vacationDbContext.Vacations.Add(vacation);
        await _vacationDbContext.SaveChangesAsync();

        return await GetById(vacation.Id);
    }
}