using Microsoft.AspNetCore.Mvc;

namespace Web.UI.ViewComponents.CarViewComponents
{
    public class _CarCoverComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }   

}
