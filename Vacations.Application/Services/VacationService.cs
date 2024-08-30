using AutoMapper;
using Vacations.Application.Interfaces.Services;
using Vacations.Application.Models.Queries;
using Vacations.Application.Models.Views;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Dtos.Queries;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Domain.Models.Enums;

namespace Vacations.Application.Services;

public class VacationService : IVacationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VacationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VacationView>> GetByQuery(VacationQueryView query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var queryDto = _mapper.Map<VacationQueryDto>(query);

        var vacations = await _unitOfWork.VacationRepository.GetByQuery(queryDto);

        return _mapper.Map<IEnumerable<VacationView>>(vacations);
    }

    public async Task<VacationView> Create(VacationView vacationView)
    {
        ArgumentNullException.ThrowIfNull(vacationView);

        var vacationDto = _mapper.Map<VacationDto>(vacationView);

        var vacation = await _unitOfWork.VacationRepository.Create(vacationDto);

        return _mapper.Map<VacationView>(vacation);
    }

    public async Task<VacationView> Update(VacationView vacationView)
    {
        ArgumentNullException.ThrowIfNull(vacationView);

        var vacationDto = _mapper.Map<VacationDto>(vacationView);

        var vacation = await _unitOfWork.VacationRepository.GetById(vacationDto.Id);

        var lastStatus = await _unitOfWork.StatusRepository.GetLastStatus(vacationDto.EmployeeTabNumber);
        
        var newVacation = _unitOfWork.VacationRepository.Update(vacationDto);
        await _unitOfWork.SaveChangesAsync();

        if (vacationDto.EntityStatusId == vacation.EntityStatusId)
        {
            _unitOfWork.StatusRepository.CloseStatus(lastStatus);
            await _unitOfWork.SaveChangesAsync();
            
            lastStatus.PlanningStatusId = (int)PlanningStatuses.Planning;

            await _unitOfWork.StatusRepository.Create(lastStatus);
        }

        return _mapper.Map<VacationView>(newVacation);
    }
}