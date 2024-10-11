namespace Vacations.Domain.Dtos.Entities;

public class AbsenceDto : BaseDto
{
    public string PId { get; set; }
    public int ParentAbsenceId { get; set; }
    public int AbsenceTypeId { get; set; }
    public int AbsenceStatusId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}