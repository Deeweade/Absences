using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Views;
using AutoMapper;
using Absence.Domain.Dtos.Entities;

namespace Absence.Application.Services;

public class EmployeesService : IEmployeesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PositionAndEmployeesView> GetByLogin(string login)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(login);

        var employee = await _unitOfWork.EmployeesRepository.GetByLogin(login);

        return _mapper.Map<PositionAndEmployeesView>(employee);
    }

    public async Task<List<PositionAndEmployeesView>> GetPeers(string pId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(pId);

        var employee = await _unitOfWork.EmployeesRepository.GetByPId(pId);

        if (employee.ManagerPId is null) return null;

        var peers = await _unitOfWork.EmployeesRepository.GetSubordinates(employee.ManagerPId);

        if (peers is null || !peers.Any()) return null;

        employee = peers.FirstOrDefault(x => x.PId == pId);

        peers.Remove(employee);

        return _mapper.Map<List<PositionAndEmployeesView>>(peers);
    }

    public async Task<List<PositionAndEmployeesView>> GetSubordinates(string pId, bool includeSubstitutions)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(pId);

        var subordinates = await _unitOfWork.EmployeesRepository.GetSubordinates(pId);

        if (subordinates is null || !subordinates.Any()) subordinates = new List<PositionAndEmployeesDto>();

        if (includeSubstitutions)
        {
            var substitutions = await _unitOfWork.SubstitutionsRepository.GetByDeputyPId(pId);

            foreach (var substitution in substitutions)
            {
                var substitutionSubordinates = await _unitOfWork.EmployeesRepository.GetSubordinates(substitution.EmployeePId);

                subordinates.AddRange(substitutionSubordinates);
            }
        }

        //исключаем дубли
        subordinates = subordinates.GroupBy(x => x.PId)
            .ToDictionary(x => x.Key, x => x.FirstOrDefault())
            .Select(x => x.Value)
            .ToList();

        return _mapper.Map<List<PositionAndEmployeesView>>(subordinates);
    }
}