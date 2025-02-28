using Microsoft.AspNetCore.Mvc;
using watchxanime.UI.DTOs.AnimeDTOs;
using watchxanime.UI.Helpers;

namespace watchxanime.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AnimeController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAnimeDTO>>("Animes");
            return View(values);
        }
        public async Task<IActionResult> DeleteAnime(int id)
        {
            await _client.DeleteAsync($"Animes/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateAnime()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnime(CreateAnimeDTO createAnimeDTO)
        {
            await _client.PostAsJsonAsync("Animes", createAnimeDTO);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateAnime(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateAnimeDTO>($"Animes/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAnime(UpdateAnimeDTO updateAnimeDTO)
        {
            await _client.PutAsJsonAsync("Animes", updateAnimeDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
