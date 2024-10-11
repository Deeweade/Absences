namespace Absence.Domain.Models.Entities;

public class Absence : BaseEntity
{
    public string PId { get; set; }
    public int ParentAbsenceId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    
    // Vacation -> VacationType
    public int AbsenceTypeId { get; set; }
    public virtual AbsenceType AbsenceType { get; set; }
    
    // Vacation -> EntityStatus
    public int AbsenceStatusId { get; set; }
    public virtual AbsenceStatus AbsenceStatus { get; set; }
}