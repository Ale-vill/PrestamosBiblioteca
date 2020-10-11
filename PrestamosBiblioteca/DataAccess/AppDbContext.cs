using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PrestamosBiblioteca.Models;

namespace PrestamosBiblioteca.DataAccess
{
    public sealed class AppDbContext:DbContext
    {
        private readonly IHostEnvironment _hostEnvironment;
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options,IHostEnvironment hostEnvironment) : base(options)
        {
            _hostEnvironment = hostEnvironment;
            Database?.SetCommandTimeout(3600);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Codigo).IsUnique();
            modelBuilder.Entity<Marca>().HasData(DataSeeder.Marcas);
            modelBuilder.Entity<Equipo>().HasData(DataSeeder.Equipos);
            modelBuilder.Entity<Equipo>().Property(e => e.Disponibilidad).HasDefaultValue(true);
            modelBuilder.Entity<Carrera>().HasData(DataSeeder.GetCarreras(_hostEnvironment));

            base.OnModelCreating(modelBuilder);
        }
    }

}
