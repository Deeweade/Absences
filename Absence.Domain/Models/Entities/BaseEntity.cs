using System.ComponentModel.DataAnnotations.Schema;

namespace Absence.Domain.Models.Entities;

public abstract class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}
