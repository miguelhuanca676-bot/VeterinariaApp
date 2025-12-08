using System;
using System.IO;
using System.Windows;

namespace VeterinariaApp
{
    public partial class RegistrarDonacionWindow : Window
    {
        private string archivoDonaciones = "donaciones.txt";

        public RegistrarDonacionWindow()
        {
            InitializeComponent();
            dpFecha.SelectedDate = DateTime.Now; // Inicializa con la fecha actual
        }

        private void BtnGuardarDonacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validar campos
                if (string.IsNullOrWhiteSpace(txtNombreDonante.Text) ||
                    string.IsNullOrWhiteSpace(txtMontoArticulo.Text) ||
                    !dpFecha.SelectedDate.HasValue)
                {
                    MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Obtener datos
                string nombreDonante = txtNombreDonante.Text.Trim();
                string montoArticulo = txtMontoArticulo.Text.Trim();
                DateTime fecha = dpFecha.SelectedDate.Value;
                string observaciones = txtObservaciones.Text.Trim();

                // Crear línea para guardar
                string linea = $"{nombreDonante}|{montoArticulo}|{fecha:yyyy-MM-dd}|{observaciones}";

                // Guardar en archivo
                using (StreamWriter sw = new StreamWriter(archivoDonaciones, true))
                {
                    sw.WriteLine(linea);
                }

                MessageBox.Show("Donación registrada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la donación: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
