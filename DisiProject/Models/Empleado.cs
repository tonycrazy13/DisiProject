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
        public int ID { get; set; }
        [Column("ID_DIRECCION")]
        public int direccionId { get; set; }
        [Column("ID_ESTADO_CIVIL")]
        public int estadoCivilId { get; set; }
        [Column("PUESTO")]
        public string puesto { get; set; }
        [Column("NOMBRE_1")]
        public string nombre1 { get; set; }
        [Column("NOMBRE_2")]
        public string nombre2 { get; set; }
        [Column("AP_PATERNO")]
        public string paterno { get; set; }
        [Column("AP_MATERNO")]
        public int materno { get; set; }
        [Column("FEC_NAC")]
        public DateTime fechaNacimiento { get; set; }
        [Column("CORREO_EMPRESARIAL")]
        public int correoEmpresarial { get; set; }
        [Column("TELEFONO")]
        public int telefono { get; set; }
        [Column("MOVIL")]
        public int movil { get; set; }
        [Column("SEXO")]
        public int sexo { get; set; }
        [Column("RFC")]
        public int rfc { get; set; }
        [Column("TIPO_EMPLEADO")]
        public int tipoEmpleado { get; set; }

    }
}