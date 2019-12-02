using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootBallManager.Entities.Concrete
{
    public class Description : EntityBase, IDescription
    {

        [Required(ErrorMessage = "Valg spiller til beskrivelse")]
        public Player Player { get; set; }
        public int?  Playerid { get; set; }
        [DataType(DataType.MultilineText)]

        [Range(10, 500, ErrorMessage = "Beskrivelsen skal være mellem 10 og 500 tegn lang")]
        public string PlayerDescription { get; set; }

    }
}
