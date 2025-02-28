using Microsoft.AspNetCore.Mvc;
using watchxanime.UI.DTOs.PrivacyPolicyDTOs;
using watchxanime.UI.Helpers;

namespace watchxanime.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class PrivacyPolicyController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultPrivacyPolicyDTO>>("PrivacyPolicys");
            return View(values);
        }

        public async Task<IActionResult> DeletePrivacyPolicy(int id)
        {
            await _client.DeleteAsync($"PrivacyPolicys/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreatePrivacyPolicy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrivacyPolicy(CreatePrivacyPolicyDTO createPrivacyPolicyDTO)
        {
            await _client.PostAsJsonAsync("PrivacyPolicys", createPrivacyPolicyDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdatePrivacyPolicy(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdatePrivacyPolicyDTO>($"PrivacyPolicys/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePrivacyPolicy(UpdatePrivacyPolicyDTO updatePrivacyPolicyDTO)
        {
            await _client.PutAsJsonAsync("PrivacyPolicys", updatePrivacyPolicyDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
