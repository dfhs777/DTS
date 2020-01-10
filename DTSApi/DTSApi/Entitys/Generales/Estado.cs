using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DTSApi.Entitys
{
    [Table("ESTADO", Schema = "DTS_GENERALES")]
    public class Estado
    {
        [Key]
        public int Secuencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int SecuenciaPais { get; set; }
        public Pais Pais { get; set; }

        public List<Ciudad> Ciudad { get; set; }
    }
}
