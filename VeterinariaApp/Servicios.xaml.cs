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
            DonacionWindow donacion = new DonacionWindow();
            donacion.ShowDialog();
        }

        private void BtnAdopcion_Click(object sender, RoutedEventArgs e)
        {
            AdopcionWindow adopcion = new AdopcionWindow();
            adopcion.ShowDialog();
        }
    }
}
