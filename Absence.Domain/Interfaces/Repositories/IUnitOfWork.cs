using Microsoft.EntityFrameworkCore.Storage;

namespace Absence.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IPlanningProcessRepository PlanningProcessRepository { get; }
    IEmployeeStagesRepository EmployeeStagesRepository { get; }
    IAbsenceRepository AbsencesRepository { get; }

    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync();
}