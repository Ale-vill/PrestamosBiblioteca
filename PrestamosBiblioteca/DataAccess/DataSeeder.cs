using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PrestamosBiblioteca.Models;
using System.Collections.Generic;
using System.IO;

namespace PrestamosBiblioteca.DataAccess
{
    public static class DataSeeder
    {
        public static readonly List<Marca> Marcas = new List<Marca> { 
            new Marca { MarcaId = 1, Nombre = "Dell" },
            new Marca { MarcaId = 2, Nombre = "Hp" },
            new Marca { MarcaId = 3, Nombre = "Acer" },
            new Marca { MarcaId = 4, Nombre = "Lenovo" },
            new Marca { MarcaId = 5, Nombre = "Asus" }
        };

        public static readonly List<Equipo> Equipos = new List<Equipo> {
            new Equipo{EquipoId=1,Codigo="Dell-01",Descripcion="Pc",Modelo="Dell G715",MarcaId=1}
        };

        public static IEnumerable<Carrera> GetCarreras(IHostEnvironment hosting)
        {
            var filepath = Path.Combine(hosting.ContentRootPath, @"DataAccess\Data\carreras.json");
            var json = JObject.Parse(File.ReadAllText(filepath));

            var carreras = JsonConvert.DeserializeObject<IEnumerable<Carrera>>(json["Carreras"]
                .ToString(Formatting.None));
            return carreras;
        }

        public static IEnumerable<Facultad> GetFacultades(IHostEnvironment hosting)
        {
            var filepath = Path.Combine(hosting.ContentRootPath, @"DataAccess\Data\facultades.json");
            var json = JObject.Parse(File.ReadAllText(filepath));

            var facultades = JsonConvert.DeserializeObject<IEnumerable<Facultad>>(json["Facultades"]
                .ToString(Formatting.None));
            return facultades;
        }
    }
}
