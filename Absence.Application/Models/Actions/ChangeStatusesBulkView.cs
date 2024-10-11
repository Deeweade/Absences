namespace Absence.Application.Models.Actions;

public class ChangeStatusesBulkView
{
    public List<string> PIds { get; set; }
    public int AbsenceStatusId { get; set; }
}
