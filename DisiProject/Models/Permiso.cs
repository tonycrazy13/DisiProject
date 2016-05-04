using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
    [Table("Cat_Permisos")]
    public class Permiso
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdPermiso { get; set; }
        public String desPermiso { get; set; }
    }

    
 }
