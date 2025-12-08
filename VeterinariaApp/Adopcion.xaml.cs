using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace VeterinariaApp
{
    public partial class AdopcionWindow : Window
    {
        private List<Mascota> mascotasDisponibles;

        public AdopcionWindow()
        {
            InitializeComponent();

            // Cargar desde archivo JSON
            mascotasDisponibles = MascotasHelper.CargarMascotas();

            CargarMascotas();
        }

        private void CargarMascotas()
        {
            wpMascotas.Children.Clear();

            foreach (var mascota in mascotasDisponibles)
            {
                Button btn = new Button
                {
                    Width = 150,
                    Height = 150,
                    Margin = new Thickness(5),
                    Tag = mascota
                };

                Image img = new Image
                {
                    Source = new BitmapImage(new Uri(mascota.ImagenPath, UriKind.RelativeOrAbsolute)),
                    Stretch = System.Windows.Media.Stretch.UniformToFill
                };

                btn.Content = img;
                btn.Click += BtnMascota_Click;

                wpMascotas.Children.Add(btn);
            }
        }

        private void BtnMascota_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Mascota mascota)
            {
                DetalleMascotaWindow detalle = new DetalleMascotaWindow(mascota);
                detalle.ShowDialog();
            }
        }

        private void BtnAgregarMascota_Click(object sender, RoutedEventArgs e)
        {
            AgregarMascotaWindow ventana = new AgregarMascotaWindow();

            ventana.ShowDialog();
            // Guardar en archivo JSON
            mascotasDisponibles = MascotasHelper.CargarMascotas();

            // Actualizar vista
            CargarMascotas();
            
        }
        public void RecargarMascotas()
        {
            mascotasDisponibles = MascotasHelper.CargarMascotas();
            CargarMascotas();
        }

        private void BtnVerAdopciones_Click(object sender, RoutedEventArgs e)
        {
            VerAdopcionesWindow ventana = new VerAdopcionesWindow();
            ventana.ShowDialog();
        }




    }
}
