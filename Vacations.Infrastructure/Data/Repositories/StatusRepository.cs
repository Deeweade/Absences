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

public class StatusRepository : IStatusRepository
{
    private readonly VacationsDbContext _vacationsDbContext;
    private readonly IMapper _mapper;

    public StatusRepository(VacationsDbContext vacationsDbContext, IMapper mapper)
    {
        _vacationsDbContext = vacationsDbContext;
        _mapper = mapper;
    }

    public async Task<StatusDto> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        return await _vacationsDbContext.Statuses
                .AsNoTracking()
                .ProjectTo<StatusDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<StatusDto> GetLastStatus(int employeeTabNumber)
    {
        return await _vacationsDbContext.Statuses
                .AsNoTracking()
                .ProjectTo<StatusDto>(_mapper.ConfigurationProvider)
                .Where(x => x.EmployeeTabNumber == employeeTabNumber)
                .LastOrDefaultAsync();
    }

    public async Task<StatusDto> Create(StatusDto status)
    {
        ArgumentNullException.ThrowIfNull(status);

        var newStatus = _mapper.Map<Status>(status);

        newStatus.IsActive = true;

        _vacationsDbContext.Statuses.Add(newStatus);
        await _vacationsDbContext.SaveChangesAsync();

        return await GetById(newStatus.Id);
    }

    public void DeactivateStatus(StatusDto status)
    {
        status.IsActive = false;

        var newStatus = _mapper.Map<Status>(status);

        _vacationsDbContext.Statuses.Update(newStatus);
    }

    public void Update(StatusDto status)
    {
        var entity = _mapper.Map<Status>(status);

        _vacationsDbContext.Statuses.Update(entity);
    }
}