using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTSApi.Entitys
{
    [Table("ESQUEMAS", Schema = "DTS_GENERALES")]
    public class Esquemas
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Pantallas> Pantallas { get; set; }
        public List<RolesEsquema> RolesEsquemas { get; set; }
    }
}
