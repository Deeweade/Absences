using Absence.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Absence.Infrastructure.Data.Contexts;

public class AbsenceDbContext(DbContextOptions<AbsenceDbContext> options) : DbContext(options)
{
    public DbSet<Comment> Comments {get; set; }
    public DbSet<WorkPeriods> WorkPeriods { get; set; }
    public DbSet<SystemProcess> Processes { get; set; }
    public DbSet<AbsenceType> AbsenceTypes { get; set; }
    public DbSet<VacationDays> VacationDays { get; set; }
    public DbSet<Substitution> Substitutions { get; set; }
    public DbSet<ProcessStage> ProcessStages { get; set; }
    public DbSet<EmployeeStage> EmployeeStages { get; set; }
    public DbSet<AbsenceStatus> AbsenceStatuses { get; set; }
    public DbSet<PlanningProcess> PlanningProcesses { get; set; }
    public DbSet<Absence.Domain.Models.Entities.Absence> Absences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbsenceType>()
            .Property(e => e.Id)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}