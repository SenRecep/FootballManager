using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootBallManager.Entities.Concrete
{
   public class Stadium : EntityBase, IStadium
    {
        [Required(ErrorMessage ="Stadium navn mangler")]
       public string StadiumName { get; set; }
        [Required(ErrorMessage ="Kapacitet mangler")]
        public int Capacity { get; set; }
        [Required(ErrorMessage ="Indtast et år")]
        public int Founded { get; set; } = DateTime.Now.Year;
    }
}
