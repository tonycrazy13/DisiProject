using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ClientesProfile> UserProfiles { get; set; }
    }

    [Table("Clientes")]
    public class ClientesProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        public int IdEstadoCliente { get; set; }
        public int IdOrigen { get; set; }
        public string TelPrincipal { get; set; }
        public string CorreoPrincipal { get; set; }
        public int IdTipoPersona { get; set; } 
        public string RazonSocial { get; set; } 
        public string RFC { get; set; }
        public string NombreComercial { get; set; }
        public string RegProveedor { get; set; }
        public DateTime FecAlta { get; set; }
        public DateTime FecMod { get; set; }
        public int IdUsuario { get; set; }
    }

   
    public class CrearClientesModel
    {
        
        [Required]
        [Display(Name = "Nombre Comercial")]
        public string NombreComercial { get; set; }

        [Required]
        [Display(Name = "Tel. Principal")]
        public string TelPrincipal { get; set; }

        [Required]
        [Display(Name = "Razon Social")]
        public string RazonSocial { get; set; }

        [Required]
        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Required]
        [Display(Name = "Reg. Proveedor")]
        public string RegProveedor { get; set; }
        
        [Required]
        [Display(Name = "Correo Electrónico")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Por favor valide su correo electronico")]
        [DataType(DataType.EmailAddress)]
        public string CorreoPrincipal { get; set; }

        public CrearClientesModel()
        {
            TiposPersona = new List<string>(new[] { "One", "Two" });
            CurrentItem = "Two";
        }

        public List<string> TiposPersona { get; set; }
        public string CurrentItem { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; }

        public string ReturnUrl { get; set; }     
    }
    
    public class EstadoClienteModel
    {
        public EstadoClienteModel()
        {
            EdosClientes = new List<string>(new[] { "One", "Two" });
            CurrentItem = "Two";
        }

        public List<string> EdosClientes { get; set; }
        public string CurrentItem { get; set; }
    }

    public class OrigenClienteModel
    {
        public OrigenClienteModel()
        {
            OrigenesCliente = new List<string>(new[] { "One", "Two" });
            CurrentItem = "Two";
        }

        public List<string> OrigenesCliente { get; set; }
        public string CurrentItem { get; set; }
    }

    public class TipoPersonaClienteModel
    {
        public TipoPersonaClienteModel()
        {
            TiposPersona = new List<string>(new[] { "One", "Two" });
            CurrentItem = "Two";
        }

        public List<string> TiposPersona { get; set; }
        public string CurrentItem { get; set; }
    }

    
}
