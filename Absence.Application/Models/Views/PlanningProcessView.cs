namespace Absence.Application.Models.Views;

public class PlanningProcessView : BaseView
{
    public string Title { get; set; }
    public int Year { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public bool IsActive { get; set; } 
}