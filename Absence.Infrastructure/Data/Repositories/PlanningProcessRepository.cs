using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Absence.Infrastructure.Data.Repositories;

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