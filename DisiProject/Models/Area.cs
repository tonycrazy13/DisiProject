using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
    [Table("CAT_AREAS")]
    public class Area
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ID_AREA")]
        public int ID { get; set; }
        [Column("DES_AREA")]
        public string DESCRIPCION { get; set; }
    }
}