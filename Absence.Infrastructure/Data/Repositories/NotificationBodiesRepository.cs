using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Absence.Infrastructure.Data.Repositories;

public class NotificationBodiesRepository : INotificationBodiesRepository
{
    private readonly AbsenceDbContext _context;

    public NotificationBodiesRepository(AbsenceDbContext context)
    {
        _context = context;
    }

    public async Task<string> GetByTypeId(int notificationType)
    {
        return await _context.NotificationBodies
            .AsNoTracking()
            .Where(x => x.NotificationTypeId == notificationType)
            .Select(x => x.Text)
            .FirstOrDefaultAsync();
    }
}
