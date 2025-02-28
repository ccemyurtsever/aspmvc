using Microsoft.AspNetCore.Mvc;
using watchxanime.UI.DTOs.AboutDTOs;
using watchxanime.UI.Helpers;

namespace watchxanime.UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutUsController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDTO>>("AboutUss");
            return View(values);
        }
        public async Task<IActionResult> DeleteAboutUs(int id)
        {
            await _client.DeleteAsync($"AboutUss/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateAboutUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutUs(CreateAboutDTO createAboutDTO)
        {
            await _client.PostAsJsonAsync("AboutUss", createAboutDTO);
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> UpdateAboutUs(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateAboutDTO>($"AboutUss/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAboutUs(UpdateAboutDTO updateAboutDTO)
        {
            await _client.PutAsJsonAsync("AboutUss", updateAboutDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
