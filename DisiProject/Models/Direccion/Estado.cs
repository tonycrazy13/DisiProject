using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{


    [Table("CAT_ESTADOS")]
    public class Estado 
    {
        [Key]
        [Column("ID_ESTADO")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdEstado { get; set; }

        [Column("DES_ESTADO_CORTA")]
        [Required(ErrorMessage = "Ingrese descripción.")]
        public string DescripcionCorta { get; set; }

        [Column("DES_ESTADO_LARGA")]
        [Required(ErrorMessage = "Ingrese descripción.")]
        public string DescripcionLarga { get; set; }
    }    
}
