using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Regele_Marius.Models
{
    [DataContract]
    public class Diagrama
    {
        public Diagrama (string suprafata, double y)
        {
            this.Suprafata = suprafata;
            this.Y = y;
        }

        [DataMember(Name = "suprafata")]
        public string Suprafata = "";

        [DataMember(Name = "t")]
        public Nullable<double> Y = null;
    }
}