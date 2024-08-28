using Vacations.Application.Models.Views;

namespace Vacations.Application.Interfaces.Services;

public interface IStatusService
{
    Task<StatusView> ChangeStatus(StatusView status);
}