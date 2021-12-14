using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Models;

namespace RestaurantOrder.Controllers
{   
   
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager) 
        {
            _signInManager = signInManager;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _signInManager
                .PasswordSignInAsync(model.UserName, model.Password, true, false);

            if (result.Succeeded)
            {
                RedirectToAction("Index", "Admin");
            }

            ModelState.AddModelError(string.Empty, "Incorrect login or password.");
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

