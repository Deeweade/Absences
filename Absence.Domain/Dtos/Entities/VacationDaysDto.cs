namespace Absence.Domain.Dtos.Entities;

public class VacationDaysDto : BaseDto
{
    public string PId { get; set; }
    public int Year { get; set; }
    public int NorthernDaysCount { get; set; }
    public int RegularDaysCount { get; set; }
    public bool IsYearPlanning { get; set; }
}