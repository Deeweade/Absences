namespace Absence.Application.Models.Views;

public class AbsenceView : BaseView
{
    public string PId { get; set; }
    public int ParentAbsenceId { get; set; }
    public string AbsenceTypeId { get; set; }
    public int AbsenceStatusId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}