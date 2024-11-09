using Absence.Domain.Models.Enums;

namespace Absence.Domain.Models.Constants;

public static class ExceptionMessages
{
    private static readonly Dictionary<ExceptionalEvents, string> _messages = new Dictionary<ExceptionalEvents, string>
    {
        { ExceptionalEvents.AbsenceTooLong, "Количество дней в отпуске больше, чем количество доступных к планированию дней" },
        { ExceptionalEvents.ReschedullingUnapprovedAbsence, "Нельзя перенести ещё не согласованный отпуск" },
        { ExceptionalEvents.ReschedullingInDifferentYear, "Нельзя перенести отпуск на другой год" },
        { ExceptionalEvents.RemovingNotDraftAbsence, "Нельзя удалить отпуск не со статусом 'Черновик'" },
        { ExceptionalEvents.NotAllDaysScheduled, "Не все доступные дни распланированы" },
        { ExceptionalEvents.SubstitutionExists, "Данный сотрудник уже назначен замещающим" },
        { ExceptionalEvents.DateStartMoreThanDateEnd, "Дата начала должна быть меньше или равна дате окончания" },
        { ExceptionalEvents.AbsenceExists, "Отпуск с этими датами уже существует" },
        { ExceptionalEvents.UpdatingNotDraftAbsence, "Можно редактировать отпуск только со статусом 'Черновик'" }
    };

    public static string GetMessage(ExceptionalEvents key)
    {
        return _messages.TryGetValue(key, out var message) ? message : "Unknown exception.";
    }   
}