using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacations.Application.Interfaces.Services;
using Vacations.Application.Models.Filters;
using Vacations.Application.Models.Views;

namespace Vacations.API.Contorllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]

public class VacationContoller(IVacationService service) : ControllerBase
{
    private readonly IVacationService _service = service;

    [HttpPost("plannedVacationFilter")]
    public async Task<IActionResult> GetPlannedVacations(VacationFilterView filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        var vacations = await _service.GetByFilter(filter);

        return Ok(vacations);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(VacationView vacationView)
    {
        ArgumentNullException.ThrowIfNull(vacationView);

        var vacation = await _service.Create(vacationView);

        return Ok(vacation);
    }
} 