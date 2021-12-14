using System.ComponentModel.DataAnnotations;

namespace RestaurantOrder.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Enter a login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        public string Password { get; set; }

    }
}
