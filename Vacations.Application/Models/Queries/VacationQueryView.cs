namespace Vacations.Application.Models.Queries;

public class VacationQueryView
{
    public ICollection<int>? Years { get; set; } = [];
    public ICollection<int>? EntityStatuses { get; set; } = [];
    public ICollection<int>? EmployeeTabNumber { get; set; } = [];
}