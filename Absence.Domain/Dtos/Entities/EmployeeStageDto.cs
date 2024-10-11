namespace Vacations.Domain.Dtos.Entities;

public class EmployeeStageDto : BaseDto
{
    public string PId { get; set; }
    public int StageId { get; set; }

    public ProcessStageDto Stage { get; set; }
}