using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    [Table("PERMISO", Schema = "DTS_SEGURIDAD")]
    public class Permisos
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public bool PermiteEditar { get; set; }
        [Required]
        public bool PermiteVista { get; set; }
        [Required]
        public bool PermiteEjecucion { get; set; }

        public List<RolesEsquema> RolesEsquemas { get; set; }
    }
}
