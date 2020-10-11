using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosBiblioteca.Models
{
    public class Facultad
    {
        public int FacultadId { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public IList<Carrera> Carreras { get; set; }
    }
}
