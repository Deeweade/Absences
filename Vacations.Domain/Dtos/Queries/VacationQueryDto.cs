namespace Vacations.Domain.Dtos.Queries;

public class VacationQueryDto
{
    public ICollection<int>? Years { get; set; } = [];
    public ICollection<int>? EntityStatuses { get; set; } = [];
    public ICollection<int>? EmployeeTabNumbers { get; set; } = [];
}