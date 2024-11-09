namespace Absence.Domain.Interfaces.Repositories;

public interface INotificationSettingsRepository
{
    Task<string> GetFrom();
    Task<bool> IsOverride();
    Task<string> GetDefaultEmail();
    Task<string> GetDisplayedName();
    Task<string> GetOverrideToEmail();
}