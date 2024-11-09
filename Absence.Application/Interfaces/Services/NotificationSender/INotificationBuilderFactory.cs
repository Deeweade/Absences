using Absence.Domain.Models.Enums;

namespace Absence.Application.Interfaces.Services.NotificationSender;

/// <summary>
    /// Интерфейс фабрики билдеров, позволяет получить нужный билдер параметров уведомлений
    /// </summary>
    public interface INotificationBuilderFactory
    {
        /// <summary>
        /// Метод получения реализации конкретного билдера параметров уведомлений
        /// </summary>
        /// <param name="builders">Тип билдера</param>
        /// <returns>Возвращает билдер в соответствии с типом, переданным в параметрах</returns>
        INotificationParametersBuilder GetBuilder(NotificationSubjects builders);
    }
