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

    [HttpPost("changeStatus/{statusId}")]
    public async Task<IActionResult> ChangeStatus(int statusId, [FromBody] StatusView statusView)
    {
        //var statusId = (int)HttpContext.Request.RouteValues[$"{statusView.Id}"];

        if (statusId != statusView.Id)
        {
            return BadRequest();
        }

        var status = await _service.ChangeStatus(statusView);
        
        return Ok(status);
    }
}