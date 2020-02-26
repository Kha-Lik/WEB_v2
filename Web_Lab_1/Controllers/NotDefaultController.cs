using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web_Lab_1.Controllers
{
    public class NotDefaultController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public NotDefaultController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        // GET
        public IActionResult SomeAction()
        {
            return View();
        }

        public IActionResult ViewWithGetParam([FromQuery] string from)
        {
            string model = $"Get parameter was \"{from}\"";
            return View("ViewWithGetParam", model);
        }
    }
}