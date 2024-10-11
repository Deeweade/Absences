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
        CreateMap<AbsenceQueryView, AbsenceQueryDto>().ReverseMap();
        CreateMap<VacationDaysView, VacationDaysDto>().ReverseMap();
        CreateMap<AbsenceStatusView, AbsenceStatusDto>().ReverseMap();
        CreateMap<AbsenceTypeView, AbsenceTypeDto>().ReverseMap();
        CreateMap<EmployeeStatusView, ProcessStageDto>().ReverseMap();
        CreateMap<AbsenceView, AbsenceDto>().ReverseMap();
        CreateMap<CommentView, CommentDto>().ReverseMap();
        CreateMap<StatusView, ProcessStageDto>().ReverseMap();
    }
}
