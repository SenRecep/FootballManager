using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootBallManager.Entities.Concrete
{
  public class Nation : EntityBase, INation
    {
        [Required(ErrorMessage ="Indtast en gyldig nationalitet")]
        public string Nationality { get; set; }
    }
}
