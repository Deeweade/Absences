namespace Vacations.Application.Models.Queries;

public class AbsenceQueryView
{
    public ICollection<int> Years { get; set; } = [];
    public ICollection<int> EntityStatuses { get; set; } = [];
    public ICollection<int> PIds { get; set; } = [];
}