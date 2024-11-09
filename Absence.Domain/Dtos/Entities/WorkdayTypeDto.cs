namespace Absence.Domain.Dtos.Entities;

public class WorkdayTypeDto : BaseDto
{
    public string Name { get; set; }

    public virtual ICollection<WorkPeriodDto> WorkPeriods { get; set; }
}