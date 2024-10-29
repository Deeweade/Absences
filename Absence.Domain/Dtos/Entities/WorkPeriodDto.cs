using System;

namespace Absence.Domain.Dtos.Entities;

public class WorkPeriodDto : BaseDto
{
    public DateTime Date { get; set; }
    public int WorkdayTypeId { get; set; }

    public virtual WorkdayTypeDto WorkdayType { get; set; }
}