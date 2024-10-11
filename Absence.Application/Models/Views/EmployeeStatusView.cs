namespace Vacations.Application.Models.Views;

public class EmployeeStatusView : BaseView
{
    public string PId { get; set; }
    public int Year { get; set; }
    public int StatusId { get; set; }
    public bool IsActive { get; set; }
}