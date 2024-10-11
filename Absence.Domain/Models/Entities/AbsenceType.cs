namespace Absence.Domain.Models.Entities;

public class AbsenceType : BaseEntity
{
    public string Title { get; set; }

    // VacationType -> Vacation
    public virtual ICollection<Absence> Absences { get; set; }
    public virtual ICollection<VacationDays> VacationDays { get; set; }
}