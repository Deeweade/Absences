namespace Absence.Application.Models.Actions;

public class UpdateEmployeeStageView
{
    public string PId { get; set; }
    public int Year { get; set; }
    public bool IsNextStage { get; set; }
}
