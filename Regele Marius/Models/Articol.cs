using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Articol
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Titlu { get; set; }
        public string Imagine { get; set; }
        public string Descriere { get; set; }
    }
}