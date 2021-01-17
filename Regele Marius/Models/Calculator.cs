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

        public int Id { get; set; }
        [DisplayFormat(NullDisplayText = "Sex")]
        public Sex Gen { get; set; }
        public int Greutate { get; set; }
        public double Inaltime { get; set; }
        [Range(1,100)]
        public int Varsta { get; set; }

    }
}