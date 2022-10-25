using LawEnforcement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LawEnforcement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawEnforcementController : ControllerBase
    {
        private readonly ILawEnforcementTeamService _lawEnforcementTeamService;

        public LawEnforcementController(ILawEnforcementTeamService lawEnforcementTeamService)
        {
            _lawEnforcementTeamService = lawEnforcementTeamService;
        }

        [HttpPost("crimeId")]
        public async Task<IActionResult> AssignCrimeToEnforcementTeam([FromQuery] Guid crimeId)
        {
            await _lawEnforcementTeamService.AssignCrimeEventToEnforcementTeamAsync(crimeId);
            return StatusCode(204);
        }
    }
}