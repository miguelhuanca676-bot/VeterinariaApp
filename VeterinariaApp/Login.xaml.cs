using System.Windows;

namespace VeterinariaApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Password.Trim();

            // Aquí puedes poner validación real o solo ejemplo
            if (usuario == "admin" && password == "1234")
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
