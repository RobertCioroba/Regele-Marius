using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public enum Durata
    {
        [Display(Name ="0:30h")]
        JumatateDeOra,
        [Display(Name ="1:00h")]
        Ora,
        [Display(Name = "1:30h")]
        Ora30,
        [Display(Name = "2:00h")]
        DouaOre
    }

    public class Analiza : Serviciu
    {
        public bool Glicemie { get; set; }
        [Display(Name = "Numar leucocite")]
        public bool NumarLeucocite { get; set; }
        [Display(Name = "Numar eritrocite")]
        public bool NumarEritrocite { get; set; }
        public bool Hemoglobina { get; set; }
        public bool Hematrocit { get; set; }
        [Display(Name = "Volum eritrocitar mediu")]
        public bool VolumEritrocitarMediu { get; set; }
        [Display(Name = "Concentratie medie")]
        public bool ConcentratieMedie { get; set; }
        public bool Trombocite { get; set; }
        [Display(Name = "Volum mediu trombocitar")]
        public bool VolumMediuTrombocitar { get; set; }
        public bool Plachetocrit { get; set; }
        public bool Monocite { get; set; }
        public bool Neutrofile { get; set; }
        public bool Eozinofile { get; set; }
        public bool Bazofile { get; set; }
        public bool Limfocite { get; set; }
        public bool Colesterol { get; set; }
        public bool Trigliceride { get; set; }
        public bool Uree { get; set; }
        public bool Creatinina { get; set; }
        public bool Calciu { get; set; }
        public bool Fier { get; set; }
        public bool Magneziu { get; set; }
        [Display(Name = "Specializare")]
        public int? SpecializareId { get; set; }
        [Display(Name = "Specializare")]
        public Specializare Specializare { get; set; }
        public Durata Durata { get; set; }

        public virtual ICollection<ProgramareAnaliza> ProgramariAnaliza { get; set; }
        public virtual ICollection<RezultatAnaliza> RezultateAnaliza { get; set; }
    }
}