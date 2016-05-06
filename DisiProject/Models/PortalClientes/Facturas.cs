using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace DisiProject.Models.PortalClientes
{
    //[Table("Facturas")]
    public class Facturas
    {
        [Key]
        [Column("UUID")]
        public String Uuid { get; set; }
        [Column("XMLA")]
        public String Xml { get; set; }
        [Column("PDF")]
        public String Pdf { get; set; }

        //public virtual ICollection<Usuario> Usuarios { get; set; }
        //public virtual ICollection<UserProfile> UserProfiles { get; set; }
        //public virtual ICollection<Area> Areas { get; set; }
        //public virtual ICollection<Facturas> Facturas { get; set; }
        //public virtual ICollection<Saldo> Saldos { get; set; }

    }
}