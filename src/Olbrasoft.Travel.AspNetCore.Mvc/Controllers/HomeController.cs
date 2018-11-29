using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Travel.Business;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRegions _regions;

        public HomeController(IRegions regions)
        {
            _regions = regions;
        }

        public async Task<IActionResult> Index()
        {
            var continents = await _regions.GetContinentsAsync(1033);
            return View(continents);
        }


        public async Task<IActionResult> Continent(int? id)
        {
            if (id == null) return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            var countries = await _regions.GetCountriesAsync((int)id,1033);
            return View(countries);
        }
    }
}
