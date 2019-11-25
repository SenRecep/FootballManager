using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;
namespace FootBallManager.Entities.Concrete
{
   public class User :EntityBase, IUser
    {
        [Required(ErrorMessage ="Indtast fornavn")]
        public string Firstname { get; set; }
        [Required(ErrorMessage ="Indtast efternavn")]
        public string Lastname { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="ugyldig adresse")]
        public virtual Adress Adress{ get; set; }
        public int Adressid{ get; set; }
        [Required]
        public bool IsAdmin { get; set; } = false;
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="ugyldig email adresse")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Indtast en gyldig adgangskode")]
        public string Password { get; set; }

    }
}
