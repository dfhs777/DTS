using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTSServicios.Entitys
{
    [Table("ROL", Schema = "DTS_SEGURIDAD")]
    public class Rol
    {

        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }

        public List<RolEsquema> RolEsquema { get; set; }
    }
}