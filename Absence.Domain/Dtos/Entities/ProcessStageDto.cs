namespace Absence.Domain.Dtos.Entities;

public class ProcessStageDto : BaseDto
{
    public string Title { get; set; }
    public int Year { get; set; }
    public int ProcessId { get; set; }

    public SystemProcessDto Process { get; set; }
}