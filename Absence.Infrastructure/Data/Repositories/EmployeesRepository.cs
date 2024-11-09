using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Absence.Domain.Dtos.Queries;
using System.Linq.Expressions;

namespace Absence.Infrastructure.Data.Repositories;

public class EmployeesRepository : IEmployeesRepository
{
    private readonly AbsenceDbContext _context;
    private readonly IMapper _mapper;

    public EmployeesRepository(AbsenceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PositionAndEmployeesDto> GetByPId(string pId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(pId);

        return await _context.PositionAndEmployees
            .AsNoTracking()
            .ProjectTo<PositionAndEmployeesDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.PId.Equals(pId));
    }

    public async Task<PositionAndEmployeesDto> GetByLogin(string login)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(login);

        return await _context.PositionAndEmployees
            .AsNoTracking()
            .ProjectTo<PositionAndEmployeesDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Mail.Contains(login));
    }

    public async Task<List<PositionAndEmployeesDto>> GetSubordinates(string managerPId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(managerPId);

        return await _context.PositionAndEmployees
            .AsNoTracking()
            .ProjectTo<PositionAndEmployeesDto>(_mapper.ConfigurationProvider)
            .Where(x => x.ManagerPId.Equals(managerPId)
                && !string.IsNullOrEmpty(x.PId)
                && !x.PGroupName.Equals("Декрет"))
            .ToListAsync();
    }

    public async Task<List<TResult>> GetByQuery<TResult>(EmployeesQueryDto queryDto, Expression<Func<PositionAndEmployeesDto, TResult>> select = null)
    {
        ArgumentNullException.ThrowIfNull(queryDto);

        var query = _context.PositionAndEmployees
            .AsNoTracking()
            .ProjectTo<PositionAndEmployeesDto>(_mapper.ConfigurationProvider);

        if (queryDto.PIds is not null && queryDto.PIds.Any())
        {
            query = query.Where(x => queryDto.PIds.Contains(x.PId));
        }

        if (select is not null)
        {
            return await query.Select(select).ToListAsync();
        }
        else
        {
            return await query.Cast<TResult>().ToListAsync();
        }
    }
}