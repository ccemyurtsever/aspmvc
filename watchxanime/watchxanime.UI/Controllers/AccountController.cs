using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace watchxanime.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AccountController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration["ApiSettings:BaseUrl"]);
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string fullName, string userName, string email, string password)
        {
            var apiUrl = "https://localhost:7142/api/Users/register";

            var userData = new
            {
                fullName = fullName,
                userName = userName,
                email = email,
                password = password,
                registration = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
            };

            var jsonContent = JsonConvert.SerializeObject(userData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(apiUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Kayıt başarılı!" });
                }
                else
                {
                    return Json(new { success = false, message = "Kayıt başarısız: " + responseContent });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var apiUrl = "https://localhost:7142/api/Users/login";

            var userData = new
            {
                userName = userName,
                password = password
            };

            var jsonContent = JsonConvert.SerializeObject(userData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(apiUrl, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<LoginResponse>(responseContent);

                    if (result?.Token != null)
                    {
                        Response.Cookies.Append("jwt_token", result.Token, new CookieOptions
                        {
                            HttpOnly = true, 
                            Secure = true,  
                            SameSite = SameSiteMode.Strict,
                            Expires = DateTime.UtcNow.AddDays(7)
                        });

                        var userInfo = new
                        {
                            userName = result.UserName,
                            fullName = result.FullName,
                            email = result.Email
                        };
                        Response.Cookies.Append("user_info", JsonConvert.SerializeObject(userInfo), new CookieOptions
                        {
                            HttpOnly = false, 
                            Secure = true,
                            SameSite = SameSiteMode.Strict,
                            Expires = DateTime.UtcNow.AddDays(7)
                        });

                        return Json(new { success = true, message = "Giriş başarılı!", user = userInfo });
                    }
                }

                return Json(new { success = false, message = "Kullanıcı adı veya şifre hatalı." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        [Authorize]
        [Route("profile")]
        public IActionResult Profile()  
        {
            var userInfo = new ProfileViewModel
            {
                UserName = User.Identity?.Name ?? "Kullanıcı",
                Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? "Email bilgisi bulunamadı"
            };
            
            return View(userInfo);
        }

        [HttpGet]
        public IActionResult GetProfile()
        {
            var token = Request.Cookies["jwt_token"];
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var userId = jsonToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = jsonToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var user = GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new { user, role = userRole });
        }

        private object GetUserById(string? userId)
        {
            throw new NotImplementedException();
        }
    }

    public enum UserRole
    {
        Admin,
        User,
        Guest
    }

    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ProfileViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
