namespace Absence.Domain.Dtos.Entities;

public class VacationDaysDto : BaseDto
{
    public string PId { get; set; }
    public int Year { get; set; }
    public int DaysNumber { get; set; }
    public bool IsYearPlanning { get; set; }
    public string AbsenceTypeId { get; set; }

    public AbsenceTypeDto AbsenceType { get; set; }
}