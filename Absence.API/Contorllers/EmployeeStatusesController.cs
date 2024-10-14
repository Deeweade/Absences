using Absence.Application.Interfaces.Services;
using Absence.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Absence.API.Contorllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]

public class EmployeeStatusesController : ControllerBase
{
    private readonly IEmployeeStagesService _service;

    public EmployeeStatusesController(IEmployeeStagesService service)
    {
        _service = service;
    }
}