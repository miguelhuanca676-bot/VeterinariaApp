using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VeterinariaApp
{
    public static class MascotasHelper
    {
        private static string archivo = "mascotas.json";

        public static List<Mascota> CargarMascotas()
        {
            if (!File.Exists(archivo))
                return new List<Mascota>();

            string json = File.ReadAllText(archivo);
            return JsonSerializer.Deserialize<List<Mascota>>(json) ?? new List<Mascota>();
        }

        public static void GuardarMascotas(List<Mascota> mascotas)
        {
            string json = JsonSerializer.Serialize(mascotas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(archivo, json);
        }
    }
}
