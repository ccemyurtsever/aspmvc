using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace watchxanime.UI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
