using System;
using System.Collections.Generic;

namespace VeterinariaApp
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public Persona(string nombre, string apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        public abstract void MostrarInformacion();
    }

    public class Cliente : Persona
    {
        public string CI { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public List<Mascota> Mascotas { get; set; }

        public Cliente(string nombre, string apellido, int edad, string ci, string telefono, string direccion)
            : base(nombre, apellido, edad)
        {
            CI = ci;
            Telefono = telefono;
            Direccion = direccion;
            Mascotas = new List<Mascota>();
        }

        public void AgregarMascota(Mascota mascota) => Mascotas.Add(mascota);

        public override void MostrarInformacion()
        {
            Console.WriteLine($"Cliente: {Nombre} {Apellido}, CI: {CI}, Edad: {Edad}, Tel: {Telefono}, Dir: {Direccion}");
            foreach (var m in Mascotas)
                Console.WriteLine($"- {m.Nombre} ({m.Raza}, {m.Sexo}, {m.Edad} años) - Diagnóstico: {m.Diagnostico}, Fecha: {m.FechaRegistro}");
        }
    }

    public class Veterinario : Persona
    {
        public string Especialidad { get; set; }
        public int AñosExperiencia { get; set; }

        public Veterinario(string nombre, string apellido, int edad, string especialidad, int añosExperiencia)
            : base(nombre, apellido, edad)
        {
            Especialidad = especialidad;
            AñosExperiencia = añosExperiencia;
        }

        public void AtenderMascota(Mascota mascota) => Console.WriteLine($"{Nombre} está atendiendo a {mascota.Nombre}.");

        public override void MostrarInformacion()
        {
            Console.WriteLine($"Veterinario: {Nombre} {Apellido}, Edad: {Edad}, Especialidad: {Especialidad}, Experiencia: {AñosExperiencia} años");
        }
    }

    public class Mascota
    {
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Diagnostico { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Mascota(string nombre, string raza, int edad, string sexo, string diagnostico)
        {
            Nombre = nombre;
            Raza = raza;
            Edad = edad;
            Sexo = sexo;
            Diagnostico = diagnostico;
            FechaRegistro = DateTime.Now;
        }

        public override string ToString() => Nombre;
    }
}
