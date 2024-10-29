
namespace Absence.Domain.Interfaces.Repositories;

public interface INotificationTitlesRepository
{
    Task<string> GetByTypeId(int notificationType);
}