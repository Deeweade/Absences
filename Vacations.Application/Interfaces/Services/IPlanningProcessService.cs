using Vacations.Application.Models.Views;

namespace Vacations.Application.Interfaces.Services;

public interface IPlanningProcessService
{
    Task<PlanningProcessView> GetActive();
}