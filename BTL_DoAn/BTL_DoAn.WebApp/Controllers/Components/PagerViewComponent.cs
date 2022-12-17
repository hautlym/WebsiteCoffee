using BTL_DoAn.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTL_DoAn.WebApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(ProductIndexModel result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
