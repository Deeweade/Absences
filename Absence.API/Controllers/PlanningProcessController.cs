using Absence.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Absence.API.Contorllers;

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