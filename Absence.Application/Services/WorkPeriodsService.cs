using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Views;
using AutoMapper;

namespace Absence.Application.Services;

public class WorkPeriodsService : IWorkPeriodsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WorkPeriodsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<WorkPeriodView>> GetAll()
    {
        var workPeriods = await _unitOfWork.WorkPeriodsRepository.GetAll();

        return _mapper.Map<List<WorkPeriodView>>(workPeriods);
    }
}
