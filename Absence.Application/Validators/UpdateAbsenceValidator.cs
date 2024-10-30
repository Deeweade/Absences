using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Actions;
using Absence.Domain.Models.Constants;
using Absence.Domain.Models.Enums;
using FluentValidation;

namespace Absence.Application.Validators;

public class UpdateAbsenceValidator : AbsenceValidator<UpdateAbsenceView>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAbsenceValidator(IUnitOfWork unitOfWork, IVacationDaysService vacationDaysService)
        : base (unitOfWork, vacationDaysService)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x)
            .MustAsync(AllowedToUpdate)
            .WithMessage(ExceptionMessages.GetMessage(ExceptionalEvents.UpdatingNotDraftAbsence));
        // RuleFor(x => x)
        //     .MustAsync(IsValidDuration)
        //     .WithMessage(ExceptionMessages.GetMessage(ExceptionalEvents.AbsenceTooLong));
    }

    public new async Task<bool> IsValidDuration(UpdateAbsenceView view, CancellationToken token)
    {
        var previousVersion = await _unitOfWork.AbsencesRepository.GetById(view.Id);

        return view.DateEnd.Subtract(view.DateStart).Days <= previousVersion.DateEnd.Subtract(previousVersion.DateStart).Days;
    }

    private async Task<bool> AllowedToUpdate(UpdateAbsenceView view, CancellationToken token)
    {
        var absence = await _unitOfWork.AbsencesRepository.GetById(view.Id);

        return absence.AbsenceStatusId == (int)AbsenceStatuses.ActiveDraft;
    }
}