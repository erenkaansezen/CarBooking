using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Dto.FooterAdressesDtos;
using Web.Dto.TestimonialDtos;

namespace Web.UI.ViewComponents.FooterAdressViewComponents
{
    public class _FooterAdresViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAdresViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7245/api/FooterAdress");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAdressesDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
