using System.Net.Mail;

namespace Absence.Application.Services.NotificationService;

public class NotificationParameters
{
    public string To { get; set; }
    public string From { get; set; }
    public string Body { get; set; }
    public string Title { get; set; }
    public bool IsOverride { get; set; }
    public List<string> CC { get; set; }
    public string DefaultEmail { get; set; }
    public string DisplayedName { get; set; }
    public string MailServerAddress { get; set;}
    public List<Attachment> Attachments { get; set; }
}