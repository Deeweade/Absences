namespace Absence.Application.Models.Actions;

public class UpdateAbsencesBulkView
{
    public List<int> AbsencesIds { get; set; }
    public List<string> PIds { get; set; }
    public int AbsenceStatusId { get; set; }
}
