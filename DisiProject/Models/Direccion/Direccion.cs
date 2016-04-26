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

        public DbSet<Direccion> Direccion { get; set; }
    }

    [Table("Direcciones")]
    public class Direccion
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdDireccion { get; set; }
        [Required(ErrorMessage = "Ingrese calle.")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "Ingrese No. Exterior.")]
        public string Interior { get; set; }
        [Required(ErrorMessage = "Ingrese No. Interior.")]
        public string Exterior { get; set; }
        public int IdTipoDireccion { get; set; }
        [Required(ErrorMessage = "Ingrese CP.")]
        public string CP { get; set; }
        public int AntAnio { get; set; }
        public int AntMes { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecAlta { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FecMod { get; set; }
        public int IdUsuario { get; set; }
        public int Estatus { get; set; }
    }    
}
