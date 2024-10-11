using Absence.Domain.Dtos.Entities;
using Absence.Domain.Models.Entities;
using AutoMapper;

namespace Absence.Infrastructure.Models.Mappings;

public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
    {
        CreateMap<Absence.Domain.Models.Entities.Absence, AbsenceDto>().ReverseMap();
        CreateMap<PlanningProcess, PlanningProcessDto>().ReverseMap();
        CreateMap<EmployeeStage, EmployeeStageDto>().ReverseMap();
        CreateMap<AbsenceStatus, AbsenceStatusDto>().ReverseMap();
        CreateMap<ProcessStage, ProcessStageDto>().ReverseMap();
        CreateMap<VacationDays, VacationDaysDto>().ReverseMap();
        CreateMap<AbsenceType, AbsenceTypeDto>().ReverseMap();
        CreateMap<Comment, CommentDto>().ReverseMap();

    }
}
