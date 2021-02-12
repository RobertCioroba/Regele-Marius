using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class RezultatInterventie
    {
        public int Id { get; set; }
        [Display(Name = "Nume Medic")]
        public int MedicId { get; set; }
        public int PacientId { get; set; }
        [Display(Name = "Analiza")]
        public int InterventieId { get; set; }

        public enum Sex3
        {
            Masculin, Feminin
        }
        [DataType(DataType.Date)]
        public DateTime DataNastere { get; set; }
        public int NrTelefon { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public Sex3 Gen { get; set; }

        public string Denumire { get; set; }
        public string Descriere { get; set; }
        public int Pret { get; set; }

        public string Echipament { get; set; }
        public string Durata { get; set; }
        public bool Succes { get; set; }

        public virtual Medic Medic { get; set; }
        public virtual Pacient Pacient { get; set; }
        public virtual Interventie Interventie { get; set; }
    }
}