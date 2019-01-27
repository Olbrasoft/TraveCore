using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Business;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Controllers
{
    public class AccommodationsController : Controller
    {
        private readonly IAccommodations _accommodations;

        public AccommodationsController(IAccommodations accommodations)
        {
            _accommodations = accommodations;
        }

        // GET: Accommodations
        public async Task<IActionResult> Index(int page = 1)
        {
            var provider = new AcceptLanguageHeaderRequestCultureProvider();

            var cultures = await provider.DetermineProviderCultureResult(HttpContext);

            ViewData["languages"] = cultures.UICultures[0];

            var pageInfo = new PageInfo(10, page);

            var accommodationsItems = await _accommodations.GetAsync(pageInfo, 1033,
                localizedAccommodations =>
                    localizedAccommodations.OrderBy(p => p.Accommodation.SequenceNumber).ThenBy(p => p.Id));

            return View(accommodationsItems.AsPagedList(pageInfo));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);

            var accommodationDetail = await _accommodations.GetAsync((int)id, 1033);

            ViewBag.H1 = accommodationDetail.Name;

            return View(accommodationDetail);
        }
    }
}