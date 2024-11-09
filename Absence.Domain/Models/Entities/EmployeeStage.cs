namespace Absence.Domain.Models.Entities;

public class EmployeeStage : BaseEntity
{
    public string PId { get; set; }
 
    // Status -> PlanningStatus
    public int StageId { get; set; }
    public virtual ProcessStage Stage { get; set; }

    // Status -> Comment
    public virtual ICollection<Comment> Comments { get; set; }
}