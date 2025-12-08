using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace VeterinariaApp
{
    public partial class VerDonacionesWindow : Window
    {
        private string archivoDonaciones = "donaciones.txt";

        public VerDonacionesWindow()
        {
            InitializeComponent();
            CargarDonaciones();
        }

        private void CargarDonaciones()
        {
            if (!File.Exists(archivoDonaciones))
            {
                MessageBox.Show("No hay donaciones registradas.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            List<Donacion> lista = new List<Donacion>();
            foreach (var linea in File.ReadAllLines(archivoDonaciones))
            {
                string[] datos = linea.Split('|');
                if (datos.Length >= 4)
                {
                    lista.Add(new Donacion
                    {
                        Nombre = datos[0],
                        MontoArticulo = datos[1],
                        Fecha = datos[2],
                        Observaciones = datos[3]
                    });
                }
            }

            dgDonaciones.ItemsSource = lista;
        }
    }

    public class Donacion
    {
        public string Nombre { get; set; }
        public string MontoArticulo { get; set; }
        public string Fecha { get; set; }
        public string Observaciones { get; set; }
    }
}
