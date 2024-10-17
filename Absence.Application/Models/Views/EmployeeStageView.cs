namespace Absence.Application.Models.Views;

public class EmployeeStageView : BaseView
{
    public string PId { get; set; }
    public int StageId { get; set; }

    public ProcessStageView Stage { get; set; }
}