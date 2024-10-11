namespace Absence.Domain.Models.Entities;

public class AbsenceStatus : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Absence> Absences { get; set; }
}