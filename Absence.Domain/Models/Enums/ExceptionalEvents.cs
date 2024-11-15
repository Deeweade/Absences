namespace Absence.Domain.Models.Enums;

public enum ExceptionalEvents
{
    AbsenceTooLong,
    ReschedullingUnapprovedAbsence,
    ReschedullingInDifferentYear,
    RemovingNotDraftAbsence,
    NotAllDaysScheduled,
    SubstitutionExists,
    DateStartMoreThanDateEnd,
    AbsenceExists,
    UpdatingNotDraftAbsence
}