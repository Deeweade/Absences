using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Domain.Models.Entities;
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
    
    public async Task<VacationDto> Create(VacationDto vacationDto)
    {
        ArgumentNullException.ThrowIfNull(vacationDto);

        var vacation = _mapper.Map<Vacation>(vacationDto);

        _vacationsDbContext.Vacations.Add(vacation);
        await _vacationsDbContext.SaveChangesAsync();

        return await GetById(vacation.Id);
    }
}