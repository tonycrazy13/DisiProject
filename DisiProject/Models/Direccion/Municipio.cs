using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{


    [Table("MUNICIPIOS")]
    public class Municipio
    {
        [Key]
        [Column("ID_MUNICIPIO")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdMunicipio { get; set; }

        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }

        [Column("DES_CORTA")]
        [Required(ErrorMessage = "Ingrese descripción.")]
        public string DescripcionCorta { get; set; }
        
        [Column("DES_LARGA")]
        [Required(ErrorMessage = "Ingrese descripción.")]
        public string DescripcionLarga { get; set; }

        [ForeignKey("IdEstado")]
        public virtual Estado Estado { get; set; }
    }    
}
