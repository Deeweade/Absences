namespace Vacations.Application.Models.Views;

public abstract class HistoryEntityView : BaseEntityView
{
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}