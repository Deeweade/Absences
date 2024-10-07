namespace Vacations.Domain.Models.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; }
    public int PId { get; set; }
    
    // Comment -> Status
    public int StatusId { get; set; }
    public virtual EmployeeStatus Status { get; set; }
}