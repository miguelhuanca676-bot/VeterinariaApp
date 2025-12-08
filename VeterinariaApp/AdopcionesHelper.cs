using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VeterinariaApp
{
    public static class AdopcionesHelper
    {
        private static string archivo = "adopciones.json";

        public static List<Adopcion> CargarAdopciones()
        {
            if (!File.Exists(archivo))
                return new List<Adopcion>();

            string json = File.ReadAllText(archivo);
            return JsonSerializer.Deserialize<List<Adopcion>>(json) ?? new List<Adopcion>();
        }

        public static void GuardarAdopciones(List<Adopcion> adopciones)
        {
            string json = JsonSerializer.Serialize(adopciones, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(archivo, json);
        }
    }
}
