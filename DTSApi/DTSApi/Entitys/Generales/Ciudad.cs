using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    public class Ciudad
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int SecuenciaEstado { get; set; }
        public Estado Estado { get; set; }
    }
}
