using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DisiProject.Models
{
    [Table("CAT_AREAS")]
    public class Area
    {
        [Column("ID_AREA")]
        public int ID { get; set; }
        [Column("DES_AREA")]
        public string DESCRIPCION { get; set; }
    }
}