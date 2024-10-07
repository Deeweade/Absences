namespace Vacations.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IAbsenceRepository AbsencesRepository { get; }
    IPlanningProcessRepository PlanningProcessRepository { get; }
    IEmployeeStatusesRepository EmployeeStatusesRepository { get; }

    Task<int> SaveChangesAsync();
}