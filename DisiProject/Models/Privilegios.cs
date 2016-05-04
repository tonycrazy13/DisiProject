using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace DisiProject.Models
{

    

    [Table("CAT_PRIVILEGIOS")]
    public class Privilegio
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]      
        public int ID_PRIVILEGIO { get; set; }
       public string DESCRIPCION{ get; set; }
       
    }

    public class CrearPrivilegios
    {

        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [Display(Name = "Area")]
        public int Area { get; set; }


        public IEnumerable<Area> Areas { get; set; }
        public int SelectedAreas { get; set; }

        public IEnumerable<Privilegio> Privilegios { get; set; }
        public int SelectedPrivilegios { get; set; }

        public IEnumerable<Permiso> Permisos { get; set; }
        public int SelectedPermisos { get; set; }

        public IEnumerable<AreaPrivilegio> AreasPrivilegios { get; set; }
    }

   
   
 }
