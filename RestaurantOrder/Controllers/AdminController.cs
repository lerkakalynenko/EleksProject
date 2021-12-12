using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrder.Controllers

{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
       
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        
       
    }
}
