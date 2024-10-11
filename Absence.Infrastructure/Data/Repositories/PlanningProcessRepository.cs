using Vacations.Domain.Interfaces.Repositories;
using Vacations.Infrastructure.Data.Contexts;
using Vacations.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Vacations.Infrastructure.Data.Repositories;

public class PlanningProcessRepository : IPlanningProcessRepository
{
    private readonly AbsenceDbContext _vacationsDbContext;
    private readonly IMapper _mapper;

    public PlanningProcessRepository(AbsenceDbContext vacationsDbContext, IMapper mapper)
    {
        _vacationsDbContext = vacationsDbContext;
        _mapper = mapper;
    }

    public async Task<PlanningProcessDto> GetActive()
    {
        return await _vacationsDbContext.PlanningProcesses
                .AsNoTracking()
                .ProjectTo<PlanningProcessDto>(_mapper.ConfigurationProvider)
                .Where(x => x.IsActive)
                .FirstOrDefaultAsync();
    }
}