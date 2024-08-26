using System.ComponentModel.DataAnnotations.Schema;

namespace Vacations.Domain.Models.Entities;

[Table("EntityStatus")]
public class EntityStatus : BaseEntity
{
    public string Name { get; set; }

    // EntityStatus -> Vacation
    public virtual ICollection<Vacation> Vacations { get; set; }
}