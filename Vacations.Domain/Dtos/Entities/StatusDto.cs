namespace Vacations.Domain.Dtos.Entities;

public class StatusDto : BaseEntityDto
{
    public int EmployeeTabNumber { get; set; }
    public int Year { get; set; }
    public int PlanningStatusId { get; set; }
}