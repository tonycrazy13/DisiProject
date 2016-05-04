using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
   
    [Table("AREA_PRIVILEGIO")]
    public class AreaPrivilegio
    {   
        [Key]
        [Column("ID_AREA")]
        public int IdArea { get; set; }

        [Column("ID_PERMISO")]
        public int IdPermiso { get; set; }
  
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

        //navigation
        [ForeignKey("IdArea")]
        public virtual Area Area { get; set; }
        [ForeignKey("IdPermiso")]
        public virtual Permiso Permiso { get; set; }

    
    }
 }
