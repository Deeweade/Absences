namespace Absence.Domain.Models.Entities;

public class Substitution : BaseEntity
{
    public string EmployeePId { get; set; }
    public string SubstitutePId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}