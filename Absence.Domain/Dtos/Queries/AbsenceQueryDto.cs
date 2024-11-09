namespace Absence.Domain.Dtos.Queries;

public class AbsenceQueryDto
{
    public ICollection<int> Ids { get; set; }
    public ICollection<int> Years { get; set; } = [];
    public ICollection<string> PIds { get; set; } = [];
    public ICollection<int> AbsenceStatuses { get; set; } = [];
}