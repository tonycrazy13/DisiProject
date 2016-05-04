using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
   
    [Table("CAT_PERMISOS")]
    public class Permiso
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
          [Column("ID_PERMISO")] 
             public int IdPermiso { get; set; }
        [Column("DES_PERMISO")]
        public string DesPermiso { get; set; }
    }

    
 }
