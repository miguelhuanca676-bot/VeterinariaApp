using System;
using System.Collections.Generic;
using System.IO;

namespace VeterinariaApp
{
    public static class ArchivoHelper
    {
        private static string archivo = "clientes.txt";

        public static void GuardarCliente(Cliente cliente)
        {
            using (StreamWriter sw = new StreamWriter(archivo, true))
            {
                foreach (var mascota in cliente.Mascotas)
                {
                    // Formato: CI|Nombre|Apellido|Edad|Telefono|Direccion|MascotaNombre|Raza|EdadMascota|Sexo|Diagnostico|Fecha
                    string linea = $"{cliente.CI}|{cliente.Nombre}|{cliente.Apellido}|{cliente.Edad}|{cliente.Telefono}|{cliente.Direccion}|{mascota.Nombre}|{mascota.Raza}|{mascota.Edad}|{mascota.Sexo}|{mascota.Diagnostico}|{mascota.FechaRegistro}";
                    sw.WriteLine(linea);
                }
            }
        }

        public static List<Mascota> BuscarPorCI(string ci)
        {
            List<Mascota> mascotas = new List<Mascota>();

            if (!File.Exists(archivo))
                return mascotas;

            string[] lineas = File.ReadAllLines(archivo);
            foreach (var linea in lineas)
            {
                string[] datos = linea.Split('|');
                if (datos[0] == ci)
                {
                    // Convertir Edad de mascota de string a int
                    int edadMascota = int.Parse(datos[8]);
                    string nombre = datos[6];
                    string raza = datos[7];
                    string sexo = datos[9];
                    string diagnostico = datos[10];
                    DateTime fecha = DateTime.Parse(datos[11]);

                    Mascota m = new Mascota(nombre, raza, edadMascota, sexo, diagnostico);
                    m.FechaRegistro = fecha;

                    mascotas.Add(m);
                }
            }

            return mascotas;
        }
    }
}
