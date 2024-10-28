using Absence.Application.Interfaces.Services;
using Absence.Application.Models.Actions;
using Microsoft.AspNetCore.Mvc;

namespace Absence.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SustitutionsController : ControllerBase
    {
        private readonly ISubstitutionsService _service;

        public SustitutionsController(ISubstitutionsService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateSubstitutionView view)
        {
            ArgumentNullException.ThrowIfNull(view);

            var substitute = await _service.Create(view);

            return Ok(substitute);
        }
    }
}