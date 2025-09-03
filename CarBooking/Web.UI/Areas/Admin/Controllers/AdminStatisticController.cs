using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Dto.BannerDtos;
using Web.Dto.StatisticDtos;

namespace Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistic")]
    public class AdminStatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            var responseCarCount = await client.GetAsync("https://localhost:7245/api/Statistics/GetCarCount");
            if (responseCarCount.IsSuccessStatusCode)
            {
                var jsonData = await responseCarCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCount = values.CarCount;
            }
            var responseBrandNameByMaxCar = await client.GetAsync("https://localhost:7245/api/Statistics/BrandNameByMaxCar");
            if (responseBrandNameByMaxCar.IsSuccessStatusCode)
            {
                var jsonData = await responseBrandNameByMaxCar.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.BrandNameByMaxCar = values.BrandNameByMaxCar;
            }
            var responseAvgDailyPrice = await client.GetAsync("https://localhost:7245/api/Statistics/GetAvgRentPriceForDaily");
            if (responseAvgDailyPrice.IsSuccessStatusCode)
            {
                var jsonData = await responseAvgDailyPrice.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.AvgDailyPrice = values.AvgDailyPrice;
            }
            var responseAvgWeeklyPrice = await client.GetAsync("https://localhost:7245/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseAvgWeeklyPrice.IsSuccessStatusCode)
            {
                var jsonData = await responseAvgWeeklyPrice.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.AvgWeeklyPrice = values.AvgWeeklyPrice;
            }
            var responseAvgMonthlyPrice = await client.GetAsync("https://localhost:7245/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseAvgMonthlyPrice.IsSuccessStatusCode)
            {
                var jsonData = await responseAvgMonthlyPrice.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.AvgMonthlyPrice = values.AvgMonthlyPrice;
            }
            var responseBrandCount = await client.GetAsync("https://localhost:7245/api/Statistics/GetBrandCount");
            if (responseBrandCount.IsSuccessStatusCode)
            {
                var jsonData = await responseBrandCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.BrandCount = values.BrandCount;
            }
            var responseElectricCarCount = await client.GetAsync("https://localhost:7245/api/Statistics/GetCarCountByElectric");
            if (responseElectricCarCount.IsSuccessStatusCode)
            {
                var jsonData = await responseElectricCarCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.ElectricCarCount = values.ElectricCarCount;
            }
            var responseCarCountByTransmissionIsAuto = await client.GetAsync("https://localhost:7245/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseCarCountByTransmissionIsAuto.IsSuccessStatusCode)
            {
                var jsonData = await responseCarCountByTransmissionIsAuto.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCountByTransmissionIsAuto = values.CarCountByTransmissionIsAuto;
            }
            var responseLocationCount = await client.GetAsync("https://localhost:7245/api/Statistics/GetLocationCount");
            if (responseLocationCount.IsSuccessStatusCode)
            {
                var jsonData = await responseLocationCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.LocationCount = values.LocationCount;
            }
            return View();
        }
    }
}
