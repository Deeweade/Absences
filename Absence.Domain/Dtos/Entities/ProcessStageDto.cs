using Absence.Domain.Models.Entities;

namespace Absence.Domain.Dtos.Entities;

public class ProcessStageDto : BaseDto
{
    public string Title { get; set; }
    public int Year { get; set; }
    public int ProcessId { get; set; }

    public SystemProcess Process { get; set; }
}