using Absence.Domain.Models.Enums;

namespace Absence.Application.Services.NotificationService.Parameters;

public class BuilderOptions
{
    public NotificationTypes NotificationType { get; set; }
    public string AbsenceOwnerPId { get; set; }
    public int AbsenceId { get; set; }
    public int SubstitutionId { get; set; }
}