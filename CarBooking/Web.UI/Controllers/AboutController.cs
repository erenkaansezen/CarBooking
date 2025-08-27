using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
