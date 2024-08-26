namespace Vacations.Domain.Models.Entities;

public class Calendar : BaseEntity
{
    public DateTime Date { get; set; }
    public bool IsWorkingDay { get; set; } // true - working day, false - weekend
}