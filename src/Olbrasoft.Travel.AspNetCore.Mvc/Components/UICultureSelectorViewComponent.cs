using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.AspNetCore.Mvc.Components
{
    // ReSharper disable once InconsistentNaming
    public class UICultureSelectorViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}