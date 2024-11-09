using Absence.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Absence.Infrastructure.Data.Contexts;

public class AbsenceDbContext(DbContextOptions<AbsenceDbContext> options) : DbContext(options)
{
    public DbSet<Comment> Comments {get; set; }
    public DbSet<WorkPeriod> WorkPeriods { get; set; }
    public DbSet<SystemProcess> Processes { get; set; }
    public DbSet<WorkdayType> WorkdayTypes { get; set; }
    public DbSet<AbsenceType> AbsenceTypes { get; set; }
    public DbSet<VacationDays> VacationDays { get; set; }
    public DbSet<Substitution> Substitutions { get; set; }
    public DbSet<ProcessStage> ProcessStages { get; set; }
    public DbSet<EmployeeStage> EmployeeStages { get; set; }
    public DbSet<AbsenceStatus> AbsenceStatuses { get; set; }
    public DbSet<PlanningProcess> PlanningProcesses { get; set; }
    public DbSet<NotificationType> NotificationTypes { get; set; }
    public DbSet<NotificationBody> NotificationBodies { get; set; }
    public DbSet<NotificationTitle> NotificationTitles { get; set; }
    public DbSet<NotificationMethod> NotificationMethods { get; set; }
    public DbSet<Domain.Models.Entities.Absence> Absences { get; set; }
    public DbSet<NotificationSetting> NotificationSettings { get; set; }
    public DbSet<PositionAndEmployees> PositionAndEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbsenceType>()
            .Property(e => e.Id)
            .IsRequired();

        modelBuilder.Entity<PositionAndEmployees>()
            .HasNoKey();

        modelBuilder.Entity<PositionAndEmployees>()
            .Property(x => x.SOPercent)
            .HasPrecision(18, 0);
        modelBuilder.Entity<PositionAndEmployees>()
            .Property(x => x.SPPercent)
            .HasPrecision(18, 0);

        base.OnModelCreating(modelBuilder);
    }
}