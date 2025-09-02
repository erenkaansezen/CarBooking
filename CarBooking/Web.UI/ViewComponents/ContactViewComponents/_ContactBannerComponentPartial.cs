using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Dto.BannerDtos;

namespace Web.UI.ViewComponents.ContactViewComponents
{
    public class _ContactBannerComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactBannerComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7245/api/Banners");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
