namespace Vacations.Domain.Models.Entities;

public class AvailableDays : BaseEntity
{
    public int EmployeeTabNumber { get; set; }
    public int NorthernDaysCount { get; set; }
    public int UsualDaysCount { get; set; }
}