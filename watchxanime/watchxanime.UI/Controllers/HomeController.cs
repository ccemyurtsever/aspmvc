using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using watchxanime.UI.Models;

namespace watchxanime.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt_token");
            Response.Cookies.Delete("user_info");

            return RedirectToAction("Index", "Home");
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/archive")]
        public IActionResult Archive()
        {
            return View();
        }

        [Route("/privacypolicy")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        [Route("/aboutus")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("/watch")]
        public IActionResult Watch()
        {
            return View();
        }
    }

}
