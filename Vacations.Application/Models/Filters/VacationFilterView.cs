namespace Vacations.Application.Models.Filters;

public class VacationFilterView
{
    public ICollection<int>? Years { get; set; } = [];
    public ICollection<int>? EntityStatuses { get; set; } = [];
}