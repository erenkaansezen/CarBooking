using Microsoft.AspNetCore.Mvc;

namespace Web.UI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailTabPaneComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
