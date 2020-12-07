using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Medic : Utilizator
    {
        public int SpecializareId { get; set; }
        [Display(Name ="Specializare")]
        public Specializare Specializare { get; set; }
        [Display(Name = "Inceput luni")]
        public string LuniInceput { get; set; }
        [Display(Name = "Final luni")]
        public string LuniFinal { get; set; }
        [Display(Name = "Inceput marti")]
        public string MartiInceput { get; set; }
        [Display(Name = "Final marti")]
        public string MartiFinal { get; set; }
        [Display(Name = "Inceput miercuri")]
        public string MiercuriInceput { get; set; }
        [Display(Name = "Final miercuri")]
        public string MiercuriFinal { get; set; }
        [Display(Name = "Inceput joi")]
        public string JoiInceput { get; set; }
        [Display(Name = "Final joi")]
        public string JoiFinal { get; set; }
        [Display(Name = "Inceput vineri")]
        public string VineriInceput { get; set; }
        [Display(Name = "Final vineri")]
        public string VineriFinal { get; set; }
    }
}