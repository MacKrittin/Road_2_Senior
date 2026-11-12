using Microsoft.AspNetCore.Mvc;
using Road2Senior.Models;
using Road2Senior.Services.Interfaces;

namespace Road2Senior.Controllers
{
    public class OrderController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly OperationTracker _operationTracker;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IEmailSender emailSender, OperationTracker operationTracker, ILogger<OrderController> logger)
        {
            _emailSender = emailSender;
            _operationTracker = operationTracker;
            _logger = logger;
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
            var operationTrackerMsg = _operationTracker.Id.ToString();
            _logger.LogInformation("[ORDER CONTROLLER GUID] : {1}", operationTrackerMsg);
            await _emailSender.SendAsync("customer@mail.com", "Order confirmed", $"Order #{orderId}");
            return Ok("Success");
        }

    }
}
