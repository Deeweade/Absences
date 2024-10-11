namespace Absence.Domain.Models.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; }
    public string PId { get; set; }
    
    // Comment -> Status
    public int StageId { get; set; }
    public virtual EmployeeStage Stage { get; set; }
}