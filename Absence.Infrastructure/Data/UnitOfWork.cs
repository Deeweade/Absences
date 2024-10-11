using Vacations.Infrastructure.Data.Repositories;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using AutoMapper;

namespace Vacations.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AbsenceDbContext _context;

    public UnitOfWork(AbsenceDbContext vacationsDbContext, IMapper mapper)
    {
        _context = vacationsDbContext;

        AbsencesRepository = new AbsenceRepository(_context, mapper);
        PlanningProcessRepository = new PlanningProcessRepository(_context, mapper);
        EmployeeStagesRepository = new EmployeeStagesRepository(_context, mapper);
    }

    public IPlanningProcessRepository PlanningProcessRepository { get; }
    public IEmployeeStagesRepository EmployeeStagesRepository { get; }
    public IAbsenceRepository AbsencesRepository { get; }

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return _context.Database.BeginTransactionAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

}