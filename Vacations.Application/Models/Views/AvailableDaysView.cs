namespace Vacations.Application.Models.Views;

public class AvailableDaysView : BaseEntityView
{
    public int EmployeeTabNumber { get; set; }
    public int NorthernDaysCount { get; set; }
    public int UsualDaysCount { get; set; }
}