using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrder.Controllers

{  
    
    public class AdminController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult GetOrder()
        {
            return View();
        }
    }
}
