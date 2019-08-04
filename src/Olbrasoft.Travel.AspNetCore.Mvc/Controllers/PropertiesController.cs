using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Business;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IProperties _properties;

        public PropertiesController(IProperties properties)
        {
            _properties = properties;
        }

        // GET: Properties
        public async Task<IActionResult> Index(int page = 1)
        {
            var provider = new AcceptLanguageHeaderRequestCultureProvider();

            var cultures = await provider.DetermineProviderCultureResult(HttpContext);

            ViewData["languages"] = cultures.UICultures[0];

            var pageInfo = new PageInfo(10, page);

            var accommodationsItems = await _properties.GetAsync(pageInfo, 1033,
                localizedAccommodations =>
                    localizedAccommodations.OrderBy(p => p.Property.SequenceNumber).ThenBy(p => p.Id));

            return View(accommodationsItems.AsPagedList(pageInfo));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return StatusCode(StatusCodes.Status400BadRequest);

            var accommodationDetail = await _properties.GetAsync((int)id, 1033);

            ViewBag.H1 = accommodationDetail.Name;

            return View(accommodationDetail);
        }

        public async Task<IActionResult> ByRegion(int regionId, int page = 1)
        {
            var pageInfo = new PageInfo(10, page);
            
            var accommodationsItems = await _properties.GetAsync(regionId, pageInfo, 1033,
                localizedAccommodations =>
                    localizedAccommodations.OrderBy(p => p.Property.SequenceNumber).ThenBy(p => p.Id));

            return View(accommodationsItems.AsPagedList(pageInfo));

        }
    }
}