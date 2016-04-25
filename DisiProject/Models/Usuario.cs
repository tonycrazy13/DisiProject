using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace DisiProject.Models
{
    
    [Table("USUARIOS")]
    public class Usuario
    {
        [Column("ID_USUARIO")]
        public int id { get; set; }
        [Column("ID_AREA")]
        public int IdArea { get; set; }
        [Column("ID_EMPLEADO")]
        public int empleado { get; set; }
        [Column("USUARIO")]
        public string username { get; set; }
        [Column("CONTRASENA")]
        public string password { get; set; }
        [Column("CORREO")]
        public string correo { get; set; }
        [Column("FLG_ESTATUS")]
        public bool activo { get; set; }
        [Column("FECHA_CONTRASENIA")]
        public DateTime fechaContrasenia { get; set; }
        [Column("BLOQUEADO")]
        public bool bloqueado { get; set; }
        [Column("FECHA_BLOQUEADO")]
        public DateTime fechaBloqueado { get; set; }

        [ForeignKey("IdArea")]
        public virtual Area Area { get; set; }
    }
}