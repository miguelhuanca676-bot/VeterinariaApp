using System.Windows;

namespace VeterinariaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            RegistrarClienteWindow ventana = new RegistrarClienteWindow();
            ventana.ShowDialog();
        }

        private void BtnHistorialClinico_Click(object sender, RoutedEventArgs e)
        {
            HistorialClinicoWindow ventana = new HistorialClinicoWindow();
            ventana.ShowDialog();
        }

        private void BtnRegistrarDoctor_Click(object sender, RoutedEventArgs e)
        {
            RegistrarDoctorWindow ventana = new RegistrarDoctorWindow();
            ventana.ShowDialog();
        }

        private void BtnServicios_Click(object sender, RoutedEventArgs e)
        {
            ServiciosWindow ventana = new ServiciosWindow();
            ventana.ShowDialog();
        }
    }
}
