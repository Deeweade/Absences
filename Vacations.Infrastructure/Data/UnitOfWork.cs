using AutoMapper;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Infrastructure.Data.Contexts;
using Vacations.Infrastructure.Data.Repositories;

namespace Vacations.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly VacationsDbContext _vacationsDbContext;

    public UnitOfWork(VacationsDbContext vacationsDbContext, IMapper mapper)
    {
        _vacationsDbContext = vacationsDbContext;

        VacationRepository = new VacationRepository(_vacationsDbContext, mapper);
        PlanningProcessRepository = new PlanningProcessRepository(_vacationsDbContext, mapper);
    }

    public IVacationRepository VacationRepository { get; }
    public IPlanningProcessRepository PlanningProcessRepository { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _vacationsDbContext.SaveChangesAsync();
    }

}