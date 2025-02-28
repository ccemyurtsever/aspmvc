using Microsoft.AspNetCore.Mvc;
using watchxanime.UI.DTOs.BannerDTOs;
using watchxanime.UI.Helpers;

namespace watchxanime.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BannerController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDTO>>("banners");
            return View(values);
        }

       public async Task<IActionResult> DeleteBanner(int id)
        {
            await _client.DeleteAsync($"banners/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDTO createBannerDTO)
        {
            await _client.PostAsJsonAsync("banners", createBannerDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateBanner(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateBannerDTO>($"banners/{id}");
            return View(value);
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDTO updateBannerDTO)
        {
            await _client.PutAsJsonAsync("banners", updateBannerDTO);
            return RedirectToAction(nameof(Index));
        }

    }

}
