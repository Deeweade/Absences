namespace Absence.Domain.Dtos.Entities;

public class SubstitutionDto : BaseDto
{
    /// <summary>
    /// Табельный номер сотрудника, которого замещают
    /// </summary>
    public string EmployeePId { get; set; }
    /// <summary>
    /// Табельный номер сотрудника, который замещает
    /// </summary>
    public string DeputyPId { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}