using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{


    [Table("CAT_TIPOS_CONTACTOS")]
    public class TipoContacto
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ID__TIPO_CONTACTO")]
        public int IdTipoContacto { get; set; }

        [Column("DES_CONTACTO_LARGA")]
        public string DescripcionLarga { get; set; }

        [Column("DES_CONTACTO_CORTA")]
        public string DescripcionCorta { get; set; }        

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
