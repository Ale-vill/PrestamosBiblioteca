using System.Collections.Generic;

namespace PrestamosBiblioteca.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Institucion { get; set; }
        public string NivelAcademico { get; set; }
        public bool Genero { get; set; }
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }

        public IList<Prestamo> Prestamos { get; set; }

    }
}