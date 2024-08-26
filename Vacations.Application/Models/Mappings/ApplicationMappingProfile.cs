using AutoMapper;
using Vacations.Application.Models.Views;
using Vacations.Domain.Dtos.Entities;

namespace Vacations.Application.Models.Mappings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateAvailableDaysMappings();
        CreateCommentMappings();
        CreateEntityStatusMappings();
        CreatePlanningStatusMappings();
        CreateStatusMappings();
        CreateVacationMappings();
        CreateVacationTypeMappings();
    }

    private void CreateAvailableDaysMappings()
    {
        CreateMap<AvailableDaysView, AvailableDaysDto>();
        CreateMap<AvailableDaysDto, AvailableDaysView>();
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

    private void CreatePlanningStatusMappings()
    {
        CreateMap<PlanningStatusView, PlanningStatusDto>();
        CreateMap<PlanningStatusDto, PlanningStatusView>();
    }

    private void CreateStatusMappings()
    {
        CreateMap<StatusView, StatusDto>();
        CreateMap<StatusDto, StatusView>();
    }

    private void CreateVacationMappings()
    {
        CreateMap<VacationView, VacationDto>();
        CreateMap<VacationDto, VacationView>();
    }
    private void CreateVacationTypeMappings()
    {
        CreateMap<VacationTypeView, VacationTypeDto>();
        CreateMap<VacationTypeDto, VacationTypeView>();
    }
}
