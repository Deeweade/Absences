using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Actions;
using Absence.Domain.Models.Constants;
using Absence.Domain.Models.Enums;
using FluentValidation;
using AutoMapper;

namespace Absence.Application.Validators;

public class UpdateAbsenceValidator : AbsenceValidator<UpdateAbsenceView>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAbsenceValidator(IUnitOfWork unitOfWork, IVacationDaysService vacationDaysService, IMapper mapper)
        : base (unitOfWork, vacationDaysService, mapper)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x)
            .MustAsync(AllowedToUpdate)
            .WithMessage(ExceptionMessages.GetMessage(ExceptionalEvents.UpdatingNotDraftAbsence));
    }

    private async Task<bool> AllowedToUpdate(UpdateAbsenceView view, CancellationToken token)
    {
        var absence = await _unitOfWork.AbsencesRepository.GetById(view.Id);

        return absence.AbsenceStatusId == (int)AbsenceStatuses.ActiveDraft;
    }
}