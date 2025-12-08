using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VeterinariaApp
{
    public static class ArchivoDoctores
    {
        private static string ruta = "doctores.txt";

        // Guardar un doctor
        public static void GuardarDoctor(Veterinario v)
        {
            string linea = $"{v.Nombre}|{v.Apellido}|{v.Edad}|{v.Especialidad}|{v.AñosExperiencia}";
            File.AppendAllLines(ruta, new[] { linea });
        }

        // Cargar doctores
        public static List<Veterinario> CargarDoctores()
        {
            List<Veterinario> lista = new List<Veterinario>();

            if (!File.Exists(ruta))
                return lista;

            foreach (var linea in File.ReadAllLines(ruta))
            {
                string[] datos = linea.Split('|');
                if (datos.Length == 5)
                {
                    Veterinario v = new Veterinario(
                        datos[0],                       // nombre
                        datos[1],                       // apellido
                        int.Parse(datos[2]),            // edad
                        datos[3],                       // especialidad
                        int.Parse(datos[4])             // experiencia
                    );
                    lista.Add(v);
                }
            }

            return lista;
        }

        // Eliminar doctor del archivo
        public static void EliminarDoctor(Veterinario doctor)
        {
            if (!File.Exists(ruta))
                return;

            var lineas = File.ReadAllLines(ruta).ToList();

            string lineaEliminar = $"{doctor.Nombre}|{doctor.Apellido}|{doctor.Edad}|{doctor.Especialidad}|{doctor.AñosExperiencia}";

            lineas.Remove(lineaEliminar);

            File.WriteAllLines(ruta, lineas);
        }
    }
}
