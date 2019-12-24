using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTSApi.Models;
using DTSApi.Entitys;

namespace DTSApi.Utils
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Esquemas> Esquemas { get; set; }
        public DbSet<TipoPantalla> TipoPantallas { get; set; }
        public DbSet<Pantallas> Pantallas { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<RolesEsquema> RolesEsquemas { get; set; }
        public DbSet<Rol> Rol { get; set; }
    }
}
