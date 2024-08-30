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

    public async Task<StatusView> ChangeStatus(StatusView status)
    {
        ArgumentNullException.ThrowIfNull(status);

        var statusDto = _mapper.Map<StatusDto>(status);

        var currentStatus = await _unitOfWork.StatusRepository.GetById(status.Id);

        if (currentStatus.EmployeeTabNumber != status.EmployeeTabNumber && currentStatus.Year != status.Year)
        {
            throw new InvalidOperationException();
        }   
            
        _unitOfWork.StatusRepository.DeactivateStatus(currentStatus);
        await _unitOfWork.SaveChangesAsync();

        var changedStatus = await _unitOfWork.StatusRepository.Create(statusDto);
    
        return _mapper.Map<StatusView>(changedStatus);
    }
}