namespace Absence.Domain.Models.Entities;

public class NotificationMethod : BaseEntity
{
    public string Title { get; set; }

    public virtual ICollection<NotificationBody> Bodies { get; set; }
}