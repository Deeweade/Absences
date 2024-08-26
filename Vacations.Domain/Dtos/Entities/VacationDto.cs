namespace Vacations.Domain.Dtos.Entities;

public class VacationDto : HistoryEntityDto
{
    public int EmployeeTabNumber { get; set; }
    public int ParentVacationId { get; set; }
    public int VacationTypeId { get; set; }
    public int EntityStatusId { get; set; }
}