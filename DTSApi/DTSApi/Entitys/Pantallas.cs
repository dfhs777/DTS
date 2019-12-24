using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    public class Pantallas
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int SecuenciaTipoPantalla { get; set; }
        public TipoPantalla TipoPantalla { get; set; }

        [Required]
        public int SecuenciaEsquemas { get; set; }
        public Esquemas Esquemas { get; set; }
    }
}
