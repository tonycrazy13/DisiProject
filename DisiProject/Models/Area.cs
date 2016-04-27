using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
    public class Area : DbContext
    {
        public Area()
            : base("DefaultConnection")
        {
        }

        public DbSet<Area> Area { get; set; }
    }


   

    [Table("Area")]
    public class Area
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdArea { get; set; }
        public String Descripcion { get; set; }
    }
   
 }
