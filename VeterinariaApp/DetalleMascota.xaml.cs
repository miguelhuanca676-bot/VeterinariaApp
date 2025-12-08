using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace VeterinariaApp
{
    public partial class DetalleMascotaWindow : Window
    {
        private Mascota mascota;

        public DetalleMascotaWindow(Mascota mascota)
        {
            InitializeComponent();
            this.mascota = mascota;
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = mascota.Nombre;
            txtRaza.Text = "Raza: " + mascota.Raza;
            txtEdad.Text = "Edad: " + mascota.Edad + " años";
            txtSexo.Text = "Sexo: " + mascota.Sexo;
            txtObservaciones.Text = "Observaciones: " + mascota.Diagnostico;

            try
            {
                imgMascota.Source = new BitmapImage(new Uri(mascota.ImagenPath, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                // Imagen por defecto si falla
                imgMascota.Source = new BitmapImage(new Uri("imagenes/default.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void BtnAdoptar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarAdopcionWindow ventana = new RegistrarAdopcionWindow(mascota);
            ventana.ShowDialog();

            // Recargar las mascotas en la ventana principal después de adoptar
            if (ventana.DialogResult == true)
            {
                // Recargar la lista de mascotas desde JSON
                var ventanaPrincipal = Application.Current.Windows.OfType<AdopcionWindow>().FirstOrDefault();
                ventanaPrincipal?.RecargarMascotas();
                this.Close();
            }
        }

    }
}
