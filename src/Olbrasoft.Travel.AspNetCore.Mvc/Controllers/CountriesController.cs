using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Travel.Business;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IRegions _regions;

        public CountriesController(IRegions regions)
        {
            _regions = regions;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await _regions.GetCountriesAsync(1033);
            return View(countries);
        }



    }
}