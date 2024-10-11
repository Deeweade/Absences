namespace Absence.Domain.Models.Entities;

public class WorkPeriods : BaseEntity
{
    public DateTime Date { get; set; }
    public bool IsWorkingDay { get; set; } // true - working day, false - weekend
}