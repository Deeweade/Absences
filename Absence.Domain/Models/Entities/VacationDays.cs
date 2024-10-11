namespace Absence.Domain.Models.Entities;

public class VacationDays : BaseEntity
{
    public string PId { get; set; }
    public int DaysNumber { get; set; }
    public bool IsYearPlanning { get; set; }
    public int AbsenceTypeId { get; set; }

    public virtual AbsenceType AbsenceType { get; set; }
}