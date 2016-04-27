using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
    public class Permiso : DbContext
    {
        public Permiso()
            : base("DefaultConnection")
        {
        }

        public DbSet<Permiso> Permiso{ get; set; }
    }



    [Table("Cat_Permisos")]
    public class Permiso
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdPermiso { get; set; }
        public String desPermiso { get; set; }
    }

    
 }
