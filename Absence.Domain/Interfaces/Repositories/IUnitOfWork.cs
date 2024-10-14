using Microsoft.EntityFrameworkCore.Storage;

namespace Absence.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IPlanningProcessRepository PlanningProcessRepository { get; }
    IEmployeeStagesRepository EmployeeStagesRepository { get; }
    IAbsenceRepository AbsencesRepository { get; }

    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task ExecuteInTransactionAsync(Func<Task> operation);
    
    Task<int> SaveChangesAsync();
}