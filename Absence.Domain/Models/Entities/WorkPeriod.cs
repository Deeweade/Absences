namespace Absence.Domain.Models.Entities;

public class WorkPeriod : BaseEntity
{
    public DateTime Date { get; set; }
    public int WorkdayTypeId { get; set; }

    public virtual WorkdayType WorkdayType { get; set; }
}