using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.MovieDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: MovieController
        public async Task<IActionResult>MovieList()
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v1 = "Tüm Filmler";
            var client=_httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7283/api/Movies");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultMovieDto>>(json);
                return View(values);
                
            }
            return View();
        }

        public async Task<IActionResult> MovieDetail(int id)
        {
            id = 0;
            return View();
        }

    }
}
