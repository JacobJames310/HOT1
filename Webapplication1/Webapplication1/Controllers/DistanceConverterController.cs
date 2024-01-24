using Microsoft.AspNetCore.Mvc;
using HOT1.Models;

namespace HOT1.Controllers
{
	public class DistanceConverterController : Controller
	{
		private const double CM_PER_IN = 2.54;

		[HttpGet]
		public IActionResult Index()
		{
			var model = new DistanceConverterModel();
			return View(model);
		}

		[HttpPost]
        public IActionResult Index(DistanceConverterModel model)
        {
            if (ModelState.IsValid)
            {
                model.DistanceInCentimeters = model.DistanceInInches * CM_PER_IN;
                ViewData["FormSubmitted"] = true;
            }
            return View(model);
        }
    }
}
