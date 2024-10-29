namespace Absence.Domain.Models.Entities;

public class NotificationBody : BaseEntity
{
    public string Text { get; set; }
    public int NotificationTypeId { get; set; }
    public int NotificationMethodId { get; set; }

    public virtual NotificationType NotificationType { get; set; }
    public virtual NotificationMethod NotificationMethod { get; set; }
}