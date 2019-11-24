using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootBallManager.Entities.Concrete
{
    public class Player : EntityBase, IPlayer
    {
        [Required(ErrorMessage = "Fornavn skal indtastes")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Efternavn skal indtastes")]
        public string LastName { get; set; }
        [DataType(DataType.MultilineText, ErrorMessage = "Adressse skal udfyldes")]
        public Adress Adress { get; set; }
        public int Adressid { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Der er ikke indtastet en gyldig email")]
        public string Email { get; set; }
        [Range(1, 150, ErrorMessage = "Alder skal være mellem 0 og 150")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Højde skal indtastes")]
        public double Height { get; set; }
        [Required(ErrorMessage = "Vægt skal indtastes")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Nationalitet kan ikke være tom")]
        public Nation Nation { get; set; }
        public int Nationid { get; set; }
        [Required(ErrorMessage = "Valg en position for spilleren")]
        public string Position { get; set; }
        [Required(ErrorMessage = "indtasts venligst fortrukne fod")]
        public string Foot { get; set; }
        [Required(ErrorMessage = "Indtast venligst ugentli løn for spilleren")]
        public double WeeklyPaid { get; set; }
        [Required(ErrorMessage = "Marketsprisen kan ikke være tom")]
        public double MarketPriceValue { get; set; }
        public PlayerSkill PlayerSkill { get; set; }
        public int PlayerSkillid { get; set; }
        public virtual List<Description> Descriptions { get; set; }
        public int Number { get; set; }
        public Team Team { get; set; }
        public int Teamid { get; set; }
    }
}
