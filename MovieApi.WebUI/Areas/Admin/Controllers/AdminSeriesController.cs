using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.AdminSeriesDto;
using Newtonsoft.Json;


namespace MovieApi.WebUI.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class AdminSeriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSeriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> SeriesList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7283/api/Serieses");

            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultSeriesDto>>(jsonData);
                return View(values);
            }

            // 👇 ASLA null gönderme
            return View(new List<AdminResultSeriesDto>());
        }


        [HttpGet]
        public IActionResult CreateSeries()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries(AdminCreateSeriesDto adminCreateSeriesDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(adminCreateSeriesDto);
            StringContent stringContent=new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responsemessage = await client.PostAsync("https://localhost:7283/api/Serieses",stringContent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList");
            }
            return View();
        }

        [HttpPost]
     [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage =
                await client.DeleteAsync($"https://localhost:7283/api/Serieses/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList", "AdminSeries", new { area = "Admin" });
            }

            // hata olursa listeye dön
            return RedirectToAction("SeriesList", "AdminSeries", new { area = "Admin" });
        }

    }
}
