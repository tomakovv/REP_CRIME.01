using Crime.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using REP_CRIME._01.Common.Dto;

namespace Crime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeEventsController : ControllerBase
    {
        private readonly ICrimeEventsService _crimeEventsService;

        public CrimeEventsController(ICrimeEventsService crimeEventsService)
        {
            _crimeEventsService = crimeEventsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCrimeEvents() => Ok(await _crimeEventsService.GetAllCrimeEventsAsync());

        [HttpGet("id")]
        public async Task<IActionResult> GetCrimeEvent([FromQuery] Guid crimeEventId) => Ok(await _crimeEventsService.GetCrimeEventAsync(crimeEventId));

        [HttpPost]
        public async Task<IActionResult> CreateCrimeEvent(CreateCrimeEventDto createCrimeEventDto)
        {
            await _crimeEventsService.CreateNewCrimeEventAsync(createCrimeEventDto);
            return StatusCode(201);
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetDailyCrimeEventsCount() => Ok(await _crimeEventsService.GetCrimeEventsStats());
    }
}