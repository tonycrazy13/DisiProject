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
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteContacto> ClientesContacto { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<TipoDireccion> TiposDireccion { get; set; }
        public DbSet<EstadoCliente> EdosCliente { get; set; }
        public DbSet<OrigenCliente> OrigenesCliente { get; set; }
        public DbSet<TipoPersona> TiposPersona { get; set; }
        public DbSet<TipoContacto> TiposContacto { get; set; }
        public DbSet<EstadoCivil> EstadosCivil { get; set; }
        public DbSet<CP> CPs { get; set; }
    }
}