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

        public DbSet<Contacto> Contacto { get; set; }
    }

    [Table("Contactos")]
    public class Contacto
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdContacto { get; set; }
        public int IdTipoPersona { get; set; }
        public int IdTipoContacto { get; set; }
        [Required(ErrorMessage = "Seleccione un Edo. Civil.")]
        public int IdEstadoCivil { get; set; }
        [Required(ErrorMessage = "Ingrese descripción del contacto.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese nombre 1.")]
        public string Nombre1 { get; set; }
        [Required(ErrorMessage = "Ingrese nombre 2.")]
        public string Nombre2 { get; set; }
        [Required(ErrorMessage = "Ingrese apellido paterno.")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Ingrese apellido materno.")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "Ingrese fecha nacimiento.")]
        public DateTime FecNacimiento { get; set; }
        [Required(ErrorMessage = "Ingrese correo personal.")]
        public string CorreoPersonal { get; set; }
        [Required(ErrorMessage = "Ingrese correo empresarial.")]
        public string CorreoEmpresarial { get; set; }
        [Required(ErrorMessage = "Ingrese telefono principal.")]
        public string TelPrincipal { get; set; }
        [Required(ErrorMessage = "Ingrese telefono móvil.")]
        public string TelMovil { get; set; }
        [Required(ErrorMessage = "Ingrese razón social.")]
        public string RazonSocial { get; set; }
        [Required(ErrorMessage = "Ingrese RFC.")]
        public string RFC { get; set; }
        [Required(ErrorMessage = "Ingrese sexo.")]
        public string Sexo { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecAlta { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecMod { get; set; }
        public int IdUsuario { get; set; }
        public int Estatus { get; set; }
    }    
}
