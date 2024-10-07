namespace Vacations.Domain.Models.Entities;

public class VacationDays : BaseEntity
{
    public int PId { get; set; }
    public int NorthernDaysCount { get; set; }
    public int RegularDaysCount { get; set; }
    public bool IsYearPlanning { get; set; }
}