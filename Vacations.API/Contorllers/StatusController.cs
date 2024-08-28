using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacations.Application.Interfaces.Services;
using Vacations.Application.Models.Views;

namespace Vacations.API.Contorllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]

public class StatusController : ControllerBase
{
    private readonly IStatusService _service;

    public StatusController(IStatusService service)
    {
        _service = service;
    }

    [HttpPost("changeStatus")]
    public async Task<IActionResult> ChangeStatus([FromBody] StatusView statusView)
    {
        var id = HttpContext.Request.RouteValues["id"];

        if ((int)id == statusView.Id)
        {
            var status = await _service.ChangeStatus(statusView);
            
            return Ok(status);
        }

        return null;
    }
}