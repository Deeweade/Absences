namespace Absence.Domain.Dtos.Queries;

public class AbsenceQueryDto
{
    public ICollection<int> Years { get; set; } = [];
    public ICollection<int> EntityStatuses { get; set; } = [];
    public ICollection<string> PIds { get; set; } = [];
}