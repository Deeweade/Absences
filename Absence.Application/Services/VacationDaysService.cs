using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Views;
using Absence.Domain.Models.Enums;
using Absence.Domain.Dtos.Queries;
using AutoMapper;

namespace Absence.Application.Services;

public class VacationDaysService : IVacationDaysService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VacationDaysService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<VacationDaysView>> GetAvailableDays(string pId, int year)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(pId);

        var availableDaysByAbsenceTypes = await _unitOfWork.VacationDaysRepository.GetAvailableDays(pId, year, true);

        var activeAbsences = await _unitOfWork.AbsencesRepository.GetByQuery(new AbsenceQueryDto
            {
                PIds = new [] { pId },
                Years = new [] { year },
                AbsenceStatuses = new [] { (int)AbsenceStatuses.ActiveDraft, (int)AbsenceStatuses.Approval, (int)AbsenceStatuses.Approved }
            });

        foreach (var typeAvailableDays in availableDaysByAbsenceTypes)
        {
            var unavailableDays = activeAbsences
                .Where(x => x.AbsenceTypeId.Equals(typeAvailableDays.AbsenceTypeId))
                .Select(x => x.DateEnd.Subtract(x.DateStart).Days + 1)
                .Sum();

            var subtraction = typeAvailableDays.DaysNumber - unavailableDays;

            typeAvailableDays.DaysNumber = subtraction < 0 ? 0 : subtraction;
        }

        return _mapper.Map<List<VacationDaysView>>(availableDaysByAbsenceTypes);
    }
}