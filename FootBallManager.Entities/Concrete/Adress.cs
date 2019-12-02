using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace FootBallManager.Entities.Concrete
{
    public partial class Adress : EntityBase, IAdress
    {
        [Required(ErrorMessage ="Indtast en gyldig Postnummer")]
        public virtual Postalcode PostalCode { get; set; }
        public int PostalCodeid { get; set; }
        [Required(ErrorMessage ="Indtast en adresse")]
        public string Adresses { get; set; }
    }
}
