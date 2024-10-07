namespace Vacations.Domain.Dtos.Entities;

public class VacationDaysDto : BaseDto
{
    public int PId { get; set; }
    public int NorthernDaysCount { get; set; }
    public int RegularDaysCount { get; set; }
    public bool IsYearPlanning { get; set; }
}