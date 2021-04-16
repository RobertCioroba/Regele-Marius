﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
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
        [DataType(DataType.Time)]
        [Display(Name = "Inceput luni")]
        public DateTime? LuniInceput { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Final luni")]
        public DateTime? LuniFinal { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Inceput marti")]
        public DateTime? MartiInceput { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Final marti")]
        public DateTime? MartiFinal { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Inceput miercuri")]
        public DateTime? MiercuriInceput { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Final miercuri")]
        public DateTime? MiercuriFinal { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Inceput joi")]
        public DateTime? JoiInceput { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Final joi")]
        public DateTime? JoiFinal { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Inceput vineri")]
        public DateTime? VineriInceput { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Final vineri")]
        public DateTime? VineriFinal { get; set; }

        public int UserId { get; set; }
        public virtual ICollection<ProgramareInterventie> ProgramariInterventie { get; set; }
        public virtual ICollection<RezultatAnaliza> RezultateAnaliza { get; set; }
        public virtual ICollection<RezultatInterventie> RezultateInterventie { get; set; }
    }
}