namespace Absence.Domain.Dtos.Entities;

public class CommentDto : BaseDto
{
    public string Text { get; set; }
    public string PId { get; set; }
    public int StatusId { get; set; }
}