namespace Vacations.Application.Models.Views;

public class VacationDaysView : BaseView
{
    public int PId { get; set; }
    public int NorthernDaysCount { get; set; }
    public int RegularDaysCount { get; set; }
    public bool IsYearPlanning { get; set; }
}