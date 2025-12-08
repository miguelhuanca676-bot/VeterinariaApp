using System;
using System.Windows;
using Microsoft.Win32;
using System.Collections.Generic;

namespace VeterinariaApp
{
    public partial class AgregarMascotaWindow : Window
    {
        public AgregarMascotaWindow()
        {
            InitializeComponent();
        }

        private void BtnExaminar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == true)
            {
                txtImagenPath.Text = dlg.FileName;
            }
        }

        private void BtnAgregarMascota_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string raza = txtRaza.Text.Trim();
            string sexo = rbMacho.IsChecked == true ? "Macho" : "Hembra";
            int edad;

            if (!int.TryParse(txtEdad.Text.Trim(), out edad))
            {
                MessageBox.Show("Edad inválida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string observaciones = txtObservaciones.Text.Trim();
            string imagenPath = txtImagenPath.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(raza) || string.IsNullOrEmpty(imagenPath))
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Crear mascota
            Mascota nuevaMascota = new Mascota(nombre, raza, edad, sexo, observaciones)
            {
                ImagenPath = imagenPath
            };

            //  CARGAR lista desde JSON
            List<Mascota> lista = MascotasHelper.CargarMascotas();

            //  AGREGAR la nueva mascota
            lista.Add(nuevaMascota);

            //  GUARDAR en JSON
            MascotasHelper.GuardarMascotas(lista);

            MessageBox.Show("Mascota agregada correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
    }
}
