using System.Windows;

namespace VeterinariaApp
{
    public partial class ServiciosWindow : Window
    {
        public ServiciosWindow()
        {
            InitializeComponent();
        }

        private void BtnDonacion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionalidad de Donación (por implementar)");
        }

        private void BtnAdopcion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionalidad de Adopción (por implementar)");
        }
    }
}
