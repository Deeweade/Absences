namespace Vacations.Domain.Models.Entities;

public class VacationType : BaseEntity
{
    public string Title { get; set; }

    // VacationType -> Vacation
    public virtual ICollection<Vacation> Vacations { get; set; }
}