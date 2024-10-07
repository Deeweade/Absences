namespace Vacations.Domain.Dtos.Entities;

public class CommentDto : BaseDto
{
    public string Text { get; set; }
    public int PId { get; set; }
    public int StatusId { get; set; }
}