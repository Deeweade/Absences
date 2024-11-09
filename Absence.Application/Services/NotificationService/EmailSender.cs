using Absence.Application.Interfaces.Services.NotificationSender;
using System.Net.Mail;

namespace Absence.Application.Services.NotificationService;

public class EmailSender : INotificationSender
{
    public async Task Send(NotificationParameters parameters)
    {
        if (string.IsNullOrEmpty(parameters.To))
        {
            parameters.To = parameters.DefaultEmail;
        }

        var mailMessage = new MailMessage
        {
            From = new MailAddress(parameters.From, parameters.DisplayedName),
            Sender = new MailAddress(parameters.From),
            IsBodyHtml = true,
            Subject = parameters.Title,
            Body = parameters.Body
        };

        if (parameters.IsOverride)
        {
            parameters.To = parameters.DefaultEmail;

            if (!parameters.To.Equals(parameters.DefaultEmail)) mailMessage.CC.Add(parameters.DefaultEmail);
        }

        mailMessage.To.Add(parameters.To);

        if (parameters.CC != null)
        {
            foreach (var cc in parameters.CC)
            {
                if (!string.IsNullOrWhiteSpace(cc)) mailMessage.CC.Add(cc);
            }
        }

        if (parameters.Attachments != null && parameters.Attachments.Count > 0)
        {
            mailMessage.Headers["Content-type"] = "multipart/related";

            foreach (var attachment in parameters.Attachments)
            {
                mailMessage.Attachments.Add(attachment);
            }
        }

        var smtpClient = new SmtpClient(parameters.MailServerAddress)
        {
            DeliveryMethod = SmtpDeliveryMethod.Network
        };

        try
        {
            await smtpClient.SendMailAsync(mailMessage);
        }
        catch
        {
            throw;
        }
    }
}