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
        
        CreateMap<PlanningProcessView, PlanningProcessDto>().ReverseMap();
        CreateMap<EmployeeStatusView, ProcessStageDto>().ReverseMap();
        CreateMap<AbsenceStatusView, AbsenceStatusDto>().ReverseMap();
        CreateMap<AbsenceQueryView, AbsenceQueryDto>().ReverseMap();
        CreateMap<VacationDaysView, VacationDaysDto>().ReverseMap();
        CreateMap<SubstitutionView, SubstitutionDto>().ReverseMap();
        CreateMap<AbsenceTypeView, AbsenceTypeDto>().ReverseMap();
        CreateMap<StatusView, ProcessStageDto>().ReverseMap();
        CreateMap<AbsenceView, AbsenceDto>().ReverseMap();
        CreateMap<CommentView, CommentDto>().ReverseMap();
    }
}