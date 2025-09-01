using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Controllers
{
    public class AdminCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
