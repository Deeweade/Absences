namespace Vacations.Application.Models.Views;

public class CommentView : BaseView
{
    public string Text { get; set; }
    public int PId { get; set; }
    public int StatusId { get; set; }
}