namespace Vacations.Domain.Models.Entities;

public class Absence : BaseEntity
{
    public int PId { get; set; }
    public int ParentAbsenceId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    
    // Vacation -> VacationType
    public int AbsenceTypeId { get; set; }
    public virtual AbsenceType AbsenceType { get; set; }
    
    // Vacation -> EntityStatus
    public int EntityStatusId { get; set; }
    public virtual EntityStatus EntityStatus { get; set; }
}