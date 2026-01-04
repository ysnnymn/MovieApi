using System.Text;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.Dtos.UserRegisterDto;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: RegisterController
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost()]
        public  async Task<IActionResult> SignUp(CreateUserRegisterDto registerDto)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(registerDto);
            StringContent stringContent=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7283/api/Registers\n", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SignUp", "Login");
            }

            ViewBag.error = "Kayıt başarısız oldu lütfen tekrar deneyiniz...";
            
            
            
            return RedirectToAction("SignIn", "Login");
        }

    }
}
