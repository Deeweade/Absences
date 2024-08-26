namespace Vacations.Domain.Dtos.Entities;

public class AvailableDaysDto : BaseEntityDto
{
    public int EmployeeTabNumber { get; set; }
    public int NorthernDaysCount { get; set; }
    public int UsualDaysCount { get; set; }
}