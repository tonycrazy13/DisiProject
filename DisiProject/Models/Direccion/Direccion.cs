using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
   

    [Table("DIRECCIONES")]
    public class Direccion
    {
        [Key]
        [Column("ID_DIRECCION")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdDireccion { get; set; }

        [Column("CALLE")]
        [Display(Name = "Calle")]
        [Required(ErrorMessage = "Ingrese calle.")]
        public string Calle { get; set; }

        [Column("NO_EXTERIOR")]
        [Display(Name = "No. Exterior")]
        [Range(1, 5)]
        [Required(ErrorMessage = "Ingrese No. Exterior.")]
        public string Interior { get; set; }

        [Column("NO_INTERIOR")]
        [Display(Name = "No. Interior")]
        [Range(1, 5)]
        [Required(ErrorMessage = "Ingrese No. Interior.")]
        public string Exterior { get; set; }

        [Column("ID_TIPO_DIRECCION")]
        [Display(Name = "Tipo dirección")]
        public int IdTipoDireccion { get; set; }

        [Column("CP")]
        [Display(Name = "CP")]
       //[Required(ErrorMessage = "Ingrese CP.")]
        public int idCP { get; set; }

        [Display(Name = "CP")]
        [Required(ErrorMessage = "Ingrese CP string.")]
        public string StringCP { get; set; }

        [Column("ANT_ANO")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Año")]
        public DateTime AntAnio { get; set; }

        [Column("ANT_MES")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Mes")]
        public DateTime AntMes { get; set; }

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

        [ForeignKey("idCP")]
        public virtual CP CP { get; set; }
    }    
}
