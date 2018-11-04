using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Models
{
    public class InfoFacade:IGetInfo
    {
        public Info GetInfo()
        {
            return new Info();
        }

       
    }
}
