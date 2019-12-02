using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManager.MvcUi.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Udfyld brugernavn")]
        [Display(Name ="Brugernavn")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Udfyld adgangskode")]
        [Display(Name = "Adgangskode")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Adganskoder skal være ens")]
        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode bekræftelse")]
        public string PasswordConfirmation { get; set; }
        [Required(ErrorMessage = "Udfyld Email adresse")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
