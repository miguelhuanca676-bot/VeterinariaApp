using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace VeterinariaApp
{
    public partial class RegistrarAdopcionWindow : Window
    {
        private Mascota mascotaSeleccionada;

        public RegistrarAdopcionWindow(Mascota mascota)
        {
            InitializeComponent();

            // Asignar la mascota seleccionada
            mascotaSeleccionada = mascota;

            // Mostrar nombre de la mascota
            txtNombreMascota.Text = mascotaSeleccionada.Nombre;

            // Fecha por defecto: hoy
            dpFecha.SelectedDate = DateTime.Now;
        }

        private void BtnConfirmarAdopcion_Click(object sender, RoutedEventArgs e)
        {
            string nombreAdoptante = txtNombreAdoptante.Text.Trim();
            DateTime? fechaAdopcion = dpFecha.SelectedDate;
            string observaciones = txtObservaciones.Text.Trim();

            if (string.IsNullOrEmpty(nombreAdoptante) || fechaAdopcion == null)
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Crear objeto Adopcion
            Adopcion nuevaAdopcion = new Adopcion
            {
                NombreAdoptante = nombreAdoptante,
                Mascota = mascotaSeleccionada,
                FechaAdopcion = fechaAdopcion.Value,
                Observaciones = observaciones
            };

            // Guardar adopción
            var adopciones = AdopcionesHelper.CargarAdopciones();
            adopciones.Add(nuevaAdopcion);
            AdopcionesHelper.GuardarAdopciones(adopciones);

            // Eliminar mascota adoptada
            var mascotas = MascotasHelper.CargarMascotas();
            mascotas.RemoveAll(m => m.Nombre == mascotaSeleccionada.Nombre && m.Raza == mascotaSeleccionada.Raza);
            MascotasHelper.GuardarMascotas(mascotas);

            MessageBox.Show("Adopción registrada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true; // Indica que la adopción se completó
            this.Close();
        }

    }
}
