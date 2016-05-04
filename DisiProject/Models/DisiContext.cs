using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisiProject.Models
{
    //Coneccion Oracle DisiOperaciones-LGONZALEZ
    public class DisiContext : DbContext
    {

        public DisiContext() : base("OracleDisiContext")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DISIOPERACIONES");
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Area> Areas { get; set; }
        //public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Permiso> Permisos{ get; set; }
        public DbSet<AreaPrivilegio> AreasPrivilegio { get; set; }
    }
}