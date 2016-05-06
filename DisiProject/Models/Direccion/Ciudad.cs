using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{


    [Table("CAT_CIUDADES")]
    public class Ciudad 
    {
        [Key]
        [Column("ID_CIUDAD")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdCiudad { get; set; }

        [Column("DES_CIUDAD_CORTA")]
        [Required(ErrorMessage = "Ingrese descripción.")]
        public string DescripcionCorta { get; set; }

        [Column("DES_CIUDAD_LARGA")]
        [Required(ErrorMessage = "Ingrese descripción.")]
        public string DescripcionLarga { get; set; }
    }    
}
