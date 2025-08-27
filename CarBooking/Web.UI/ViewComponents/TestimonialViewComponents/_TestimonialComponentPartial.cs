using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Dto.AboutDtos;

namespace Web.UI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> Invoke()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7245/api/Testimonials");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
