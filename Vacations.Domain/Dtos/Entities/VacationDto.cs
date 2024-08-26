namespace Vacations.Domain.Dtos.Entities;

public class VacationDto : BaseEntityDto
{
    public int EmployeeTabNumber { get; set; }
    public int ParentVacationId { get; set; }
    public int VacationTypeId { get; set; }
    public int EntityStatusId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}