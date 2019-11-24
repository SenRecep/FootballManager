using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootBallManager.Entities.Concrete
{
   public class PlayerSkill : EntityBase, IPlayerSkill
    {
        [Required(ErrorMessage ="Valg en spiller")]
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        [Required]
        public int GoolKeeping { get; set; } = 0;
        [Required]
        public int Defending { get; set; } = 0;
        [Required]
        public int Technical { get; set; } = 0;
        [Required]
        public int Attacking { get; set; } = 0;
        [Required]
        public int Speed { get; set; } = 0;
    }
}
