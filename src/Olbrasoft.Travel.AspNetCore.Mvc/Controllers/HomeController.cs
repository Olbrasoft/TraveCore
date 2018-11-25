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
        
    }
}
