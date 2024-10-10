using Vacations.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Vacations.Infrastructure.Data.Contexts;

public class AbsenceDbContext(DbContextOptions<AbsenceDbContext> options) : DbContext(options)
{
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Comment> Comments {get; set; }
    public DbSet<Absence> Absences { get; set; }
    public DbSet<WorkPeriods> WorkPeriods { get; set; }
    public DbSet<AbsenceType> AbsenceTypes { get; set; }
    public DbSet<VacationDays> VacationDays { get; set; }
    public DbSet<AbsenceStatus> EntityStatuses { get; set; }
    public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
    public DbSet<PlanningProcess> PlanningProcesses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}