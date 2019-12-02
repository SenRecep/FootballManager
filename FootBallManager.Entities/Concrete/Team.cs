using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootBallManager.Entities.Concrete
{
   public class Team : EntityBase, ITeam
    {

        [Required(ErrorMessage ="Udfyld klubnavn")]
        public string ClubName { get; set; }
        [Required(ErrorMessage ="udfyld år for oprettelsen")]
        [DataType(DataType.DateTime)]
        public int Founded { get; set; }
        [Required(ErrorMessage ="Valg en stadium til holdet")  ]

        public Stadium Stadium { get; set; }
        public int Stadiumid { get; set; }

        public List<Player> Players { get; set; }
        
        public Coach Coach{ get; set; }
        //todo: Coach id verilmemis

        public virtual List<Trophy> Trophies { get; set; }

    }
}

