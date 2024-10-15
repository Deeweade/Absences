using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Domain.Dtos.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

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

    public async Task<PositionAndEmployeesDto> GetByLogin(string login)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(login);

        throw new Exception();

        // return await _context.PositionAndEmployees
        //     .AsNoTracking()
        //     .ProjectTo<PositionAndEmployeesDto>(_mapper.ConfigurationProvider)
        //     .FirstOrDefaultAsync(x => x.PId.Equals("00118463"));
    }
}