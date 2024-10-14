namespace Absence.Application.Models.Actions;

public class UpdateStagesBulkView
{
    public int AbsenceStatusId { get; set; }
    public List<string> PIds { get; set; }
    public int Year { get; internal set; }
}
