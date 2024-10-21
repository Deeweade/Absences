using Absence.Application.Models.Views;
using Absence.Domain.Dtos.Entities;
using AutoMapper;

namespace Absence.Application.Tests;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<VacationDaysView, VacationDaysDto>().ReverseMap();
    }
}