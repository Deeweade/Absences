namespace Vacations.Domain.Models.Entities;

public class Status : BaseEntity
{
    public int EmployeeTabNumber { get; set; }
    public int Year { get; set; }
    public bool IsActive { get; set; }
 
    // Status -> PlanningStatus
    public int PlanningStatusId { get; set; }
    public virtual PlanningStatus PlanningStatus { get; set; }

    // Status -> Comment
    public virtual ICollection<Comment> Comments { get; set; }
}