using Vacations.Domain.Interfaces.Repositories;
using Vacations.Infrastructure.Data.Contexts;
using Vacations.Domain.Models.Entities;
using Vacations.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Vacations.Infrastructure.Data.Repositories;

public class EmployeeStatusesRepository : IEmployeeStatusesRepository
{
    private readonly AbsenceDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeStatusesRepository(AbsenceDbContext vacationsDbContext, IMapper mapper)
    {
        _context = vacationsDbContext;
        _mapper = mapper;
    }

    public async Task<EmployeeStatusDto> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        return await _context.EmployeeStatuses
            .AsNoTracking()
            .ProjectTo<EmployeeStatusDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<EmployeeStatusDto> GetLastStatus(int pId)
    {
        return await _context.EmployeeStatuses
            .AsNoTracking()
            .ProjectTo<EmployeeStatusDto>(_mapper.ConfigurationProvider)
            .Where(x => x.PId == pId)
            .LastOrDefaultAsync();
    }

    public async Task<EmployeeStatusDto> Create(EmployeeStatusDto status)
    {
        ArgumentNullException.ThrowIfNull(status);

        var newStatus = _mapper.Map<EmployeeStatus>(status);

        _context.EmployeeStatuses.Add(newStatus);
        await _context.SaveChangesAsync();

        return await GetById(newStatus.Id);
    }

    public void DeactivateStatus(EmployeeStatusDto status)
    {
        var newStatus = _mapper.Map<EmployeeStatus>(status);

        _context.EmployeeStatuses.Update(newStatus);
    }

    public EmployeeStatusDto Update(EmployeeStatusDto status)
    {
        var entity = _mapper.Map<EmployeeStatus>(status);

        var newStatus = _context.EmployeeStatuses.Update(entity);

        return _mapper.Map<EmployeeStatusDto>(newStatus);
    }

    public EmployeeStatusDto CloseStatus(EmployeeStatusDto status)
    {
        var newStatus = Update(status);

        return newStatus;
    }
}