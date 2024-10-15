namespace Absence.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IPlanningProcessRepository PlanningProcessRepository { get; }
    IEmployeeStagesRepository EmployeeStagesRepository { get; }
    ISubstitutionsRepository SubstitutionsRepository { get; }
    IEmployeesRepository EmployeesRepository { get; }
    IAbsenceRepository AbsencesRepository { get; }

    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task ExecuteInTransactionAsync(Func<Task> operation);
    
    Task<int> SaveChangesAsync();
}