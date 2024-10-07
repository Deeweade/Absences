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
        CreateAvailableDaysMappings();
        CreateCommentMappings();
        CreateEntityStatusMappings();
        CreatePlanningProcessMappings();
        CreatePlanningStatusMappings();
        CreateStatusMappings();
        CreateVacationMappings();
        CreateVacationTypeMappings();
        CreateVacationFilterMappings();
    }

    private void CreateAvailableDaysMappings()
    {
        CreateMap<VacationDaysView, VacationDaysDto>();
        CreateMap<VacationDaysDto, VacationDaysView>();
    }

    private void CreateCommentMappings()
    {
        CreateMap<CommentView, CommentDto>();
        CreateMap<CommentDto, CommentView>();
    }

    private void CreateEntityStatusMappings()
    {
        CreateMap<EntityStatusView, EntityStatusDto>();
        CreateMap<EntityStatusDto, EntityStatusView>();
    }

    private void CreatePlanningProcessMappings()
    {
        CreateMap<PlanningProcessView, PlanningProcessDto>();
        CreateMap<PlanningProcessDto, PlanningProcessView>();
    }

    private void CreatePlanningStatusMappings()
    {
        CreateMap<StatusView, StatusDto>();
        CreateMap<StatusDto, StatusView>();
    }

    private void CreateStatusMappings()
    {
        CreateMap<EmployeeStatusView, StatusDto>();
        CreateMap<StatusDto, EmployeeStatusView>();
    }

    private void CreateVacationMappings()
    {
        CreateMap<AbsenceView, AbsenceDto>();
        CreateMap<AbsenceDto, AbsenceView>();
    }
    private void CreateVacationTypeMappings()
    {
        CreateMap<AbsenceTypeView, AbsenceTypeDto>();
        CreateMap<AbsenceTypeDto, AbsenceTypeView>();
    }

    private void CreateVacationFilterMappings()
    {
        CreateMap<AbsenceQueryView, AbsenceQueryDto>();
        CreateMap<AbsenceQueryDto, AbsenceQueryView>();
    }
}
