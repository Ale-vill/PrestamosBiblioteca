namespace PrestamosBiblioteca.Models
{
    public class Equipo
    {
        public int EquipoId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public bool Reservado { get; set; }
        public int MarcaId { get; set; }

        public Marca Marca { get; set; }


    }
}