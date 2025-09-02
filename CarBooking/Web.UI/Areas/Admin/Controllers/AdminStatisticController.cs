using Microsoft.AspNetCore.Mvc;

namespace Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistic")]
    public class AdminStatisticController : Controller
    {
        [Route("Index")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
