using System;

namespace PrestamosBiblioteca.Models
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }
        public DateTime Entrega { get; set; }
        public DateTime Devolucion { get; set; }
        public string Observacion { get; set; }
        public int UsuarioId { get; set; }
        public int EquipoId { get; set; }

        public Equipo Equipo { get; set; }


    }
}