using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    [Table("ROLESQUEMA", Schema = "DTS_SEGURIDAD")]
    public class RolEsquema
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public int SecuenciaPermiso { get; set; }
        public Permiso Permiso { get; set; }

        [Required]
        public int SecuenciaEsquema { get; set; }
        public Esquema Esquema { get; set; }

        [Required]
        public int SecuenciaRol { get; set; }
        public Rol Rol { get; set; }
    }
}
