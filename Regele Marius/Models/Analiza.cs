using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class Analiza : Serviciu
    {
        public int Glicemie { get; set; }
        public int NumarLeucocite { get; set; }
        public int NumarEritrocite { get; set; }
        public int Hemoglobina { get; set; }
        public int Hematrocit { get; set; }
        public int VolumEritrocitarMediu { get; set; }
        public int ConcentratieMedie { get; set; }
        public int Trombocite { get; set; }
        public int VolumMediuTrombocitar { get; set; }
        public int Plachetocrit { get; set; }
        public int Monocite { get; set; }
        public int Neutrofile { get; set; }
        public int Eozinofile { get; set; }
        public int Bazofile { get; set; }
        public int Limfocite { get; set; }
        public int Colesterol { get; set; }
        public int Trigliceride { get; set; }
        public int Uree { get; set; }
        public int Creatinina { get; set; }
        public int Calciu { get; set; }
        public int Fier { get; set; }
        public int Magneziu { get; set; }
    }
}