namespace Absence.Application.Models.Queries;

public class AbsenceQueryView
{
    public ICollection<int> Years { get; set; } = [];
    public ICollection<string> PIds { get; set; } = [];
    public ICollection<int> EntityStatuses { get; set; } = [];
}