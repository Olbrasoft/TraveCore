using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Olbrasoft.Travel.Business;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRegions _regions;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IRegions regions, IStringLocalizer<HomeController> localizer)
        {
            _regions = regions;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index()
        {
            //var userLanguages = Request.Headers["Accept-Language"].ToString();

            //if (userLanguages != null) await Response.WriteAsync(userLanguages);

            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(1033);

            var provider = new AcceptLanguageHeaderRequestCultureProvider();

            var cultures = await provider.DetermineProviderCultureResult(HttpContext);

            ViewData["languages"] = cultures.UICultures[0];

            //           ViewData["H1"] = _localizer["Travel"];

            var continents = await _regions.GetContinentsAsync(1033);
            return View(continents);
        }


        public IEnumerable<string> Search(string term)
        {
            var source = new List<string>
            {
                "Jirka",
                "value1",
                "value2"
            };
            
            var result = source.Where(p => p.Contains(term));

            return result;

        }


        public async Task<IActionResult> Continent(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status400BadRequest);
            var countries = await _regions.GetCountriesAsync((int)id, 1033);
            return View(countries);
        }
    }
}