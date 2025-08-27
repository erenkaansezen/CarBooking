using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Dto.AboutDtos;

namespace Web.UI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> Invoke()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5000/api/AboutUs");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
    
    
}
