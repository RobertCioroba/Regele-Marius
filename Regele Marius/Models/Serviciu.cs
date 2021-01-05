using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Serviciu
    {
        public int Id { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        public int Pret { get; set; }
    }
}