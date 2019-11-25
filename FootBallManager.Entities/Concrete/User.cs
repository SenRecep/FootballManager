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
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [DataType(DataType.MultilineText)]
        public virtual Adress Adress{ get; set; }
        public int Adressid{ get; set; }
        public bool IsAdmin { get; set; } = false;
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "ugyldig email adresse")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Indtast en gyldig adgangskode")]
        public string Password { get; set; }
    }
}
