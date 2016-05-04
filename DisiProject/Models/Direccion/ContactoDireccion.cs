using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{


    [Table("CONTACTOS_DIRECCIONES")]
    public class ContactoDireccion
    {
        [Key]
        [Column("ID_CONTACTO")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdContacto { get; set; }

        [Column("ID_DIRECCION")]
        [Required(ErrorMessage = "Ingrese descripción.")]
        public string IdDireccion { get; set; }

        [Column("FEC_ALTA")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecAlta { get; set; }

        [Column("FEC_BAJA")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecBaja { get; set; }

        [Column("FEC_MOD")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecMod { get; set; }

        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("ESTATUS")]
        public int Estatus { get; set; }


    }    
}
