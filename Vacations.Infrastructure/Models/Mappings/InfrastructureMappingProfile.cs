using AutoMapper;
using Vacations.Domain.Dtos.Entities;
using Vacations.Domain.Models.Entities;
using Vacations.Domain.Models.Filters;

namespace Vacations.Infrastructure.Models.Mappings;

public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
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
        CreateMap<AvailableDays, AvailableDaysDto>();
        CreateMap<AvailableDaysDto, AvailableDays>();
    }

    private void CreateCommentMappings()
    {
        CreateMap<Comment, CommentDto>();
        CreateMap<CommentDto, Comment>();
    }

    private void CreateEntityStatusMappings()
    {
        CreateMap<EntityStatus, EntityStatusDto>();
        CreateMap<EntityStatusDto, EntityStatus>();
    }

    private void CreatePlanningStatusMappings()
    {
        CreateMap<PlanningStatus, PlanningStatusDto>();
        CreateMap<PlanningStatusDto, PlanningStatus>();
    }

    private void CreateStatusMappings()
    {
        CreateMap<Status, StatusDto>();
        CreateMap<StatusDto, Status>();
    }

    private void CreateVacationMappings()
    {
        CreateMap<Vacation, VacationDto>();
        CreateMap<VacationDto, Vacation>();
    }

    private void CreateVacationTypeMappings()
    {
        CreateMap<VacationType, VacationTypeDto>();
        CreateMap<VacationTypeDto, VacationType>();
    }
}
