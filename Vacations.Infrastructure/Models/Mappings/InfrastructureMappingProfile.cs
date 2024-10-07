using Vacations.Domain.Models.Entities;
using Vacations.Domain.Dtos.Entities;
using AutoMapper;

namespace Vacations.Infrastructure.Models.Mappings;

public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
    {
        CreateAvailableDaysMappings();
        CreateCommentMappings();
        CreateEntityStatusMappings();
        CreatePlanningProcessMappings();
        CreatePlanningStatusMappings();
        CreateStatusMappings();
        CreateVacationMappings();
        CreateVacationTypeMappings();
    }

    private void CreateAvailableDaysMappings()
    {
        CreateMap<VacationDays, VacationDaysDto>();
        CreateMap<VacationDaysDto, VacationDays>();
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

    public void CreatePlanningProcessMappings()
    {
        CreateMap<PlanningProcess, PlanningProcessDto>();
        CreateMap<PlanningProcessDto, PlanningProcess>();
    }

    private void CreatePlanningStatusMappings()
    {
        CreateMap<Status, StatusDto>();
        CreateMap<StatusDto, Status>();
    }

    private void CreateStatusMappings()
    {
        CreateMap<EmployeeStatus, EmployeeStatusDto>();
        CreateMap<EmployeeStatusDto, EmployeeStatus>();
    }

    private void CreateVacationMappings()
    {
        CreateMap<Absence, AbsenceDto>();
        CreateMap<AbsenceDto, Absence>();
    }

    private void CreateVacationTypeMappings()
    {
        CreateMap<AbsenceType, AbsenceTypeDto>();
        CreateMap<AbsenceTypeDto, AbsenceType>();
    }
}
