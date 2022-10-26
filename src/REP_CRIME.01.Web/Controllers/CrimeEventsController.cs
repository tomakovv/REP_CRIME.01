using Microsoft.AspNetCore.Mvc;
using REP_CRIME._01.Common.Dto;
using REP_CRIME._01.Web.Extensions;
using REP_CRIME._01.Web.Models;
using System.Diagnostics;

namespace REP_CRIME._01.Web.Controllers
{
    public class CrimeEventsController : Controller
    {
        private readonly HttpClient _httpClient;

        public CrimeEventsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var crimeEventsResult = await _httpClient.DoGetAsync<IEnumerable<CrimeEventViewModel>>("http://crime-service/api/CrimeEvents");
            var crimeStatsResult = await _httpClient.DoGetAsync<CrimeEventStats>("http://crime-service/api/CrimeEvents/stats");

            if (crimeEventsResult.Success && crimeStatsResult.Success)
            {
                var crimes = crimeEventsResult.Data.OrderBy(s => s.Date).Take(10);
                var crimeStats = crimeStatsResult.Data;
                ViewBag.CrimeStats = crimeStats;
                var vm = new List<CrimeEventViewModel>();
                foreach (var crime in crimes)
                {
                    vm.Add(new CrimeEventViewModel()
                    {
                        Status = crime.Status,
                        Date = crime.Date,
                        Description = crime.Description,
                        EventId = crime.EventId,
                        Location = crime.Location,
                        ReporterEmail = crime.ReporterEmail,
                        Type = crime.Type,
                    });
                }
                return View(vm);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCrimeEventDto entry)
        {
            if (ModelState.IsValid)
            {
                var result = await _httpClient.PostAsJsonAsync("http://crime-service/api/CrimeEvents", entry);
                if (result.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            return View(entry);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}