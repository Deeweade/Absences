namespace Vacations.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IVacationRepository VacationRepository { get; }
    IPlanningProcessRepository PlanningProcessRepository { get; }

    Task<int> SaveChangesAsync();
}