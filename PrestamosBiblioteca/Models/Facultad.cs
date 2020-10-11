using System.Collections.Generic;


namespace PrestamosBiblioteca.Models
{
    public class Facultad
    {
        public int FacultadId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public IList<Carrera> Carreras { get; set; }
    }
}
