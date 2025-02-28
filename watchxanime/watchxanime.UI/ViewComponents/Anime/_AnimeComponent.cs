using Microsoft.AspNetCore.Mvc;
using watchxanime.UI.DTOs.AnimeDTOs;
using watchxanime.UI.Helpers;

namespace watchxanime.UI.ViewComponents.Anime
{
    public class _AnimeComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAnimeDTO>>("animes");
            return View(values);
        }
    }
}
