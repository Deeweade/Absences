using Absence.Infrastructure.Data.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Absence.Infrastructure.Tests;
using AutoMapper;

[TestFixture]
public class VacationDaysRepositoryTests
{
    private VacationDaysRepository _vacationDaysRepository;
    private AbsenceDbContext _context;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<AbsenceDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;

        _context = new AbsenceDbContext(options);
        _context.Database.OpenConnection();
        _context.Database.EnsureCreated();

        var mapper = new MapperConfiguration(cfg => new MappingProfile()).CreateMapper();
        _vacationDaysRepository = new VacationDaysRepository(_context, mapper);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task GetAvailableDays_ShouldReturnCorrectData()
    {
        // Arrange
        var vacationDays = new VacationDays { PId = "123", Year = 2024, DaysNumber = 20, IsYearPlanning = true };
        await _context.VacationDays.AddAsync(vacationDays);
        await _context.SaveChangesAsync();

        // Act
        var result = await _vacationDaysRepository.GetAvailableDays("123", 2024, true);

        // Assert
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].DaysNumber, Is.EqualTo(20));
    }
}