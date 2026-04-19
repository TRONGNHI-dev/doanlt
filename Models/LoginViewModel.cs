using System.ComponentModel.DataAnnotations;

namespace TravelProject.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui long nhap ten dang nhap")]
        [Display(Name = "Username")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui long nhap mat khau")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
