using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    public class RolesEsquema
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public int SecuenciaPermiso { get; set; }
        public Permisos Permisos { get; set; }

        [Required]
        public int SecuenciaEsquemas { get; set; }
        public Esquemas Esquemas { get; set; }

        [Required]
        public int SecuenciaRol { get; set; }
        public Rol Rol { get; set; }
    }
}
