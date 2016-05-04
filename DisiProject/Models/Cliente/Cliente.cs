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

        public DbSet<Cliente> ClienteProfile { get; set; }
    }

    [Table("CLIENTES")]
    public class Cliente
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }

        [Column("ID_ESTADO_CLIENTE")]
        [Required(ErrorMessage = "Seleccione un Edo.")]        
        public int IdEstadoCliente { get; set; }

        [Column("ID_ORIGEN")]
        [Required(ErrorMessage = "Seleccione un origen.")]
        public int IdOrigen { get; set; }

        [Column("TEL_PRINCIPAL")]
        [Display(Name = "Tel. Principal")]
        [Required(ErrorMessage = "Ingrese telefono principal.")]
        public string TelPrincipal { get; set; }

        [Column("CORREO_PRINCIPAL")]
        [Display(Name = "Correo Electrónico")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Por favor valide su correo electronico")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Ingrese correo principal.")]
        public string CorreoPrincipal { get; set; }

        [Column("ID_TIPO_PERSONA")]
        [Required(ErrorMessage = "Seleccione tipo de persona.")]
        public int IdTipoPersona { get; set; }

        [Column("RAZON_SOCIAL")]
        [Display(Name = "Razon Social")]
        [Required(ErrorMessage = "Ingrese razón social.")]
        public string RazonSocial { get; set; }

        [Column("RFC")]
        [Display(Name = "RFC")]
        [Required(ErrorMessage = "Ingrese RFC.")]
        public string RFC { get; set; }

        [Column("NOMBRE_COMERCIAL")]
        [Display(Name = "Nombre Comercial")]
        [Required(ErrorMessage = "Ingrese nombre comercial.")]
        public string NombreComercial { get; set; }

        [Column("REG_PROVEEDOR")]
        [Display(Name = "Reg. Proveedor")]
        [Required(ErrorMessage = "Ingrese reg. Cliente")]
        public string RegProveedor { get; set; }

        [Column("FEC_ALTA")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecAlta { get; set; }

        [Column("FEC_MOD")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecMod { get; set; }

        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("ESTATUS")]
        public int Estatus { get; set; }

        [ForeignKey("IdEstadoCliente")]
        public virtual EstadoCliente EstadoCliente { get; set; }

        [ForeignKey("IdOrigen")]
        public virtual OrigenCliente OrigenCliente { get; set; }

        [ForeignKey("IdTipoPersona")]
        public virtual TipoPersona TipoPersona { get; set; }
    }       
}
