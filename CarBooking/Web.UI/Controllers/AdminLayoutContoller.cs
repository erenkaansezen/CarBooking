using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class AdminLayoutContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
