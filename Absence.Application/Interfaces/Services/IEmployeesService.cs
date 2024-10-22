using Absence.Application.Models.Views;

namespace Absence.Application.Interfaces.Services;

public interface IEmployeesService
{
    Task<PositionAndEmployeesView> GetManager(string pId);
    Task<PositionAndEmployeesView> GetByLogin(string login);
    Task<List<PositionAndEmployeesView>> GetPeers(string pId);
    Task<List<PositionAndEmployeesView>> GetSubordinates(string pId, bool includeSubstitutions);
}