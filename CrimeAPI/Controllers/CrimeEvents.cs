using Crime.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeEvents : ControllerBase
    {
        public CrimeEvents(ICrimeEventsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult<IEnumerable<>>
    }
}