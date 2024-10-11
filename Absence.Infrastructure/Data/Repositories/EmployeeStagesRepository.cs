using Vacations.Domain.Interfaces.Repositories;
using Vacations.Infrastructure.Data.Contexts;
using Vacations.Domain.Dtos.Entities;
using Absence.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Vacations.Infrastructure.Data.Repositories;

public class EmployeeStagesRepository : IEmployeeStagesRepository
{
    private readonly AbsenceDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeStagesRepository(AbsenceDbContext vacationsDbContext, IMapper mapper)
    {
        _context = vacationsDbContext;
        _mapper = mapper;
    }

    public async Task<EmployeeStageDto> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        return await _context.EmployeeStages
            .AsNoTracking()
            .ProjectTo<EmployeeStageDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<EmployeeStageDto> GetLastStage(string pId, int year)
    {
        return await _context.EmployeeStages
            .AsNoTracking()
            .ProjectTo<EmployeeStageDto>(_mapper.ConfigurationProvider)
            .Where(x => x.PId.Equals(pId)
                && x.Stage.Year == year)
            .OrderBy(x => x.Id)
            .LastOrDefaultAsync();
    }

    public async Task<EmployeeStageDto> Create(EmployeeStageDto status)
    {
        ArgumentNullException.ThrowIfNull(status);

        var newStatus = _mapper.Map<EmployeeStage>(status);

        _context.EmployeeStages.Add(newStatus);
        await _context.SaveChangesAsync();

        return await GetById(newStatus.Id);
    }

    public void DeactivateStatus(EmployeeStageDto status)
    {
        var newStatus = _mapper.Map<EmployeeStage>(status);

        _context.EmployeeStages.Update(newStatus);
    }

    public EmployeeStageDto Update(EmployeeStageDto status)
    {
        var entity = _mapper.Map<EmployeeStage>(status);

        var newStatus = _context.EmployeeStages.Update(entity);

        return _mapper.Map<EmployeeStageDto>(newStatus);
    }

    public EmployeeStageDto CloseStatus(EmployeeStageDto status)
    {
        var newStatus = Update(status);

        return newStatus;
    }
}