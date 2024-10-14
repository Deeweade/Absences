using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface ISubstitutionsService
{
    Task<SubstitutionView> Create(SubstitutionView view);
}
