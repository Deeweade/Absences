using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Actions;
using Absence.Application.Models.Views;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Models.Enums;
using Absence.Application.Helpers;
using AutoMapper;

namespace Absence.Application.Services;

public class SubstitutionsService : ISubstitutionsService
{
    private readonly INotificationSenderFacade _sender;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubstitutionsService(IUnitOfWork unitOfWork, IMapper mapper, 
        INotificationSenderFacade sender)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _sender = sender;
    }

    public async Task<SubstitutionView> Create(CreateSubstitutionView view)
    {
        ArgumentNullException.ThrowIfNull(view);
        
        try
        {
            view.DateStart = view.DateStart ?? DateTime.Now;
            view.DateEnd = view.DateEnd ?? DateTime.MaxValue;

            var dto = _mapper.Map<SubstitutionDto>(view);

            var existed = await _unitOfWork.SubstitutionsRepository.Get(dto.EmployeePId, dto.DeputyPId);

            if (existed is not null)
                ExceptionHelper.ThrowContextualException<InvalidOperationException>(ExceptionalEvents.SubstitutionExists);

            dto = await _unitOfWork.SubstitutionsRepository.Create(dto);

            await _sender.Send_SubstitutionAdded(dto);

            return _mapper.Map<SubstitutionView>(dto);
        }
        catch
        {
            throw;
        }
    }
}