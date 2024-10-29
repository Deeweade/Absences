using System.Net.Mail;

namespace Absence.Application.Services.NotificationService;

public class NotificationParameters
{
    public string From { get; }
    public string To { get; set; }
    public bool IsOverride { get; }
    public string Body { get; set; }
    public string Title { get; set; }
    public string DefaultEmail { get; }
    public string DisplayedName { get; }
    public List<string> CC { get; set; }
    public string MailServerAddress { get; }
    public List<Attachment> Attachments { get; set; }
}