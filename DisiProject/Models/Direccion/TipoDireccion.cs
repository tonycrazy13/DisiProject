﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{


    [Table("CAT_TIPO_DIRECCION")]
    public class TipoDireccion
    {
        [Key]
        [Column("ID_TIPO_DIRECCION")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdTipoDireccion { get; set; }

        [Column("DES_TIPO_DIRECCION")]
        [Required(ErrorMessage = "Ingrese descripción.")]
        public string Descripcion { get; set; }

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


    }    
}
