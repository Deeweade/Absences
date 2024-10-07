namespace Vacations.Domain.Models.Entities;

public class Status : BaseEntity
{
    public string Title { get; set; }

    public virtual ICollection<EmployeeStatus> EmployeeStatuses { get; set; }
}