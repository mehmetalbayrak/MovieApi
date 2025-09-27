using Dto.UserRegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserRegisterDto createUserRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createUserRegisterDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7083/api/Registers", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SignIn", "Login");
            }
            ViewBag.error = "Kayıt başarısız oldu lütfen tekrar deneyiniz!";
            return View();

        }
    }
}
