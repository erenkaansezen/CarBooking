using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Dto.CarDtos;
using Web.Dto.CarPricingDtos;
using Web.Dto.ServiceDtos;

namespace Web.UI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7245/api/CarPricing");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.carid = id;
            return View();
        }
    }
}
