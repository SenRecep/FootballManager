using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootBallManager.Entities.Concrete
{
   public class Postalcode : EntityBase, IPostalcode
    {
        [Required(ErrorMessage ="Indtast venligst en by")]
        public string City { get; set; }
        [Range(1000, 9999)]
        [Required(ErrorMessage ="Indtast venligst en gyldig postnummer")]
        public int PostalCode { get; set; }
    }
}
