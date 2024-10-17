using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IEmployeesService
{
    Task<PositionAndEmployeesView> GetByLogin(string login);
    //Task<List<PositionAndEmployeesView>> GetPeers(string pId);
}