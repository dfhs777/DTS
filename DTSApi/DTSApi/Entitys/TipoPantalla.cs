using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    public class TipoPantalla
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Pantallas> Pantallas { get; set; }
    }
}
