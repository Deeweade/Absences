
using Absence.Domain.Dtos.Entities;

namespace Absence.Domain.Interfaces.Repositories;

public interface IWorkPeriodsRepository
{
    Task<List<WorkPeriodDto>> GetAll();
}
