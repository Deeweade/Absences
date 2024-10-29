using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Views;
using Absence.Domain.Models.Constants;
using Absence.Domain.Models.Enums;
using Absence.Domain.Dtos.Queries;
using FluentValidation;

namespace Absence.Application.Validators;

public class AbsenceValidator<T> : AbstractValidator<T> where T : AbsenceView
{
    private readonly IVacationDaysService _vacationDaysService;
    private readonly IUnitOfWork _unitOfWork;

    public AbsenceValidator(IUnitOfWork unitOfWork, IVacationDaysService vacationDaysService)
    {
        _vacationDaysService = vacationDaysService;
        _unitOfWork = unitOfWork;

        RuleFor(x => x.DateStart)
            .LessThanOrEqualTo(x => x.DateEnd).WithMessage(ExceptionMessages.GetMessage(ExceptionalEvents.DateStartMoreThanDateEnd));
        RuleFor(x => x)
            .MustAsync(IsUnique).WithMessage(ExceptionMessages.GetMessage(ExceptionalEvents.AbsenceExists));
    }

    // public virtual async Task<bool> IsValidDuration(T view, CancellationToken token)
    // {
    //     var remainingDays = (await _vacationDaysService.GetRemainingDays(view.PId, view.DateStart.Year))
    //         .FirstOrDefault(x => x.AbsenceTypeId.Equals(view.AbsenceTypeId));

    //     return remainingDays.DaysNumber >= view.DateEnd.Subtract(view.DateStart).Days + 1;
    // }

    private async Task<bool> IsUnique(T view, CancellationToken token)
    {
        var absences = await _unitOfWork.AbsencesRepository.GetByQuery(new AbsenceQueryDto
        {
            PIds = new List<string> { view.PId },
            Years = new List<int> { view.DateStart.Year },
            AbsenceStatuses = new List<int> { (int)AbsenceStatuses.ActiveDraft, (int)AbsenceStatuses.Approval, (int)AbsenceStatuses.Approved }
        });

        return !absences.Any(x => x.DateStart.Date == view.DateStart.Date
            && x.DateEnd.Date == view.DateEnd.Date);
    }
}