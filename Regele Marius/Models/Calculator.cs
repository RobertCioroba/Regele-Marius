using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Calculator
    {
        public enum Sex
        {
            Masculin, Feminin
        }

        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayFormat(NullDisplayText = "Sex")]
        public Sex Gen { get; set; }
        [Required]
        public int Greutate { get; set; }
        [Required]
        public double Inaltime { get; set; }
        [Required]
        [Range(1,100)]
        public int Varsta { get; set; }

    }
}