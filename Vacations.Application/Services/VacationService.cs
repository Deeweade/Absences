using AutoMapper;
using Vacations.Application.Interfaces.Services;
using Vacations.Application.Models.Filters;
using Vacations.Application.Models.Views;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Domain.Models.Filters;

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

    public async Task<VacationView> Create(VacationView vacationView)
    {
        ArgumentNullException.ThrowIfNull(vacationView);

        var vacationDto = _mapper.Map<VacationDto>(vacationView);

        var vacation = await _unitOfWork.VacationRepository.Create(vacationDto);

        return _mapper.Map<VacationView>(vacation);
    }
}