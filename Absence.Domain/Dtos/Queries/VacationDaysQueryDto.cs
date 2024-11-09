namespace Absence.Domain.Dtos.Queries;

public class VacationDaysQueryDto
{
    public int? Year { get; set; }
    public string PId { get; set; }
    public bool? IsYearPlanning { get; set; }
}
