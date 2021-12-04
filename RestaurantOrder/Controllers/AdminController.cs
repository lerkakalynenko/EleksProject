using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        
       
    }
}
