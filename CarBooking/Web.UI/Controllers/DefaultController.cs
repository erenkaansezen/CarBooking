using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
