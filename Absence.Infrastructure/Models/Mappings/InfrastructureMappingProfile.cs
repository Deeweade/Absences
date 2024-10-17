using Absence.Domain.Models.Entities;
using Absence.Domain.Dtos.Entities;
using AutoMapper;

namespace Absence.Infrastructure.Models.Mappings;

public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
    {
        CreateMap<PositionAndEmployees, PositionAndEmployeesDto>().ReverseMap();
        CreateMap<PlanningProcess, PlanningProcessDto>().ReverseMap();
        CreateMap<EmployeeStage, EmployeeStageDto>().ReverseMap();
        CreateMap<AbsenceStatus, AbsenceStatusDto>().ReverseMap();
        CreateMap<SystemProcess, SystemProcessDto>().ReverseMap();
        CreateMap<ProcessStage, ProcessStageDto>().ReverseMap();
        CreateMap<VacationDays, VacationDaysDto>().ReverseMap();
        CreateMap<Substitution, SubstitutionDto>().ReverseMap();
        CreateMap<AbsenceType, AbsenceTypeDto>().ReverseMap();
        CreateMap<Comment, CommentDto>().ReverseMap();

        CreateMap<Domain.Models.Entities.Absence, AbsenceDto>()
            .ForMember(dest => dest.AbsenceStatus, opt => opt.MapFrom(src => src.AbsenceStatus))
            .ForMember(dest => dest.AbsenceType, opt => opt.MapFrom(src => src.AbsenceType));

        CreateMap<AbsenceDto, Domain.Models.Entities.Absence>()
            .ForMember(dest => dest.AbsenceStatus, opt => opt.Ignore())
            .ForMember(dest => dest.AbsenceType, opt => opt.Ignore());

        CreateMap<ProcessStage, ProcessStageDto>()
            .ForMember(dest => dest.Process, opt => opt.MapFrom(src => src.Process));
    }
}