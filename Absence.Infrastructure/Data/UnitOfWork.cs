using AutoMapper;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Infrastructure.Data.Contexts;
using Vacations.Infrastructure.Data.Repositories;

namespace Vacations.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AbsenceDbContext _vacationsDbContext;

    public UnitOfWork(AbsenceDbContext vacationsDbContext, IMapper mapper)
    {
        _vacationsDbContext = vacationsDbContext;

        AbsencesRepository = new AbsenceRepository(_vacationsDbContext, mapper);
        PlanningProcessRepository = new PlanningProcessRepository(_vacationsDbContext, mapper);
        EmployeeStatusesRepository = new EmployeeStatusesRepository(_vacationsDbContext, mapper);
    }

    public IAbsenceRepository AbsencesRepository { get; }
    public IPlanningProcessRepository PlanningProcessRepository { get; }
    public IEmployeeStatusesRepository EmployeeStatusesRepository { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await _vacationsDbContext.SaveChangesAsync();
    }

}