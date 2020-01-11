using System.ComponentModel.DataAnnotations;

namespace DTSServicios.Entitys
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
