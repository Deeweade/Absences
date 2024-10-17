namespace Absence.Application.Models.Views;

public class ProcessStageView : BaseView
{
    public string Title { get; set; }
    public int Year { get; set; }
    public int ProcessId { get; set; }

    public SystemProcessView Process { get; set; }
}