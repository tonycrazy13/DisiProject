using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{


    [Table("CAT_ESTADO_CIVIL")]
    public class EstadoCivil
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ID_ESTADO_CIVIL")]
        public int IdEstadoCivil { get; set; }

        [Column("DES_ESTADO_CIVIL")]
        public string Descripcion { get; set; }

        [Column("CVE_ESTADO_CIVIL")]
        public string Clave { get; set; }        

        [Column("FEC_ALTA")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FecAlta { get; set; }

        [Column("FEC_MOD")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FecMod { get; set; }
     
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }
       
        [Column("ESTATUS")]
        public int Estatus { get; set; }
    }    
}
