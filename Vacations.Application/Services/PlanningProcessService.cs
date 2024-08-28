using AutoMapper;
using Vacations.Application.Interfaces.Services;
using Vacations.Application.Models.Views;
using Vacations.Domain.Interfaces.Repositories;

namespace Vacations.Application.Services;

public class PlanningProcessService : IPlanningProcessService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PlanningProcessService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PlanningProcessView> GetActive()
    {
        var status = await _unitOfWork.PlanningProcessRepository.GetActive();

        return _mapper.Map<PlanningProcessView>(status);
    }
}