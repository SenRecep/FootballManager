using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace FootBallManager.Entities.Concrete
{
    public class Trophy : EntityBase, ITrophy
    {
        [Required(ErrorMessage = "Valg år for trofæet")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Valg placering")]
        public int Place { get; set; }
        public Team team { get; set; }
        public int? teamid { get; set; }
    }
}
