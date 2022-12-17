using BTL_DoAn.Application.Catalog.Common;
using Microsoft.AspNetCore.Mvc;

namespace BTL_DoAn.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
