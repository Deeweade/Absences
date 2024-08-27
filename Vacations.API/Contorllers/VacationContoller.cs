using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacations.Application.Interfaces.Services;
using Vacations.Application.Models.Views;

namespace Vacations.API.Contorllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]

public class VacationContoller(IVacationService service) : ControllerBase
{
    private readonly IVacationService _service = service;

    [HttpPost("create")]
    public async Task<IActionResult> Create(VacationView vacationView)
    {
        ArgumentNullException.ThrowIfNull(vacationView);

        var vacation = await _service.Create(vacationView);

        return Ok(vacation);
    }
} 