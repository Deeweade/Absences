namespace Vacations.Domain.Dtos.Entities;

public class EmployeeStatusDto : BaseDto
{
    public int PId { get; set; }
    public int Year { get; set; }
    public int StatusId { get; set; }
    public bool IsActive { get; set; }
}