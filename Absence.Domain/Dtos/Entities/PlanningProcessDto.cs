namespace Absence.Domain.Dtos.Entities;

public class PlanningProcessDto : BaseDto
{
    public string Title { get; set; }
    public int Year { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public bool IsActive { get; set; } 
}