using Microsoft.AspNetCore.Mvc;
using watchxanime.UI.DTOs.PrivacyPolicyDTOs;
using watchxanime.UI.Helpers;

namespace watchxanime.UI.ViewComponents.PrivacyPolicy
{
    public class _PrivacyPolicyComponent : ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultPrivacyPolicyDTO>>("PrivacyPolicys");
            return View(values);
        }
    }
}
