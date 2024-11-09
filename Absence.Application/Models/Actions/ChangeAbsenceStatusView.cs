namespace Absence.Application.Models.Actions;

public class ChangeAbsenceStatusView
{
    public int AbsenceId { get; set; }
    public int NewAbsenceStatusId { get; set; }
}