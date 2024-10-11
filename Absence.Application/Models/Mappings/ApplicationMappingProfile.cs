using Vacations.Application.Models.Queries;
using Vacations.Application.Models.Views;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Dtos.Queries;
using AutoMapper;

namespace Vacations.Application.Models.Mappings;

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
