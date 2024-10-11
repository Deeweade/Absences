using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Views;
using AutoMapper;

namespace Absence.Application.Services;

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