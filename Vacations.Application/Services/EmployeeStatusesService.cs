using Vacations.Application.Interfaces.Services;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Application.Models.Views;
using Vacations.Domain.Dtos.Entities;
using AutoMapper;

namespace Vacations.Application.Services;

public class EmployeeStatusesService : IEmployeeStatusesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeStatusesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EmployeeStatusView> ChangeStatus(EmployeeStatusView status)
    {
        ArgumentNullException.ThrowIfNull(status);

        var statusDto = _mapper.Map<EmployeeStatusDto>(status);

        var currentStatus = await _unitOfWork.EmployeeStatusesRepository.GetById(status.Id);

        if (currentStatus.PId != status.PId && currentStatus.Year != status.Year)
        {
            throw new InvalidOperationException();
        }   
            
        _unitOfWork.EmployeeStatusesRepository.DeactivateStatus(currentStatus);
        await _unitOfWork.SaveChangesAsync();

        var changedStatus = await _unitOfWork.EmployeeStatusesRepository.Create(statusDto);
    
        return _mapper.Map<EmployeeStatusView>(changedStatus);
    }
}