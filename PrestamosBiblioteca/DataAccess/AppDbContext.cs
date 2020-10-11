using Microsoft.EntityFrameworkCore;
using PrestamosBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosBiblioteca.DataAccess
{
    public class AppDbContext:DbContext
    {
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            Database.SetCommandTimeout(3600);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Codigo).IsUnique();
            modelBuilder.Entity<Marca>().HasData(DataSeeder.Marcas);
            modelBuilder.Entity<Equipo>().HasData(DataSeeder.Equipos);
            base.OnModelCreating(modelBuilder);
        }
    }

}
