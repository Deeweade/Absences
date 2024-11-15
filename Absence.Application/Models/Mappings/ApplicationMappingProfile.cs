using Absence.Application.Models.Queries;
using Absence.Application.Models.Views;
using Absence.Domain.Dtos.Entities;
using Absence.Domain.Dtos.Queries;
using AutoMapper;

namespace Absence.Application.Models.Mappings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<PositionAndEmployeesView, PositionAndEmployeesDto>().ReverseMap();
        CreateMap<PlanningProcessView, PlanningProcessDto>().ReverseMap();
        CreateMap<AbsenceStatusView, AbsenceStatusDto>().ReverseMap();
        CreateMap<EmployeeStageView, ProcessStageDto>().ReverseMap();
        CreateMap<SystemProcessView, ProcessStageDto>().ReverseMap();
        CreateMap<AbsenceQueryView, AbsenceQueryDto>().ReverseMap();
        CreateMap<SubstitutionView, SubstitutionDto>().ReverseMap();
        CreateMap<AbsenceTypeView, AbsenceTypeDto>().ReverseMap();
        CreateMap<WorkdayTypeView, WorkdayTypeDto>().ReverseMap();
        CreateMap<AbsenceView, AbsenceDto>().ReverseMap();
        CreateMap<CommentView, CommentDto>().ReverseMap();

        CreateMap<WorkPeriodView, WorkPeriodDto>()
            .ForMember(dest => dest.WorkdayType, opt => opt.MapFrom(src => src.WorkdayType))
            .ReverseMap();

        CreateMap<AbsenceView, AbsenceDto>()
            .ForMember(dest => dest.AbsenceStatus, opt => opt.MapFrom(src => src.AbsenceStatus))
            .ForMember(dest => dest.AbsenceType, opt => opt.MapFrom(src => src.AbsenceType));

        CreateMap<AbsenceDto, AbsenceView>()
            .ForMember(dest => dest.AbsenceStatus, opt => opt.Ignore())
            .ForMember(dest => dest.AbsenceType, opt => opt.Ignore());

        CreateMap<VacationDaysDto, VacationDaysView>()
            .ForMember(dest => dest.AbsenceType, opt => opt.MapFrom(src => src.AbsenceType));
    }
}