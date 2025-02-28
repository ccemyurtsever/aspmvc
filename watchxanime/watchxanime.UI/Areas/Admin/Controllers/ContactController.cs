using Microsoft.AspNetCore.Mvc;
using watchxanime.UI.DTOs.ContactDTOs;
using watchxanime.UI.Helpers;

namespace watchxanime.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();


        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDTO>>("Contacts");
            return View(values);
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _client.DeleteAsync($"Contacts/{id}");
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ContactDetail(int id)
        {
            var values = await _client.GetFromJsonAsync<ResultContactDTO>($"Contacts/{id}");
            return View(values);
        }
    }
}
