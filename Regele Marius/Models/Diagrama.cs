﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Regele_Marius.Models
{
    [DataContract]
    public class Diagrama
    {
        public int Id { get; set; }
        public Diagrama (string suprafata, double valoare)
        {
            this.Suprafata = suprafata;
            this.Valoare = valoare;
        }

        [DataMember(Name = "suprafata")]
        public string Suprafata = "";

        [DataMember(Name = "valoare")]
        public Nullable<double> Valoare = null;
    }
}