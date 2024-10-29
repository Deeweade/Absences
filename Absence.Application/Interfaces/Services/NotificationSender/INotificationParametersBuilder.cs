using Absence.Application.Services.NotificationService;
using Absence.Domain.Models.Enums;

namespace Absence.Application.Interfaces.Services.NotificationSender;

public interface INotificationParametersBuilder
{
    Task<NotificationParameters> Build(NotificationTypes absencesRequireApproval, string pId);
}