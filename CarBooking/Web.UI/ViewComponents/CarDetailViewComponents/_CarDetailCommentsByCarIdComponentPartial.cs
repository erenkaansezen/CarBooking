using Microsoft.AspNetCore.Mvc;

namespace Web.UI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentsByCarIdComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CarDetailCommentsByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7245/api/Reviews/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Web.Dto.CommentDtos.ResultCommentByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
