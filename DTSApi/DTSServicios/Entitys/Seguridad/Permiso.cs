﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTSServicios.Entitys
{
    [Table("PERMISO", Schema = "DTS_SEGURIDAD")]
    public class Permiso
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

        public List<RolEsquema> RolesEsquemas { get; set; }
    }
}
