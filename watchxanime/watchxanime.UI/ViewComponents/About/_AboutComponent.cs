using Microsoft.AspNetCore.Mvc;
using watchxanime.UI.DTOs.AboutDTOs;
using watchxanime.UI.Helpers;

namespace watchxanime.UI.ViewComponents.About
{
    public class _AboutComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDTO>>("aboutuss");
            return View(values);
        }
    }
}
