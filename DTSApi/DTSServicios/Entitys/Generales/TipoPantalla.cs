using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTSServicios.Entitys
{
    [Table("TIPOPANTALLA", Schema = "DTS_GENERALES")]
    public class TipoPantalla
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Pantalla> Pantalla { get; set; }
    }
}
