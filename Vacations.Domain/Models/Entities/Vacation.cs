namespace Vacations.Domain.Models.Entities;

public class Vacation : BaseEntity
{
    public int EmployeeTabNumber { get; set; }
    public int ParentVacationId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    
    // Vacation -> VacationType
    public int VacationTypeId { get; set; }
    public virtual VacationType VacationType { get; set; }
    
    // Vacation -> EntityStatus
    public int EntityStatusId { get; set; }
    public virtual EntityStatus EntityStatus { get; set; }
}