using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
    public class Privilegios : DbContext
    {
        public Privilegios()
            : base("DefaultConnection")
        {
        }

        public DbSet<Privilegios> Privilegios { get; set; }
    }



    [Table("Cat_Privilegios")]
    public class Privilegios
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdPrivilegio { get; set; }
        public String descripcion { get; set; }
    }

    
 }
