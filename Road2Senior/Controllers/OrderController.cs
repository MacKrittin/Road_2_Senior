using Road2Senior.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Road2Senior.Controllers
{
    public class OrderController : Controller
    {
        private readonly IEmailSender _emailSender;

        public OrderController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(int orderId)
        {
            // ... บันทึก Order

            await _emailSender.SendAsync("customer@mail.com", "Order confirmed", $"Order #{orderId}");
            return Ok("Success");
        }

    }
}
