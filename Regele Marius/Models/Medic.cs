using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public enum Schimb
    {
        Unu,
        Doi
    }

    public class Medic
    {
        public int Id { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public string Prenume { get; set; }
        public int? SpecializareId { get; set; }
        [Display(Name ="Specializare")]
        public Specializare Specializare { get; set; }

        public Schimb Schimb { get; set; }

        public int UserId { get; set; }
        public int ProgramId { get; set; }
        public virtual ICollection<ProgramareInterventie> ProgramariInterventie { get; set; }
        public virtual ICollection<RezultatAnaliza> RezultateAnaliza { get; set; }
        public virtual ICollection<RezultatInterventie> RezultateInterventie { get; set; }
    }
}