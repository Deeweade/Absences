using Vacations.Application.Interfaces.Services;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Application.Models.Queries;
using Vacations.Application.Models.Views;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Models.Enums;
using Vacations.Domain.Dtos.Queries;
using AutoMapper;

namespace Vacations.Application.Services;

public class AbsenceService : IAbsenceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AbsenceService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AbsenceView>> GetByQuery(AbsenceQueryView query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var queryDto = _mapper.Map<AbsenceQueryDto>(query);

        var absences = await _unitOfWork.AbsencesRepository.GetByQuery(queryDto);

        return _mapper.Map<IEnumerable<AbsenceView>>(absences);
    }

    public async Task<AbsenceView> Create(AbsenceView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var dto = _mapper.Map<AbsenceDto>(view);

        var absence = await _unitOfWork.AbsencesRepository.Create(dto);

        return _mapper.Map<AbsenceView>(absence);
    }

    public async Task<AbsenceView> Update(AbsenceView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var dto = _mapper.Map<AbsenceDto>(view);

        var absence = await _unitOfWork.AbsencesRepository.GetById(dto.Id);

        var lastStatus = await _unitOfWork.EmployeeStatusesRepository.GetLastStatus(dto.PId);
        
        var newAbsence = _unitOfWork.AbsencesRepository.Update(dto);
        await _unitOfWork.SaveChangesAsync();

        if (dto.AbsenceStatusId == absence.AbsenceStatusId)
        {
            _unitOfWork.EmployeeStatusesRepository.CloseStatus(lastStatus);
            await _unitOfWork.SaveChangesAsync();
            
            lastStatus.StatusId = (int)PlanningStatuses.Planning;

            await _unitOfWork.EmployeeStatusesRepository.Create(lastStatus);
        }

        return _mapper.Map<AbsenceView>(newAbsence);
    }
}