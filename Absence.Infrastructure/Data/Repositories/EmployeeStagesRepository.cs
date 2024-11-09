using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Models.Entities;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Dtos.Queries;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Absence.Infrastructure.Data.Repositories;

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

    public async Task<EmployeeStageDto> GetLast(string pId, int year)
    {
        return await _context.EmployeeStages
            .AsNoTracking()
            .ProjectTo<EmployeeStageDto>(_mapper.ConfigurationProvider)
            .Where(x => x.PId.Equals(pId)
                && x.Stage.Year == year)
            .OrderBy(x => x.Id)
            .LastOrDefaultAsync();
    }

    public async Task<List<EmployeeStageDto>> GetByQuery(EmployeeStagesQueryDto queryDto)
    {
        ArgumentNullException.ThrowIfNull(queryDto);

        var query = _context.EmployeeStages
            .AsNoTracking()
            .ProjectTo<EmployeeStageDto>(_mapper.ConfigurationProvider);

        if (queryDto.PIds.Count != 0)
        {
            query = query.Where(x => queryDto.PIds.Contains(x.PId));
        }

        if (queryDto.Year is not null)
        {
            query = query.Where(x => x.Stage.Year == queryDto.Year);
        }

        return await query.ToListAsync();
    }

    public async Task<EmployeeStageDto> Create(EmployeeStageDto status)
    {
        ArgumentNullException.ThrowIfNull(status);

        var newStatus = _mapper.Map<EmployeeStage>(status);

        _context.EmployeeStages.Add(newStatus);
        await _context.SaveChangesAsync();

        return await GetById(newStatus.Id);
    }

    public async Task<EmployeeStageDto> Update(EmployeeStageDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _context.EmployeeStages.FirstOrDefaultAsync(x => x.Id == dto.Id);

        entity.StageId = dto.StageId;

        var changes = _context.EmployeeStages.Update(entity);

        return _mapper.Map<EmployeeStageDto>(changes.Entity);
    }

    public async Task UpdateBulk(List<EmployeeStageDto> dtos)
    {
        ArgumentNullException.ThrowIfNull(dtos);

        var stagesIds = dtos.Select(x => x.Id).ToList();

        var entities = await _context.EmployeeStages
            .Where(x => stagesIds.Contains(x.Id))
            .ToListAsync();

        if (!entities.Any()) throw new Exception("No matching EmployeeStages found in the database.");

        foreach (var entity in entities)
        {
            var dto = dtos.First(x => x.Id == entity.Id);
            
            entity.StageId = dto.StageId;
        }
    }
}