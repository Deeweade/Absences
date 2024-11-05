using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Actions;
using AutoMapper;

namespace Absence.Application.Validators;

public class CreateAbsenceValidator : AbsenceValidator<CreateAbsenceView>
{
    public CreateAbsenceValidator(IUnitOfWork unitOfWork, IVacationDaysService vacationDaysService, IMapper mapper)
        : base (unitOfWork, vacationDaysService, mapper)
    {
    }
}