namespace Absence.Domain.Models.Entities;

public class NotificationTitle : BaseEntity
{
    public string Text { get; set; }
    public int NotificationTypeId { get; set; }

    public virtual NotificationType NotificationType { get; set; }
}