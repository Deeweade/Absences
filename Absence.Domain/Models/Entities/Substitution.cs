namespace Absence.Domain.Models.Entities;

/// <summary>
/// Замещения одних сотрудников другими
/// </summary>
public class Substitution : BaseEntity
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