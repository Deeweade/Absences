namespace Vacations.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IVacationRepository VacationRepository { get; }
    IStatusRepository StatusRepository { get; }

    Task<int> SaveChangesAsync();
}