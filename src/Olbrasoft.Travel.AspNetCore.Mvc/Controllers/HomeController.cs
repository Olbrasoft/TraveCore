using Microsoft.AspNetCore.Mvc;
using Olbrasoft.Travel.AspNetCore.Mvc.Models;
using Olbrasoft.Travel.Data.Entity.Framework;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
