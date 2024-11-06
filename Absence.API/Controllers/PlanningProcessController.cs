using Absence.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Absence.API.Controllers;

[ApiController]
[Route("api/[controller]")]
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