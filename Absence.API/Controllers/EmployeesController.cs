using Absence.Application.Interfaces.Services;
using Absence.Application.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace Absence.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _service;

        public EmployeesController(IEmployeesService service)
        {
            _service = service;
        }

        [HttpGet("byLogin/{login}")]
        public async Task<PositionAndEmployeesView> GetByLogin(string login)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(login);

            return await _service.GetByLogin(login);
        }

        [HttpGet("peers/{pId}")]
        public async Task<List<PositionAndEmployeesView>> GetPeers(string pId)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(pId);

            return await _service.GetPeers(pId);
        }

        [HttpGet("subordinates/{pId}/{includeSubstitutions}")]
        public async Task<List<PositionAndEmployeesView>> GetSubordinates(string pId, bool includeSubstitutions)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(pId);

            return await _service.GetSubordinates(pId, includeSubstitutions);
        }

        [HttpGet("manager/{pId}")]
        public async Task<PositionAndEmployeesView> GetManager(string pId)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(pId);

            return await _service.GetManager(pId);
        }
    }
}