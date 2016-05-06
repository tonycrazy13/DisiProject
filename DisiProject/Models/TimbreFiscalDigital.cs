using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisiProject.Models
{
    public class TimbreFiscalDigital
    {
        public string VersionTimbre { get; set; }

        public DateTime FechaTimbrado { get; set; }

        public string SelloCfd { get; set; }

        public string NoCertificadoSat { get; set; }

        public string SelloSat { get; set; }

        public string UUid { get; set; }
    }
}