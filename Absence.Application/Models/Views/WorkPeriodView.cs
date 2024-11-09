namespace Absence.Application.Models.Views;

public class WorkPeriodView : BaseView
{
    public DateTime Date { get; set; }
    public int WorkdayTypeId { get; set; }

    public virtual WorkdayTypeView WorkdayType { get; set; }
}