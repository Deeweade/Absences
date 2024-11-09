namespace Absence.Domain.Models.Entities;

public class VacationDays : BaseEntity
{
    public string PId { get; set; }
    public int Year { get; set; }
    public int AvailableDaysNumber { get; set; }
    public int PlannedDaysNumber { get; set; }
    public bool IsYearPlanning { get; set; }
    public string AbsenceTypeId { get; set; }

    public virtual AbsenceType AbsenceType { get; set; }
}