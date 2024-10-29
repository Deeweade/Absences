using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Absence.Infrastructure.Data.Repositories;

public class WorkPeriodsRepository : IWorkPeriodsRepository
{
    private readonly AbsenceDbContext _context;
    private readonly IMapper _mapper;

    public WorkPeriodsRepository(AbsenceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WorkPeriodDto>> GetAll()
    {
        return await _context.WorkPeriods
            .AsNoTracking()
            .ProjectTo<WorkPeriodDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}