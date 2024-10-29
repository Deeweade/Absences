using System;

namespace Absence.Domain.Models.Entities;

public class WorkdayType : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<WorkPeriod> WorkPeriods { get; set; }
}