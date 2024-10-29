namespace Absence.Application.Interfaces.Services.NotificationSender;

public interface IEmailFormattingService
{
    /// <summary>
    /// Заменяет специальные слова в тексте уведомления значениями из словаря
    /// </summary>
    /// <param name="notificationBody">Текст уведомления</param>
    /// <param name="dict">Словарь со значениями</param>
    /// <returns>Отредактированный текст</returns>
    string ReplaceParams(string notificationBody, Dictionary<string, string> dict);
}