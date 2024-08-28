using AutoMapper;
using Vacations.Application.Interfaces.Services;
using Vacations.Application.Models.Views;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Interfaces.Repositories;

namespace Vacations.Application.Services;

public class StatusService : IStatusService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StatusService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<StatusView> ChangeStatus(int id, StatusView status)
    {
        ArgumentNullException.ThrowIfNull(status);

        var statusDto = _mapper.Map<StatusDto>(status);

        var currentStatus = await _unitOfWork.StatusRepository.GetActiveById(id);

        await _unitOfWork.StatusRepository.DeactivateStatus(currentStatus);
        await _unitOfWork.SaveChangesAsync();

        currentStatus.PlanningStatusId = statusDto.PlanningStatusId;
        
        var changedStatus = await _unitOfWork.StatusRepository.Create(currentStatus);
        await _unitOfWork.SaveChangesAsync();

        if (currentStatus.EmployeeTabNumber != changedStatus.EmployeeTabNumber && currentStatus.Year != changedStatus.Year)
        {
            return _mapper.Map<StatusView>(currentStatus);
        }

        return _mapper.Map<StatusView>(changedStatus);
    }
}