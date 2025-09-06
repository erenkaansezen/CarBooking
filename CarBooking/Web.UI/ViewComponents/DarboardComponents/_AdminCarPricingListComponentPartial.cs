using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Dto.CarPricingDtos;

namespace Web.UI.ViewComponents.DarboardComponents
{
    public class _AdminCarPricingListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminCarPricingListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7060/api/CarPricings/GetCarPricingWithTimePeriodList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
