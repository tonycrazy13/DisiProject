using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
    public class Usuario : DbContext
    {
        public Usuario()
            : base("DefaultConnection")
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
    }

    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        public int IdArea { get; set; }
        public int IdEmpleado { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public int Estatus { get; set; }
    }

   
 }
