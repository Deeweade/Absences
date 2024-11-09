using Absence.Application.Interfaces.Services;
using Absence.Application.Models.Actions;
using Microsoft.AspNetCore.Mvc;

namespace Absence.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeStagesController : ControllerBase
    {
        private readonly IEmployeeStagesService _service;

        public EmployeeStagesController(IEmployeeStagesService service)
        {
            _service = service;
        }

        // [HttpPost("update/{pId}")]
        // public async Task<IActionResult> Update(string pId, [FromBody] UpdateEmployeeStageView view)
        // {
        //     ArgumentNullException.ThrowIfNullOrEmpty(pId);
        //     ArgumentNullException.ThrowIfNull(view);

        //     if (view.PId != pId)
        //     {
        //         return BadRequest();
        //     }

        //     var result = await _service.Update(view);

        //     return Ok(result);
        // }
    }
}