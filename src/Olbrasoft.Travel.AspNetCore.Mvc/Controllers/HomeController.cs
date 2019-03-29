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
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ITravel _travel;

        public HomeController(ITravel travel, IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
            _travel = travel;
        }

        public async Task<IActionResult> Index()
        {
            var suggestions = await _travel.SuggestionsAsync("Bene", 1033);

            //var q1 = from r in q
            //         select new SuggestionDto
            //         {
            //             Id = r.Id,
            //             Label = r.Name
            //         };

            //var result = q1.ToArray();

            //var userLanguages = Request.Headers["Accept-Language"].ToString();

            //if (userLanguages != null) await Response.WriteAsync(userLanguages);

            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(1033);

            var provider = new AcceptLanguageHeaderRequestCultureProvider();

            var cultures = await provider.DetermineProviderCultureResult(HttpContext);

            ViewData["languages"] = cultures.UICultures[0];

            const int languageId = 1033;

            var continents = await _travel.Regions.GetContinentsAsync(languageId);

            return View(continents);
        }

        public async Task<IActionResult> Continent(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status400BadRequest);

            var countries = await _travel.Regions.GetCountriesAsync((int)id, 1033);

            return View(countries);
        }

        public async Task<JsonResult> Suggestions(string term)
        {
            var suggestions = await _travel.SuggestionsAsync(term, 1033);

            return Json(suggestions);
        }
    }
}