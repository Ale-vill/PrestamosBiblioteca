using System.Collections.Generic;

namespace PrestamosBiblioteca.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre { get; set; }
        public IList<Equipo> Equipos { get; set; }
    }
}