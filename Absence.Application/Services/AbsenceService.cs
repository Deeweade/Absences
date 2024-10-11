using Absence.Application.Interfaces.Services;
using Absence.Domain.Interfaces.Repositories;
using Absence.Application.Models.Actions;
using Absence.Application.Models.Queries;
using Absence.Application.Models.Views;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Dtos.Queries;
using AutoMapper;

namespace Absence.Application.Services;

public class AbsenceService : IAbsenceService
{
    private readonly IEmployeeStagesService _employeeStagesService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AbsenceService(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeStagesService employeeStagesService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _employeeStagesService = employeeStagesService;
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

        using (var transaction = await _unitOfWork.BeginTransactionAsync())
        {
            try
            {
                dto = await _unitOfWork.AbsencesRepository.Create(dto);

                //проставляем этап сотруднику
                await _employeeStagesService.CreateOrSetFirstStatus(dto.PId, dto.DateStart.Date.Year);

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        return _mapper.Map<AbsenceView>(dto);
    }

    public async Task ChangeStatusesBulk(ChangeStatusesBulkView view)
    {
        ArgumentNullException.ThrowIfNull(view);
    }
    
    public async Task<AbsenceView> Update(AbsenceView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var dto = _mapper.Map<AbsenceDto>(view);

        using (var transaction = await _unitOfWork.BeginTransactionAsync())
        {
            try
            {
                var absence = await _unitOfWork.AbsencesRepository.GetById(dto.Id);
                
                dto = _unitOfWork.AbsencesRepository.Update(dto);

                //проставляем этап сотруднику
                await _employeeStagesService.CreateOrSetFirstStatus(dto.PId, dto.DateStart.Date.Year);

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        return _mapper.Map<AbsenceView>(dto);
    }
}