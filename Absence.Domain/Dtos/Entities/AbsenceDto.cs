namespace Absence.Domain.Dtos.Entities;

public class AbsenceDto : BaseDto
{
    public string PId { get; set; }
    public int ParentAbsenceId { get; set; }
    public string AbsenceTypeId { get; set; }
    public int AbsenceStatusId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }

    public AbsenceTypeDto AbsenceType { get; set; }
    public AbsenceStatusDto AbsenceStatus { get; set; }

    public int Duration()
    {
        return DateEnd.Subtract(DateStart).Days + 1;
    }
}