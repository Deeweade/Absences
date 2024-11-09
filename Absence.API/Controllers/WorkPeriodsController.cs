using Absence.Application.Interfaces.Services;
using Absence.Application.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace Absence.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkPeriodsController : ControllerBase
    {
        private readonly IWorkPeriodsService _service;

        public WorkPeriodsController(IWorkPeriodsService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<List<WorkPeriodView>> GetAll()
        {
            return await _service.GetAll();
        }
    }
}