using DTSServicios.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DTSServicios.Utils
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Pantalla> PantallaDbSet { get; set; }
        public DbSet<TipoPantalla> TipoPantallaDbSet { get; set; }
        public DbSet<Permiso> PermisoDbSet { get; set; }
        public DbSet<RolEsquema> RolEsquemaDbSet { get; set; }
        public DbSet<Rol> RolDbSet { get; set; }
        public DbSet<Esquema> EsquemaDbSet { get; set; }
        public DbSet<Pais> PaisDbSet { get; set; }
        public DbSet<Estado> EstadoDbSet { get; set; }
        public DbSet<Ciudad> CiudadDbSet { get; set; }
    }
}
