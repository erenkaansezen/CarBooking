using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
