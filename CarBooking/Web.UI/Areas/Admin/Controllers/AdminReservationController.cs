using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Web.Dto.CarDtos;
using Web.Dto.LocationDtos;
using Web.Dto.ReservationDtos;
using Web.Dto.ServiceDtos;

namespace Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminReservation")]
    public class AdminReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // API uçlarını kendi projene göre güncelle
            var reservationsTask = client.GetAsync("https://localhost:7245/api/Reservations");
            var locationsTask = client.GetAsync("https://localhost:7245/api/Locations");
            var carsTask = client.GetAsync("https://localhost:7245/api/Cars"); // Marka bilgisi dönüyorsa yeterli

            await Task.WhenAll(reservationsTask, locationsTask, carsTask);

            // Rezervasyonlar
            var reservations = new List<ResultReservationDto>();
            if (reservationsTask.Result.IsSuccessStatusCode)
            {
                var json = await reservationsTask.Result.Content.ReadAsStringAsync();
                reservations = JsonConvert.DeserializeObject<List<ResultReservationDto>>(json) ?? new();
            }

            // Lokasyon 
            var locationNames = new Dictionary<int, string>();
            if (locationsTask.Result.IsSuccessStatusCode)
            {
                var json = await locationsTask.Result.Content.ReadAsStringAsync();
                var locs = JsonConvert.DeserializeObject<List<ResultLocationDto>>(json) ?? new();
                foreach (var l in locs) locationNames[l.LocationID] = l.Name;
            }

            // Araç sözlüğü
            var carNames = new Dictionary<int, string>();
            if (carsTask.Result.IsSuccessStatusCode)
            {
                var json = await carsTask.Result.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDtos>>(json) ?? new();
                foreach (var c in cars)
                {
                    var brand = c.BrandName ?? "";
                    var model = c.Model ?? "";
                    carNames[c.CarID] = string.Join(" ", new[] { brand, model }.Where(s => !string.IsNullOrWhiteSpace(s)));
                }
            }

            ViewBag.LocationNames = locationNames; 
            ViewBag.CarNames = carNames;           

            return View(reservations);
        }

        [Route("ReservationStatusToDelivered/{id}")]
        public async Task<IActionResult> ReservationStatusToDelivered(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.PostAsync($"https://localhost:7245/api/Reservations/ReservationStatusToDelivered/{id}", null);
            return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });
        }

        [Route("ReservationStatusToReceived/{id}")]
        public async Task<IActionResult> ReservationStatusToReceived(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.PostAsync($"https://localhost:7245/api/Reservations/ReservationStatusToReceived/{id}", null);
            return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });
        }
        [Route("RemoveReservation/{id}")]
        public async Task<IActionResult> RemoveReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7245/api/Reservations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });
            }
            return View();
        }
    }
}