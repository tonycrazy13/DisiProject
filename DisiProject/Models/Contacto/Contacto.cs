using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
    [Table("CONTACTOS")]
    public class Contacto
    {
        [Key]
        [Column("ID_CONTACTO")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdContacto { get; set; }

        [Column("ID_TIPO_PERSONA")]
        public int IdTipoPersona { get; set; }

        [Column("ID__TIPO_CONTACTO")]
        public int IdTipoContacto { get; set; }

        [Column("ID_ESTADO_CIVIL")]
        [Required(ErrorMessage = "Seleccione un Edo. Civil.")]
        public int IdEstadoCivil { get; set; }

        [Column("DESC_CONTACTO")]
        [Display(Name = "Descripción del contacto")]
        [Required(ErrorMessage = "Ingrese descripción del contacto.")]
        public string Descripcion { get; set; }

        [Column("NOMBRE_1")]
        [Display(Name = "Nombre 1")]
        [Required(ErrorMessage = "Ingrese nombre 1.")]
        public string Nombre1 { get; set; }

        [Column("NOMBRE_2")]
        [Display(Name = "Nombre 2")]
        [Required(ErrorMessage = "Ingrese nombre 2.")]
        public string Nombre2 { get; set; }

        [Column("AP_PATERNO")]
        [Display(Name = "Apellido paterno")]
        [Required(ErrorMessage = "Ingrese apellido paterno.")]
        public string ApellidoPaterno { get; set; }

        [Column("AP_MATERNO")]
        [Display(Name = "Apellido materno")]
        [Required(ErrorMessage = "Ingrese apellido materno.")]
        public string ApellidoMaterno { get; set; }

        [Column("FEC_NAC")]
        [Display(Name = "Fecha nacimiento")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecNacimiento { get; set; }

        [Column("CORREO_PERSONAL")]
        [Display(Name = "Correo personal")]
        [Required(ErrorMessage = "Ingrese correo personal.")]
        public string CorreoPersonal { get; set; }

        [Column("CORREO_EMPRESARIAL")]
        [Display(Name = "Correo empresarial")]
        [Required(ErrorMessage = "Ingrese correo empresarial.")]
        public string CorreoEmpresarial { get; set; }

        [Column("TELEFONO")]
        [Display(Name = "Teléfono local")]
        [Required(ErrorMessage = "Ingrese telefono principal.")]
        public string TelPrincipal { get; set; }

        [Column("MOVIL")]
        [Display(Name = "Teléfono móvil")]
        [Required(ErrorMessage = "Ingrese telefono móvil.")]
        public string TelMovil { get; set; }

        [Column("RAZON_SOCIAL")]
        [Display(Name = "Razón social")]
        [Required(ErrorMessage = "Ingrese razón social.")]
        public string RazonSocial { get; set; }

        [Column("RFC")]
        [Display(Name = "RFC")]
        [Required(ErrorMessage = "Ingrese RFC.")]
        public string RFC { get; set; }

        [Column("SEXO")]
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Ingrese sexo.")]
        public string Sexo { get; set; }

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

        [ForeignKey("IdEstadoCivil")]
        public virtual EstadoCivil EstadoCivil { get; set; }

        [ForeignKey("IdTipoContacto")]
        public virtual TipoContacto TipoContacto { get; set; }

        [ForeignKey("IdTipoPersona")]
        public virtual TipoPersona TipoPersona { get; set; }
    }    
}
