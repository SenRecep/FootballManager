using System.ComponentModel.DataAnnotations;

namespace FootballManager.MvcUi.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Venligst udfyld en gyldig Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Venligst skriv en adgangskode")]
        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode")]
        public string Password { get; set; }
        [Display(Name ="Husk mig")]
        public bool RememberMe { get; set; } 
    }
}
