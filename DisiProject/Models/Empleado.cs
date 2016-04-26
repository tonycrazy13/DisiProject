using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace DisiProject.Models
{
    [Table("EMPLEADOS")]
    public class Empleado
    {
        [Column("ID_EMPLEADO")]
        public int IdEmpleado { get; set; }
        [Column("ID_DIRECCION")]
        public int IdDireccion { get; set; }
        [Column("ID_ESTADO_CIVIL")]
        public int IdEstadoCivil { get; set; }
        [Column("PUESTO")]
        public int Puesto { get; set; }
        [Column("NOMBRE_1")]
        public string Nombre1 { get; set; }
        [Column("NOMBRE_2")]
        public string Nombre2 { get; set; }
        [Column("AP_PATERNO")]
        public string Paterno { get; set; }
        [Column("AP_MATERNO")]
        public int Materno { get; set; }
        [Column("FEC_NAC")]
        public DateTime FechaNacimiento { get; set; }
        [Column("CORREO_EMPRESARIAL")]
        public string CorreoEmpresarial { get; set; }
        [Column("TELEFONO")]
        public string Telefono { get; set; }
        [Column("MOVIL")]
        public string Movil { get; set; }
        [Column("SEXO")]
        public bool Sexo { get; set; }
        [Column("RFC")]
        public int Rfc { get; set; }
        [Column("TIPO_EMPLEADO")]
        public int TipoEmpleado { get; set; }

    }
}