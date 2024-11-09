namespace Absence.Application.Models.Actions;

public class UpdateAbsencesBulkView
{
    public List<string> PIds { get; set; }
    public int Year { get; set; }
    public int AbsenceStatusId { get; set; }
}