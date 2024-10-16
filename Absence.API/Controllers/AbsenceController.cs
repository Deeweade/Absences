using Absence.Application.Interfaces.Services;
using Absence.Application.Models.Actions;
using Absence.Application.Models.Queries;
using Absence.Application.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Absence.API.Contorllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]

public class AbsenceController : ControllerBase
{
    private readonly IAbsenceService _service;

    public AbsenceController(IAbsenceService service)
    {
        _service = service;
    }

    [HttpPost("filter")]
    public async Task<IActionResult> GetByFilter(AbsenceQueryView query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var vacations = await _service.GetByQuery(query);

        return Ok(vacations);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(AbsenceView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        var absence = await _service.Create(view);

        return Ok(absence);
    }
    
    [HttpPost("update/{absenceId}")]
    public async Task<IActionResult> Update(int absenceId, AbsenceView view)
    {
        ArgumentNullException.ThrowIfNull(view);
        
        if (absenceId != view.Id)
        {
            return BadRequest();
        }

        var absence = await _service.Update(view);

        return Ok(absence);
    }

    [HttpPost("changeStatuses/bulk")]
    public async Task<IActionResult> Update(UpdateAbsencesBulkView view)
    {
        ArgumentNullException.ThrowIfNull(view);

        await _service.ChangeStatusesBulk(view);

        return Ok();
    }

    [HttpPost("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(id, 1);

        await _service.Delete(id);

        return Ok();
    }
} 