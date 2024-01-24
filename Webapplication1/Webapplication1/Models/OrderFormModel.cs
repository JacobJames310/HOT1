using Microsoft.AspNetCore.Mvc;

namespace HOT1.Models
{
    public class CrazyCrankModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
