using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Regele_Marius.Models
{
    public class ProgramareAnaliza
    {
        public int Id { get; set; }
        public int MedicId { get; set; }
        public int PacientId { get; set; }
        public int AnalizaId { get; set; }
        public DateTime DataProgramare { get; set; }
        public string OraInceput { get; set; }
        public string OraFinal { get; set; }
        public bool Glicemie { get; set; }
        public bool NumarLeucocite { get; set; }
        public bool NumarEritrocite { get; set; }
        public bool Hemoglobina { get; set; }
        public bool Hematrocit { get; set; }
        public bool VolumEritrocitarMediu { get; set; }
        public bool ConcentratieMedie { get; set; }
        public bool Trombocite { get; set; }
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
    }
}