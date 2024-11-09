namespace Absence.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    INotificationSettingsRepository NotificationSettingsRepository { get; }
    INotificationTitlesRepository NotificationTitlesRepository { get; }
    INotificationBodiesRepository NotificationBodiesRepository { get; }
    IPlanningProcessRepository PlanningProcessRepository { get; }
    IEmployeeStagesRepository EmployeeStagesRepository { get; }
    ISubstitutionsRepository SubstitutionsRepository { get; }
    IVacationDaysRepository VacationDaysRepository { get; }
    IWorkPeriodsRepository WorkPeriodsRepository { get; }
    IEmployeesRepository EmployeesRepository { get; }
    IAbsenceRepository AbsencesRepository { get; }

    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task ExecuteInTransactionAsync(Func<Task> operation);
    
    Task<int> SaveChangesAsync();
}