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
                var jsonDataCarCount = await responseCarCount.Content.ReadAsStringAsync();
                var valuesCarCount = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonDataCarCount);
                ViewBag.CarCount = valuesCarCount.CarCount;
            }
            var responseBrandNameByMaxCar = await client.GetAsync("https://localhost:7245/api/Statistics/BrandNameByMaxCar");
            if (responseBrandNameByMaxCar.IsSuccessStatusCode)
            {
                var jsonDataBrandNameByMaxCar = await responseBrandNameByMaxCar.Content.ReadAsStringAsync();
                var valuesBrandNameByMaxCar = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonDataBrandNameByMaxCar);
                ViewBag.BrandNameByMaxCar = valuesBrandNameByMaxCar.BrandNameByMaxCar;
            }
            var responseAvgDailyPrice = await client.GetAsync("https://localhost:7245/api/Statistics/GetAvgRentPriceForDaily");
            if (responseAvgDailyPrice.IsSuccessStatusCode)
            {
                var jsonDataAvgDailyPrice = await responseAvgDailyPrice.Content.ReadAsStringAsync();
                var valuesAvgDailyPrice = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonDataAvgDailyPrice);
                ViewBag.AvgDailyPrice = valuesAvgDailyPrice.AvgDailyPrice;
            }
            var responseAvgWeeklyPrice = await client.GetAsync("https://localhost:7245/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseAvgWeeklyPrice.IsSuccessStatusCode)
            {
                var jsonDataAvgWeeklyPrice = await responseAvgWeeklyPrice.Content.ReadAsStringAsync();
                var valuesAvgWeeklyPrice = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonDataAvgWeeklyPrice);
                ViewBag.AvgWeeklyPrice = valuesAvgWeeklyPrice.AvgWeeklyPrice;
            }
            var responseAvgMonthlyPrice = await client.GetAsync("https://localhost:7245/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseAvgMonthlyPrice.IsSuccessStatusCode)
            {
                var jsonDataAvgMonthlyPrice = await responseAvgMonthlyPrice.Content.ReadAsStringAsync();
                var valuesAvgMonthlyPrice = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonDataAvgMonthlyPrice);
                ViewBag.AvgMonthlyPrice = valuesAvgMonthlyPrice.AvgMonthlyPrice;
            }
            var responseBrandCount = await client.GetAsync("https://localhost:7245/api/Statistics/GetBrandCount");
            if (responseBrandCount.IsSuccessStatusCode)
            {
                var jsonDataBrandCount = await responseBrandCount.Content.ReadAsStringAsync();
                var valuesBrandCount = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonDataBrandCount);
                ViewBag.BrandCount = valuesBrandCount.BrandCount;
            }
            var responseElectricCarCount = await client.GetAsync("https://localhost:7245/api/Statistics/GetCarCountByElectric");
            if (responseElectricCarCount.IsSuccessStatusCode)
            {
                var jsonDataElectricCarCount = await responseElectricCarCount.Content.ReadAsStringAsync();
                var valuesElectricCarCount = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonDataElectricCarCount);
                ViewBag.ElectricCarCount = valuesElectricCarCount.ElectricCarCount;
            }
            var responseCarCountByTransmissionIsAuto = await client.GetAsync("https://localhost:7245/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseCarCountByTransmissionIsAuto.IsSuccessStatusCode)
            {
                var jsonDataCarCountByTransmissionIsAuto = await responseCarCountByTransmissionIsAuto.Content.ReadAsStringAsync();
                var valuesCarCountByTransmissionIsAuto = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonDataCarCountByTransmissionIsAuto);
                ViewBag.CarCountByTransmissionIsAuto = valuesCarCountByTransmissionIsAuto.CarCountByTransmissionIsAuto;
            }
            var responseLocationCount = await client.GetAsync("https://localhost:7245/api/Statistics/GetLocationCount");
            if (responseLocationCount.IsSuccessStatusCode)
            {
                var jsonDataLocationCount = await responseLocationCount.Content.ReadAsStringAsync();
                var valuesLocationCount = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonDataLocationCount);
                ViewBag.LocationCount = valuesLocationCount.LocationCount;
            }
            return View();
        }
    }
}
