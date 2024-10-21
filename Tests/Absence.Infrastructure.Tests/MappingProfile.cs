using Absence.Domain.Models.Entities;
using Absence.Domain.Dtos.Entities;
using AutoMapper;

namespace Absence.Infrastructure.Tests;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<VacationDays, VacationDaysDto>().ReverseMap();
    }
}
