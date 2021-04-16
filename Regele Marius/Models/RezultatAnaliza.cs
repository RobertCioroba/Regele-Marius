using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class RezultatAnaliza
    {
        public int Id { get; set; }
        [Display(Name = "Nume Medic")]
        public int? MedicId { get; set; }
        public int? PacientId { get; set; }
        [Display(Name = "Analiza")]
        public int? AnalizaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataNastere { get; set; }
        public int? NrTelefon { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public Sex Gen { get; set; }
        public string NumePacient { get; set; }
        public string PrenumePacient { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        public int? Pret { get; set; }

        public int? Glicemie { get; set; }
        public int? NumarLeucocite { get; set; }
        public int? NumarEritrocite { get; set; }
        public int? Hemoglobina { get; set; }
        public int? Hematrocit { get; set; }
        public int? VolumEritrocitarMediu { get; set; }
        public int? ConcentratieMedie { get; set; }
        public int? Trombocite { get; set; }
        public int? VolumMediuTrombocitar { get; set; }
        public int? Plachetocrit { get; set; }
        public int? Monocite { get; set; }
        public int? Neutrofile { get; set; }
        public int? Eozinofile { get; set; }
        public int? Bazofile { get; set; }
        public int? Limfocite { get; set; }
        public int? Colesterol { get; set; }
        public int? Trigliceride { get; set; }
        public int? Uree { get; set; }
        public int? Creatinina { get; set; }
        public int? Calciu { get; set; }
        public int? Fier { get; set; }
        public int? Magneziu { get; set; }

        public virtual Medic Medic { get; set; }
        public virtual Pacient Pacient { get; set; }
        public virtual Analiza Analiza { get; set; }

        [Display(Name = "Nume pacient")]
        public string NumeComplet
        {
            get
            {
                return NumePacient + " " + PrenumePacient;
            }
        }
    }
}