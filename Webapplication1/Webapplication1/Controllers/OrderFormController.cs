using Microsoft.AspNetCore.Mvc;
using HOT1.Models;

namespace HOT1.Controllers
{
    public class OrderFormController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new OrderFormModel());
        }

        [HttpPost]
        public IActionResult Index(OrderFormModel orderForm)
        {
            if (ModelState.IsValid)
            {
                double discountPercentage;
                if (IsValidDiscountCode(orderForm.DiscountCode, out discountPercentage))
                {
                    orderForm.PricePerShirt *= (1 - discountPercentage);
                    orderForm.DiscountMessage = $"Discount applied: {discountPercentage:P0} off!";
                }
                else if (!string.IsNullOrEmpty(orderForm.DiscountCode))
                {
                    orderForm.DiscountMessage = "Invalid discount code.";
                }

                return View(orderForm);
            }

            return View(orderForm);
        }

        private bool IsValidDiscountCode(string code, out double discountPercentage)
        {
            var discountCodes = new Dictionary<string, double>
    {
        { "6175", 0.30 }, 
        { "1390", 0.20 }, 
        { "BB88", 0.10 } 
    };

            discountPercentage = 0;

            if (string.IsNullOrEmpty(code))
            {
                return false;
            }

            return discountCodes.TryGetValue(code, out discountPercentage);
        }
    }
}