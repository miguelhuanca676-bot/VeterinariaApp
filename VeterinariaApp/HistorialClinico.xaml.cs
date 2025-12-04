using System.Collections.Generic;
using System.Windows;

namespace VeterinariaApp
{
    public partial class HistorialClinicoWindow : Window
    {
        public HistorialClinicoWindow()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string ci = txtBuscarCI.Text.Trim();
            List<Mascota> mascotas = ArchivoHelper.BuscarPorCI(ci);

            if (mascotas.Count == 0)
            {
                MessageBox.Show("No se encontraron registros para este CI.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                dgHistorial.ItemsSource = null;
            }
            else
            {
                dgHistorial.ItemsSource = mascotas;
            }
        }
    }
}
