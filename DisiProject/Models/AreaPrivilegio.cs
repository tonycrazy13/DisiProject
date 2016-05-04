using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{
    [Table("Permisos_Usuarios")]
    public class AreaPrivilegio
    {
        [Key]
        public int IdUsuario { get; set; }
        public int IdPermiso { get; set; }
        public int IdPrivilegio { get; set; }
    }


      

    public class CrearPrivilegios
    {

        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [Display(Name = "Area")]
        public int Area { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        public int Empleado { get; set; }

        [Required]
        [Display(Name = "Permisos")]
        public int Permisos { get; set; }

        public List<string> Areas { get; set; }
        public string CurrentItem { get; set; }

        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; }

    }
      
    

 }
