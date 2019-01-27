using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Controllers
{
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        //overall route /{culture}/Values/ShowMeTheCulture
        [Route("ShowMeTheCulture")]
        public string GetCulture()
        {
            return $"CurrentCulture:{CultureInfo.CurrentCulture.Name}, CurrentUICulture:{CultureInfo.CurrentUICulture.Name}";
        }
    }
}