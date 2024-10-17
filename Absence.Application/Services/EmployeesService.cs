using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Views;
using AutoMapper;

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

    // public async Task<List<PositionAndEmployeesView>> GetPeers(string pId)
    // {
    //     ArgumentNullException.ThrowIfNullOrEmpty(pId);

    //     var employee = await _unitOfWork.EmployeesRepository.GetByPId(pId);

    //     // var peers = await _unitOfWork.EmployeesRepository.GetByOId(employee.OId);

    //     employee = peers.FirstOrDefault(x => x.PId == pId);

    //     peers.Remove(employee);

    //     return _mapper.Map<List<PositionAndEmployeesView>>(peers);
    // }
}