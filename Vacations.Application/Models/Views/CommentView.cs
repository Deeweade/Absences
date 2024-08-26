namespace Vacations.Application.Models.Views;

public class CommentView : BaseEntityView
{
    public string Text { get; set; }
    public int EmployeeTabNumber { get; set; }
    public int StatusId { get; set; }
}