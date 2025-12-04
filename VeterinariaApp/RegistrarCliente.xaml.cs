using System;
using System.Windows;

namespace VeterinariaApp
{
    public partial class RegistrarClienteWindow : Window
    {
        public RegistrarClienteWindow()
        {
            InitializeComponent();
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Datos del cliente
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                int edad = int.Parse(txtEdad.Text.Trim());
                string ci = txtCI.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string direccion = txtDireccion.Text.Trim();

                Cliente cliente = new Cliente(nombre, apellido, edad, ci, telefono, direccion);

                // Datos de la mascota
                string nombreMascota = txtNombreMascota.Text.Trim();
                string raza = txtRazaMascota.Text.Trim();
                int edadMascota = int.Parse(txtEdadMascota.Text.Trim());
                string sexo = rbMacho.IsChecked == true ? "Macho" : "Hembra";
                string diagnostico = txtDiagnostico.Text.Trim();

                Mascota mascota = new Mascota(nombreMascota, raza, edadMascota, sexo, diagnostico);
                cliente.AgregarMascota(mascota);

                // Guardar en archivo
                ArchivoHelper.GuardarCliente(cliente);

                MessageBox.Show("Cliente y mascota registrados correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
