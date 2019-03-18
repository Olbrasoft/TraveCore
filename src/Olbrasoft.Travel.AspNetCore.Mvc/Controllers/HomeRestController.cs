using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Olbrasoft.Travel.AspNetCore.Mvc.Controllers
{
   
    public class HomeRestController : Controller
    {

        //[Route("api/[controller]")]
        //[HttpGet("Search")]
        public IEnumerable<string> Search(string term)
        {
            var result= new List<string>()
            {
                "Jirka",
                "value1",
                "value2"
            };
            
            return result.Where(p => p.Contains(term));
        }

        
    }
}
