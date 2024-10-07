namespace Vacations.Application.Models.Views;

public class AbsenceView : BaseView
{
    public int PId { get; set; }
    public int ParentAbsenceId { get; set; }
    public int AbsenceType { get; set; }
    public int EntityStatusId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}