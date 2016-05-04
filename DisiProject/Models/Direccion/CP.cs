using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{


    [Table("CODIGOS_POSTALES")]
    public class CP
    {
        [Key]
        [Column("ID_CP")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdCP { get; set; }

        [Column("CP")]
        [Required(ErrorMessage = "Ingrese CP.")]
        public string cp { get; set; }

        [Column("ID_MUNICIPIO")]
        public int IdMunicipio { get; set; }

        [Column("ID_CIUDAD")]
         public int IdCiudad { get; set; }

        [Column("DES_COLONIA")]
        public string DescripcionColonia { get; set; }

        [ForeignKey("IdMunicipio")]
        public virtual Municipio Municipio { get; set; }

        [ForeignKey("IdCiudad")]
        public virtual Ciudad Ciudad { get; set; }
    }    
}
