using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootBallManager.Entities.Concrete
{
    public class Coach : EntityBase, ICoach
    {
        [Required(ErrorMessage = "Indtast fornavn")]
        public string Firstname { get; set; }
        [Required(ErrorMessage ="Indtast eternavn")]
        public string LastName { get; set; }

        [Range(1, 150, ErrorMessage = "Alder skal være mellem 1 og 150")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Nationalitet kan ikke være tom")]
        public Nation Nation { get; set; }
        public int? Nationid { get; set; }
        [Required]
        public double WeeklyPaid { get; set; } = 0;
        [Required]
        public CoachSkill CoachSkill { get; set; }
        public int? CoachSkillid { get; set; }
    }
}
