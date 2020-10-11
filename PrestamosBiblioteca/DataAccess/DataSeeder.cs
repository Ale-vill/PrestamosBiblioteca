using PrestamosBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosBiblioteca.DataAccess
{
    public static class DataSeeder
    {
        public static List<Marca> Marcas = new List<Marca> { 
            new Marca { MarcaId = 1, Nombre = "Dell" },
            new Marca { MarcaId = 2, Nombre = "Hp" },
            new Marca { MarcaId = 3, Nombre = "Acer" },
            new Marca { MarcaId = 4, Nombre = "Lenovo" },
            new Marca { MarcaId = 5, Nombre = "Asus" }
        };

        public static List<Equipo> Equipos = new List<Equipo> {
            new Equipo{EquipoId=1,Codigo="Dell-01",Descripcion="Pc",Modelo="Dell G715",MarcaId=1}
        };
    }
}
