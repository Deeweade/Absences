using Absence.Application.Interfaces.Services;
using Absence.Application.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace Absence.API.Contorllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SustitutionsController : ControllerBase
    {
        private readonly ISubstitutionsService _service;

        public SustitutionsController(ISubstitutionsService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(SubstitutionView view)
        {
            ArgumentNullException.ThrowIfNull(view);

            var substitute = await _service.Create(view);

            return Ok(substitute);
        }
    }
}