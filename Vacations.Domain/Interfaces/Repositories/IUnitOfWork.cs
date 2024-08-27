namespace Vacations.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IVacationRepository VacationRepository { get; }

    Task<int> SaveChangesAsync();
}