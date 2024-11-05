using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Models.Enums;
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

    public async Task<int> GetHolidaysNumberInPeriods(List<AbsenceDto> absences)
    {
        ArgumentNullException.ThrowIfNull(absences);

        var holidaysNumber = 0;

        foreach (var absence in absences)
        {
            var daysNumber = await _context.WorkPeriods
                .AsNoTracking()
                .Where(x => x.WorkdayTypeId == (int)WorkdayTypes.Holiday
                    && absence.DateStart <= x.Date
                    && absence.DateEnd >= x.Date)
                .CountAsync();
            
            holidaysNumber += daysNumber;
        }

        return holidaysNumber;
    }
}