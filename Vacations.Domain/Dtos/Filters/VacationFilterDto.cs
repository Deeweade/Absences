namespace Vacations.Domain.Dtos.Filters;

public class VacationFilterDto
{
    public ICollection<int>? Years { get; set; } = [];
    public ICollection<int>? EntityStatuses { get; set; } = [];
}