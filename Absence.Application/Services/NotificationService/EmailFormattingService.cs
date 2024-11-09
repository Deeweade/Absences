using Absence.Application.Interfaces.Services.NotificationSender;

namespace Absence.Application.Services.NotificationService;

public class EmailFormattingService : IEmailFormattingService
{
    public string ReplaceParams(string notificationBody, Dictionary<string, string> dict)
    {
        var result = notificationBody;
        
        if (dict != null && dict.Count > 0)
        {
            result = dict.Aggregate(result, (current, item) => current.Replace(item.Key, item.Value));
        }

        return result;
    }
}
