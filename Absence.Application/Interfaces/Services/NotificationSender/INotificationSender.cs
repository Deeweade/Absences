using Absence.Application.Services.NotificationService;

namespace Absence.Application.Interfaces.Services.NotificationSender;

public interface INotificationSender
{
    Task Send(NotificationParameters parameters);
}