using Microsoft.AspNetCore.Identity;

namespace watchxanime.API.Services.UserServices
{
    public class AppUser: IdentityUser<int>
    {
        public string FullName { get; set; } = null!;
        public DateTime Registration { get; set; }
    }
}
