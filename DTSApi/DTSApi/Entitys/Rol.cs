using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    public class Rol
    {

        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }

        public List<RolesEsquema> RolesEsquemas { get; set; }
    }
}