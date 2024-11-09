using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Models.Constants;
using Microsoft.EntityFrameworkCore;

namespace Absence.Infrastructure.Data.Repositories;

public class NotificationSettingsRepository : INotificationSettingsRepository
{
    private readonly AbsenceDbContext _context;

    public NotificationSettingsRepository(AbsenceDbContext context)
    {
        _context = context;
    }

    public async Task<string> GetDefaultEmail()
    {
        return await _context.NotificationSettings
            .AsNoTracking()
            .Where(x => x.Title.Equals(SettingNameConstants.DefaultEmail))
            .Select(x => x.Value)
            .FirstOrDefaultAsync();
    }

    public async Task<string> GetDisplayedName()
    {
        return await _context.NotificationSettings
            .AsNoTracking()
            .Where(x => x.Title.Equals(SettingNameConstants.DisplayedName))
            .Select(x => x.Value)
            .FirstOrDefaultAsync();
    }

    public async Task<string> GetFrom()
    {
        return await _context.NotificationSettings
            .AsNoTracking()
            .Where(x => x.Title.Equals(SettingNameConstants.From))
            .Select(x => x.Value)
            .FirstOrDefaultAsync();
    }

    public async Task<string> GetOverrideToEmail()
    {
        return await _context.NotificationSettings
            .AsNoTracking()
            .Where(x => x.Title.Equals(SettingNameConstants.CC))
            .Select(x => x.Value)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> IsOverride()
    {
        return await _context.NotificationSettings
            .AsNoTracking()
            .Where(x => x.Title.Equals(SettingNameConstants.IsOverride))
            .Select(x => x.Value.ToLower().Equals("true") ? true : false)
            .FirstOrDefaultAsync();
    }
}