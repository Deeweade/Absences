using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Dtos.Queries;
using Absence.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Absence.Infrastructure.Data.Repositories;

public class AbsenceRepository : IAbsenceRepository
{
    private readonly AbsenceDbContext _context;
    private readonly IMapper _mapper;

    public AbsenceRepository(AbsenceDbContext vacationsDbContext, IMapper mapper)
    {
        _context = vacationsDbContext;
        _mapper = mapper;
    }

    public async Task<AbsenceDto> GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        return await _context.Absences
                .AsNoTracking()
                .ProjectTo<AbsenceDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> GetVacationDaysSum(string pId, int year)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(pId);
        ArgumentOutOfRangeException.ThrowIfLessThan(year, 2024);

        var absences = await _context.Absences
            .AsNoTracking()
            .Where(x => x.PId.Equals(pId)
                && x.DateStart.Year == year
                && (x.AbsenceTypeId == "0101"
                || x.AbsenceTypeId == "0105"))
            .ToListAsync();

        return absences
            .Select(x => (x.DateEnd - x.DateStart).Days)
            .Sum();
    }

    public async Task<List<AbsenceDto>> GetByQuery(AbsenceQueryDto queryDto)
    {
        ArgumentNullException.ThrowIfNull(queryDto);

        var query = _context.Absences
            .AsNoTracking()
            .ProjectTo<AbsenceDto>(_mapper.ConfigurationProvider);

        if (queryDto.Ids is not null && queryDto.Ids.Any())
        {
            query = query.Where(x => queryDto.Ids.Contains(x.Id));
        }

        if (queryDto.Years.Count != 0 && !queryDto.Years.Contains(0))
        {
            query = query.Where(x => queryDto.Years.Contains(x.DateStart.Year));
        }

        if (queryDto.AbsenceStatuses.Count != 0 && !queryDto.AbsenceStatuses.Contains(0))
        {
            query = query.Where(x => queryDto.AbsenceStatuses.Contains(x.AbsenceStatusId));
        }

        if (queryDto.PIds.Count != 0)
        {
            query = query.Where(x => queryDto.PIds.Contains(x.PId));
        }

        var result = await query.ToListAsync();

        return result;
    } 
    
    public async Task<AbsenceDto> Create(AbsenceDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        dto.AbsenceStatusId = (int)AbsenceStatuses.ActiveDraft;

        var absence = _mapper.Map<Domain.Models.Entities.Absence>(dto);

        _context.Absences.Add(absence);
        await _context.SaveChangesAsync();

        return await GetById(absence.Id);
    }

    public async Task<List<AbsenceDto>> CreateBulk(List<AbsenceDto> dtos)
    {
        ArgumentNullException.ThrowIfNull(dtos);

        var absences = _mapper.Map<List<Domain.Models.Entities.Absence>>(dtos);

        foreach (var absence in absences)
        {
            absence.AbsenceStatusId = (int)AbsenceStatuses.ActiveDraft;
        }

        _context.Absences.AddRange(absences);
        await _context.SaveChangesAsync();

        return _mapper.Map<List<AbsenceDto>>(absences);
    }

    public async Task<AbsenceDto> Update(AbsenceDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var entity = await _context.Absences.FirstOrDefaultAsync(x => x.Id == dto.Id);

        entity.DateStart = dto.DateStart;
        entity.DateEnd = dto.DateEnd;
        entity.ParentAbsenceId = dto.ParentAbsenceId;
        entity.AbsenceTypeId = dto.AbsenceTypeId;
        entity.AbsenceStatusId = dto.AbsenceStatusId;

        var changes = _context.Absences.Update(entity);

        return _mapper.Map<AbsenceDto>(changes.Entity);
    }


    public void UpdateBulk(List<AbsenceDto> dtos)
    {
        ArgumentNullException.ThrowIfNull(dtos);

        var absences = _mapper.Map<List<Domain.Models.Entities.Absence>>(dtos);

        _context.Absences.UpdateRange(absences);
    }

    public async Task Delete(int id)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(id, 1);

        var absence = await _context.Absences.FirstOrDefaultAsync(x => x.Id == id);

        _context.Absences.Remove(absence);
    }
}