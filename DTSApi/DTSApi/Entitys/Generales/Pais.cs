using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    [Table("PAIS", Schema = "DTS_GENERALES")]
    public class Pais
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Estado> Estado { get; set; }
    }
}
