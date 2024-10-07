using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacations.Application.Interfaces.Services;

namespace Vacations.API.Contorllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]

public class PlanningProcessController : ControllerBase
{
    private readonly IPlanningProcessService _service;

    public PlanningProcessController(IPlanningProcessService service)
    {
        _service = service;
    }

    [HttpGet("getActive")]
    public async Task<IActionResult> GetActive()
    {
        var planningProcess = await _service.GetActive();

        return Ok(planningProcess);
    }
}