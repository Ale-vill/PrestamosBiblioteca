using System.Collections.Generic;

namespace PrestamosBiblioteca.Models
{
    public class Carrera
    {

        public int CarreraId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int FacultadId { get; set; }
        public Facultad Facultad { get; set; }

        public IList<Usuario> Usuarios { get; set; }



    }
}