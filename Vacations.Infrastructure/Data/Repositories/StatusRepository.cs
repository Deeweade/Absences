using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Domain.Models.Entities;
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

    public async Task<StatusDto> GetActiveById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        return await _vacationsDbContext.Statuses
                .AsNoTracking()
                .ProjectTo<StatusDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
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

    public async Task DeactivateStatus(StatusDto status)
    {
        status.IsActive = false;

        var entity = await _vacationsDbContext.Statuses
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == status.Id);

        _vacationsDbContext.Statuses.Update(entity);
    }
}