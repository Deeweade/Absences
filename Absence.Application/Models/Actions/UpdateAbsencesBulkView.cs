namespace Absence.Application.Models.Actions;

public class UpdateAbsencesBulkView
{
    public List<int> AbsencesIds { get; set; }
    public int AbsenceStatusId { get; set; }
}