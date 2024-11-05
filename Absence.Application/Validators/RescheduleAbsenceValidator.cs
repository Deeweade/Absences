using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Actions;
using Absence.Domain.Models.Constants;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Models.Enums;
using Absence.Domain.Dtos.Queries;
using FluentValidation;
using AutoMapper;

namespace Absence.Application.Validators;

public class RescheduleAbsenceValidator : AbstractValidator<RescheduleAbsenceView>
{
    private readonly IVacationDaysService _vacationDaysService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RescheduleAbsenceValidator(IVacationDaysService vacationDaysService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _vacationDaysService = vacationDaysService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;

        RuleFor(x => x)
            .MustAsync(IsAbsenceApproved)
            .WithMessage(ExceptionMessages.GetMessage(ExceptionalEvents.ReschedullingUnapprovedAbsence));
        RuleFor(x => x)
            .MustAsync(IsEqualYears)
            .WithMessage(ExceptionMessages.GetMessage(ExceptionalEvents.ReschedullingInDifferentYear));
        RuleFor(x => x)
            .MustAsync(AreUnique)
            .WithMessage(ExceptionMessages.GetMessage(ExceptionalEvents.AbsenceExists));
        RuleFor(x => x)
            .MustAsync(IsValidDuration)
            .WithMessage(ExceptionMessages.GetMessage(ExceptionalEvents.AbsenceTooLong));
    }

    private async Task<bool> IsEqualYears(RescheduleAbsenceView view, CancellationToken token)
    {
        var cancelledAbsence = await _unitOfWork.AbsencesRepository.GetById(view.CancelledAbsenceId);

        return view.NewAbsences.All(x => x.DateStart.Date.Year == cancelledAbsence.DateStart.Year);
    }

    private async Task<bool> IsValidDuration(RescheduleAbsenceView view, CancellationToken token)
    {
        var cancelledAbsence = await _unitOfWork.AbsencesRepository.GetById(view.CancelledAbsenceId);

        var dtos = _mapper.Map<List<AbsenceDto>>(view.NewAbsences);

        var holidaysNumber = await _unitOfWork.WorkPeriodsRepository.GetHolidaysNumberInPeriods(dtos);

        var absenceDuration = dtos.Sum(x => x.Duration()) - holidaysNumber;

        return absenceDuration <= cancelledAbsence.Duration();
    }

    private async Task<bool> IsAbsenceApproved(RescheduleAbsenceView view, CancellationToken token)
    {
        var cancelledAbsence = await _unitOfWork.AbsencesRepository.GetById(view.CancelledAbsenceId);

        return cancelledAbsence.AbsenceStatusId == (int)AbsenceStatuses.Approved;
    }

    private async Task<bool> AreUnique(RescheduleAbsenceView view, CancellationToken token)
    {
        var cancelledAbsence = await _unitOfWork.AbsencesRepository.GetById(view.CancelledAbsenceId);

        var existedAbsences = await _unitOfWork.AbsencesRepository.GetByQuery(new AbsenceQueryDto
        {
            PIds = new List<string> { cancelledAbsence.PId },
            Years = new List<int> { cancelledAbsence.DateStart.Year },
            AbsenceStatuses = new List<int> { (int)AbsenceStatuses.ActiveDraft, (int)AbsenceStatuses.Approval, (int)AbsenceStatuses.Approved }
        });

        foreach (var newAbsence in view.NewAbsences)
        {
            if (existedAbsences.Any(x => x.DateStart.ToString("d").Equals(newAbsence.DateStart.ToString("d"))
                && x.DateEnd.ToString("d").Equals(newAbsence.DateEnd.ToString("d"))))
            {
                return false;
            }
        }

        return true;
    }
}