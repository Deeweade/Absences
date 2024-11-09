namespace Absence.Domain.Models.Entities;

public class NotificationType : BaseEntity
{
    public string Title { get; set; }

    public virtual ICollection<NotificationBody> Bodies { get; set; }
    public virtual ICollection<NotificationTitle> Titles { get; set; }
}