using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Services;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Dtos.Queries;
using Absence.Application.Tests;
using AutoMapper;
using Moq;

[TestFixture]
public class VacationDaysServiceTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private VacationDaysService _vacationDaysService;

    [SetUp]
    public void SetUp()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        var mapper = new MapperConfiguration(cfg => new MappingProfile()).CreateMapper();
        _vacationDaysService = new VacationDaysService(_unitOfWorkMock.Object, mapper);
    }

    [Test]
    public async Task GetAvailableDays_ShouldCalculateDaysCorrectly()
    {
        // Arrange
        var pId = "123";
        var year = 2024;
        var vacationDaysDtos = new List<VacationDaysDto>
        {
            new VacationDaysDto { PId = pId, Year = year, DaysNumber = 20, AbsenceTypeId = "1" }
        };

        var activeAbsences = new List<AbsenceDto>
        {
            new AbsenceDto { AbsenceTypeId = "1", DateStart = new DateTime(2024, 1, 1), DateEnd = new DateTime(2024, 1, 5) } // 5 дней
        };

        _unitOfWorkMock.Setup(x => x.VacationDaysRepository.GetAvailableDays(pId, year, true))
            .ReturnsAsync(vacationDaysDtos);

        _unitOfWorkMock.Setup(x => x.AbsencesRepository.GetByQuery(It.IsAny<AbsenceQueryDto>()))
            .ReturnsAsync(activeAbsences);

        // Act
        var result = await _vacationDaysService.GetAvailableDays(pId, year);

        // Assert
        Assert.That(result[0].DaysNumber, Is.EqualTo(15)); // 20 - 5 = 15 дней
    }
}