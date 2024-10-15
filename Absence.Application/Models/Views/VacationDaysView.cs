namespace Absence.Application.Models.Views;

public class VacationDaysView : BaseView
{
    public string PId { get; set; }
    public int Year { get; set; }
    public int NorthernDaysCount { get; set; }
    public int RegularDaysCount { get; set; }
    public bool IsYearPlanning { get; set; }
}