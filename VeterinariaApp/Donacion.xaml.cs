using System.Windows;

namespace VeterinariaApp
{
    public partial class DonacionWindow : Window
    {
        public DonacionWindow()
        {
            InitializeComponent();
        }

        private void BtnRegistrarDonacion_Click(object sender, RoutedEventArgs e)
        {
            // Abrir ventana de registro de donación
            RegistrarDonacionWindow registrarWindow = new RegistrarDonacionWindow();
            registrarWindow.ShowDialog();
        }

        private void BtnVerDonaciones_Click(object sender, RoutedEventArgs e)
        {
            // Abrir ventana para mostrar donaciones
            VerDonacionesWindow verWindow = new VerDonacionesWindow();
            verWindow.ShowDialog();
        }
    }
}
