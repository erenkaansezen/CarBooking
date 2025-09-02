using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Areas.Admin.Controllers
{
    public class AdminStatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
