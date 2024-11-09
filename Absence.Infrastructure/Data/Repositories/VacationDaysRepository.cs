using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Absence.Infrastructure.Data.Repositories;

public class VacationDaysRepository : IVacationDaysRepository
{
    private readonly AbsenceDbContext _context;
    private readonly IMapper _mapper;

    public VacationDaysRepository(AbsenceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<VacationDaysDto>> GetAll(string pId, int year, bool isYearPlanning)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(pId);

        return await _context.VacationDays
            .AsNoTracking()
            .ProjectTo<VacationDaysDto>(_mapper.ConfigurationProvider)
            .Where(x => x.PId.Equals(pId)
                && x.Year == year
                && x.IsYearPlanning == isYearPlanning)
            .ToListAsync();
    }
}