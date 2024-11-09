namespace Absence.Application.Models.Views;

public class SubstitutionView : BaseView
{
    public string EmployeePId { get; set; }
    public string DeputyPId { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
}
