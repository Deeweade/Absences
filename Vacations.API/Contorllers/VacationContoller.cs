using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacations.Application.Interfaces.Services;
using Vacations.Application.Models.Queries;
using Vacations.Application.Models.Views;

namespace Vacations.API.Contorllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "RequireAuthenticatedUser")]

public class VacationContoller : ControllerBase
{
    private readonly IVacationService _service;

    public VacationContoller(IVacationService service)
    {
        _service = service;
    }

    [HttpPost("filter")]
    public async Task<IActionResult> GetByFilter(VacationQueryView query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var vacations = await _service.GetByQuery(query);

        return Ok(vacations);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(VacationView vacationView)
    {
        ArgumentNullException.ThrowIfNull(vacationView);

        var vacation = await _service.Create(vacationView);

        return Ok(vacation);
    }
    
    [HttpPost("update/{vacationId}/{planningStatusId}")]
    public async Task<IActionResult> Update(int vacationId, VacationView vacationView, int planningStatusId)
    {
        ArgumentNullException.ThrowIfNull(vacationView);
        
        if (vacationId != vacationView.Id)
        {
            return BadRequest();
        }

        var vacation = await _service.Update(vacationView, planningStatusId);

        return Ok(vacation);
    }
} 