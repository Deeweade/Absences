using Absence.Application.Interfaces.Services;
using Absence.Application.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace Absence.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacationDaysController : ControllerBase
    {
        private readonly IVacationDaysService _service;

        public VacationDaysController(IVacationDaysService service)
        {
            _service = service;
        }

        [HttpGet("availableDaysNumber/{pId}/{year}")]
        public async Task<VacationDaysView> GetAvailableDaysNumber(string pId, int year)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(pId);

            return await _service.GetAvailableDaysNumber(pId, year);
        }
    }
}