using Vacations.Domain.Models.Entities;
using Vacations.Domain.Dtos.Entities;
using AutoMapper;

namespace Vacations.Infrastructure.Models.Mappings;

public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
    {
        CreateMap<PlanningProcess, PlanningProcessDto>().ReverseMap();
        CreateMap<EmployeeStatus, EmployeeStatusDto>().ReverseMap();
        CreateMap<EntityStatus, EntityStatusDto>().ReverseMap();
        CreateMap<VacationDays, VacationDaysDto>().ReverseMap();
        CreateMap<AbsenceType, AbsenceTypeDto>().ReverseMap();
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<Absence, AbsenceDto>().ReverseMap();
        CreateMap<Status, StatusDto>().ReverseMap();

    }
}
