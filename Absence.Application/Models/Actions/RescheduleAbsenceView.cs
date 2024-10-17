using Absence.Application.Models.Views;

namespace Absence.Application.Models.Actions;

public class RescheduleAbsenceView
{
    public int CancelledAbsenceId { get; set; }

    public List<AbsenceView> NewAbsences { get; set; }
}
