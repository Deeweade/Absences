using AutoMapper;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Interfaces.Repositories;
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

    public async Task<StatusDto> ChangeStatus(StatusDto status)
    {
        
    }
}