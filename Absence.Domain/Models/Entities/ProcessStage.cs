using Absence.Domain.Models.Entities;

namespace Absence.Domain.Models.Entities;

public class ProcessStage : BaseEntity
{
    public string Title { get; set; }
    public int Year { get; set; }
    public int ProcessId { get; set; }

    public virtual SystemProcess Process { get; set; }

    public virtual ICollection<EmployeeStage> EmployeeStages { get; set; }
}