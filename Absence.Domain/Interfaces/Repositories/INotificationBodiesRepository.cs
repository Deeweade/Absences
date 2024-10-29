
namespace Absence.Domain.Interfaces.Repositories;

public interface INotificationBodiesRepository
{
    Task<string> GetByTypeId(int notificationType);
}