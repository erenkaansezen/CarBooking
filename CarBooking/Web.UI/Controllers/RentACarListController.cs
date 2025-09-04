using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Dto.BrandDtos;
using Web.Dto.RentACarDtos;

namespace Web.UI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {

            var locationID = TempData["locationID"];
            id = int.Parse(locationID.ToString());

            ViewBag.locationID = locationID;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7245/api/RentACars?locationID={id}&available=true");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
