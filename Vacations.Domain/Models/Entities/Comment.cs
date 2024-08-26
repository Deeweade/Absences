namespace Vacations.Domain.Models.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; }
    public int EmployeeTabNumber { get; set; }
    
    // Comment -> Status
    public int StatusId { get; set; }
    public virtual Status Status { get; set; }
}