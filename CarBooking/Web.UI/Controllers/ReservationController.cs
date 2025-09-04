using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Web.Dto.LocationDtos;
using Web.Dto.ReservationDtos;

namespace Web.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.carid = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7245/api/Locations");

            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> locations = (from x in values
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.LocationID.ToString()
                                              }).ToList();
            ViewBag.v = locations;

            

            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:7245/api/Reservations", stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
