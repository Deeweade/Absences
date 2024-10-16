using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Views;
using AutoMapper;

namespace Absence.Application.Services;

public class VacationDaysService : IVacationDaysService
{
    private readonly IVacationDaysRepository _repository;
    private readonly IMapper _mapper;

    public VacationDaysService(IVacationDaysRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<VacationDaysView>> GetAvailableDaysNumber(string pId, int year)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(pId);

        var days = await _repository.GetAvailableDays(pId, year, true);

        return _mapper.Map<List<VacationDaysView>>(days);
    }
}