using Absence.Domain.Models.Enums;

namespace Absence.Domain.Models.Constants;

public static class ExceptionMessages
{
    private static readonly Dictionary<ExceptionalEvents, string> _messages = new Dictionary<ExceptionalEvents, string>
    {
        { ExceptionalEvents.AbsenceTooLong, "Absence duration is more than the number of available days" },
        { ExceptionalEvents.ReschedullingUnapprovedAbsence, "Cannot reschedule unapproved absence" },
        { ExceptionalEvents.ReschedullingInDifferentYear, "Cannot reschedule absence in different year" },
        { ExceptionalEvents.RemovingNotDraftAbsence, $"Cannot delete an absence with not '{AbsenceStatuses.ActiveDraft}' status" }
    };

    public static string GetMessage(ExceptionalEvents key)
    {
        return _messages.TryGetValue(key, out var message) ? message : "Unknown exception.";
    }   
}