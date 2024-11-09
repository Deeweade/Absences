using Absence.Application.Services.NotificationService.Parameters;
using Absence.Application.Services.NotificationService;

namespace Absence.Application.Interfaces.Services.NotificationSender;

public interface INotificationParametersBuilder
{
    Task<NotificationParameters> Build(BuilderOptions options);
}