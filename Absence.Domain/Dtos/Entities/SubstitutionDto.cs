namespace Absence.Domain.Dtos.Entities;

public class SubstitutionDto : BaseDto
{
    public string EmployeePId { get; set; }
    public string SubstitutePId { get; set; }
    public DateTime DateEnd { get; set; }
}