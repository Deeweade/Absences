using System;

namespace Absence.Domain.Dtos.Queries;

public class EmployeeStagesQueryDto
{
    public List<string> PIds { get; set; }
    public int? Year { get; set; }
}
