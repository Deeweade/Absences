using System.ComponentModel.DataAnnotations;

namespace Absence.Domain.Models.Entities;

public class AbsenceType
{
    [Key]
    [Required]
    public string Id { get; set;}
    public string Title { get; set; }

    // VacationType -> Vacation
    public virtual ICollection<Absence> Absences { get; set; }
    public virtual ICollection<VacationDays> VacationDays { get; set; }
}