using Vacations.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Vacations.Infrastructure.Data.Contexts;

public class VacationsDbContext(DbContextOptions<VacationsDbContext> options) : DbContext(options)
{
    public DbSet<AvailableDays> AvailableDays { get; set; }
    public DbSet<Comment> Comments {get; set; }
    public DbSet<EntityStatus> EntityStatuses { get; set; }
    public DbSet<PlanningProcess> PlanningProcesses { get; set; }
    public DbSet<PlanningStatus> PlanningStatuses { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Vacation> Vacations { get; set; }
    public DbSet<VacationType> VacationTypes { get; set; }
    public DbSet<Calendar> Calendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}