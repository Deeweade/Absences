using Absence.Domain.Models.Entities;

namespace Absence.Domain.Models.Entities;

public class SystemProcess : BaseEntity
{
    public string Title { get; set; }

    public virtual ICollection<ProcessStage> Stages { get; set; }
}
