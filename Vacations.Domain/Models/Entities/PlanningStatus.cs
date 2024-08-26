namespace Vacations.Domain.Models.Entities;

public class PlanningStatus : BaseEntity
{
    public string Title { get; set; }

    public virtual ICollection<Status> Statuses { get; set; }
}