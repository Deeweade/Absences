namespace Vacations.Domain.Models.Entities;

public class EmployeeStatus : BaseEntity
{
    public int PId { get; set; }
    public int Year { get; set; }
 
    // Status -> PlanningStatus
    public int StatusId { get; set; }
    public virtual Status Status { get; set; }

    // Status -> Comment
    public virtual ICollection<Comment> Comments { get; set; }
}