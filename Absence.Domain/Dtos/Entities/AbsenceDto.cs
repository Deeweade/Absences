using Absence.Domain.Models.Entities;

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
    public AbsenceStatus AbsenceStatus { get; set; }
}