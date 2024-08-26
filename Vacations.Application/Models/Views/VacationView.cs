namespace Vacations.Application.Models.Views;

public class VacationView : HistoryEntityView
{
    public int EmployeeTabNumber { get; set; }
    public int ParentVacationId { get; set; }
    public int VacationTypeId { get; set; }
    public int EntityStatusId { get; set; }
}