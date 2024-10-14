using Absence.Infrastructure.Data.Repositories;
using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using AutoMapper;

namespace Absence.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AbsenceDbContext _context;
    private IDbContextTransaction _transaction;

    public UnitOfWork(AbsenceDbContext vacationsDbContext, IMapper mapper)
    {
        _context = vacationsDbContext;

        AbsencesRepository = new AbsenceRepository(_context, mapper);
        SubstitutionsRepository = new SubstitutionsRepository(_context, mapper);
        EmployeeStagesRepository = new EmployeeStagesRepository(_context, mapper);
        PlanningProcessRepository = new PlanningProcessRepository(_context, mapper);
    }

    public IPlanningProcessRepository PlanningProcessRepository { get; }
    public IEmployeeStagesRepository EmployeeStagesRepository { get; }
    public ISubstitutionsRepository SubstitutionsRepository { get; }
    public IAbsenceRepository AbsencesRepository { get; }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            await _transaction?.CommitAsync();
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task ExecuteInTransactionAsync(Func<Task> operation)
    {
        await BeginTransactionAsync();

        try
        {
            await operation();
            
            await SaveChangesAsync();
            await CommitAsync();
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}