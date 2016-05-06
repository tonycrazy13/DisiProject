using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisiProject.Models.PortalClientes
{
    [Table("SALDO")]
    public class Saldo
    {
         [Column("SALDOCREDITO")]
         public int fiIdSaldoCredito { get; set; }

        [Column("DESCRIPCION")]
        public string fcDescripcion { get; set; }

        [Column("MONTOESTIMADO")]
        public decimal fdMontoEstimadoTrim { get; set; }

        [Column("MONTOESTIMADOANUAL")]
        public decimal fdMontoEstimadoAnual { get; set; }

        [Column("OBSERVACIONES")]
        public string fcObservaciones { get; set; }
    }
}