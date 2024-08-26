namespace Vacations.Domain.Dtos.Entities;

public class CommentDto : BaseEntityDto
{
    public string Text { get; set; }
    public int EmployeeTabNumber { get; set; }
    public int StatusId { get; set; }
}