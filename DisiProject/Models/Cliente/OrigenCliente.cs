using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
    [Table("CAT_ORIGENES")]
    public class OrigenCliente
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ID_ORIGEN")]
        public int IdOrigenCliente { get; set; }

        [Column("DESC_ORIGEN")]
        public string Descripcion { get; set; }

        [Column("FEC_ALTA")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecAlta { get; set; }

        [Column("FEC_MOD")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecMod { get; set; }

        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("ESTATUS")]
        public int Estatus { get; set; }
    }    
}
