using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Dto.CarFeatureDtos;
using Web.Dto.LocationDtos;

namespace Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7245/api/CarFeatures/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDtos)
        {
            foreach(var item in resultCarFeatureByCarIdDtos)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7245/api/CarFeatures/CarFeatureChangeAvaibleTrue?id={item.CarFeatureID}");
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7245/api/CarFeatures/CarFeatureChangeAvaibleFalse?id={item.CarFeatureID}");
                }
                
            }
            return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
        }
    }
}
