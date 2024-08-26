namespace Vacations.Domain.Models.Entities;

public class Vacation : HistoryEntity
{
    public int EmployeeTabNumber { get; set; }

    public int ParentVacationId { get; set; }
    
    // Vacation -> VacationType
    public int VacationTypeId { get; set; }
    public virtual VacationType VacationType { get; set; }
    
    // Vacation -> EntityStatus
    public int EntityStatusId { get; set; }
    public virtual EntityStatus EntityStatus { get; set; }
}