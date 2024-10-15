using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Views;
using Absence.Domain.Dtos.Entities;
using AutoMapper;

namespace Absence.Application.Services;

public class SubstitutionsService : ISubstitutionsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubstitutionsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SubstitutionView> Create(SubstitutionView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var dto = _mapper.Map<SubstitutionDto>(view);

        dto = await _unitOfWork.SubstitutionsRepository.Create(dto);

        return _mapper.Map<SubstitutionView>(dto);
    }
}