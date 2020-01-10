using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTSApi.Entitys
{
    [Table("ESQUEMA", Schema = "DTS_GENERALES")]
    public class Esquema
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Pantalla> Pantalla { get; set; }
        public List<RolEsquema> RolEsquema { get; set; }
    }
}
