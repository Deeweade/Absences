using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Actions;
using Absence.Domain.Models.Constants;
using Absence.Domain.Models.Enums;
using FluentValidation;

namespace Absence.Application.Validators;

public class CreateAbsenceValidator : AbsenceValidator<CreateAbsenceView>
{
    public CreateAbsenceValidator(IUnitOfWork unitOfWork, IVacationDaysService vacationDaysService)
        : base (unitOfWork, vacationDaysService)
    {
        // RuleFor(x => x)
        //     .MustAsync(IsValidDuration)
        //     .WithMessage(ExceptionMessages.GetMessage(ExceptionalEvents.AbsenceTooLong));
    }
}