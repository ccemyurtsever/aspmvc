using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace watchxanime.UI.Areas.Admin.Controllers
{
    //[Authorize]
    public class InitController : Controller
    {
        [Area("Admin")]
        [Route("[area]/")]  
        public IActionResult Index()
        {
            return View();
        }

    }
}
