using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IPlanningProcessService
{
    Task<PlanningProcessView> GetActive();
}