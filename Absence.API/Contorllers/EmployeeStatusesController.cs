using Vacations.Application.Interfaces.Services;
using Vacations.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vacations.API.Contorllers;

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

    [HttpPost("changeStatus/{statusId}")]
    public async Task<IActionResult> ChangeStatus(int statusId, [FromBody] EmployeeStatusView statusView)
    {
        if (statusId != statusView.Id)
        {
            return BadRequest();
        }

        var status = await _service.ChangeStatus(statusView);
        
        return Ok(status);
    }
}