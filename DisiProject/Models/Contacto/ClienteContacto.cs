﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
   

    [Table("clientes_contactos")]
    public class ClienteContacto
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }

        [Column("ID_CONTACTO")]
        public int IdContacto { get; set; }

        [Column("FEC_ALTA")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecAlta { get; set; }

        [Column("FEC_MOD")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecMod { get; set; }

        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("FLG_ESTATUS")]
        public int Estatus { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
        [ForeignKey("IdContacto")]
        public Contacto Contacto { get; set; }
    }    
}
