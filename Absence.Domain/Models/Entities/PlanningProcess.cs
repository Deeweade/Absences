namespace Absence.Domain.Models.Entities;

public class PlanningProcess : BaseEntity
{
    public string Title { get; set; }
    public int Year { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public bool IsActive { get; set; } 
}