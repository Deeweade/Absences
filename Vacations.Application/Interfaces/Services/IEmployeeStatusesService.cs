using Vacations.Application.Models.Views;

namespace Vacations.Application.Interfaces.Services;

public interface IEmployeeStatusesService
{
    Task<EmployeeStatusView> ChangeStatus(EmployeeStatusView status);
}