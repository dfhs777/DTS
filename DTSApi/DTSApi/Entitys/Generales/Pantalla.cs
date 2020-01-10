using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    [Table("PANTALLA", Schema = "DTS_GENERALES")]
    public class Pantalla
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int SecuenciaTipoPantalla { get; set; }
        public TipoPantalla TipoPantalla { get; set; }

        [Required]
        public int SecuenciaEsquema { get; set; }
        public Esquema Esquema { get; set; }
    }
}
