using System;
using System.Windows;

namespace VeterinariaApp
{
    public partial class RegistrarClienteWindow : Window
    {
        public RegistrarClienteWindow()
        {
            InitializeComponent();
            // Cargar doctores desde archivo si aún no están en la lista global
            if (RegistrarDoctorWindow.Veterinarios.Count == 0)
            {
                RegistrarDoctorWindow.Veterinarios.AddRange(ArchivoDoctores.CargarDoctores());
            }

            // Asignar ComboBox
            cbDoctores.ItemsSource = null;
            cbDoctores.ItemsSource = RegistrarDoctorWindow.Veterinarios;

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

                // --- PRIMERO validar y obtener el doctor ---
                if (cbDoctores.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un doctor.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Veterinario doctorAsignado = (Veterinario)cbDoctores.SelectedItem;

                // Datos de la mascota
                string nombreMascota = txtNombreMascota.Text.Trim();
                string raza = txtRazaMascota.Text.Trim();
                int edadMascota = int.Parse(txtEdadMascota.Text.Trim());
                string sexo = rbMacho.IsChecked == true ? "Macho" : "Hembra";
                string diagnostico = txtDiagnostico.Text.Trim();

                Mascota mascota = new Mascota(nombreMascota, raza, edadMascota, sexo, diagnostico);

                // --- AHORA puedes usar doctorAsignado ---
                mascota.DoctorAsignado = doctorAsignado.InfoCompleta;

                cliente.AgregarMascota(mascota);
                cliente.DoctorAsignado = doctorAsignado;

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
        private void BtnEliminarDoctorDesdeCombo_Click(object sender, RoutedEventArgs e)
        {
            Veterinario doctor = (sender as FrameworkElement).DataContext as Veterinario;

            if (doctor == null)
                return;

            // Eliminar de la lista global
            RegistrarDoctorWindow.Veterinarios.Remove(doctor);

            // Eliminar del archivo
            ArchivoDoctores.EliminarDoctor(doctor);

            // Refrescar ComboBox
            cbDoctores.ItemsSource = null;
            cbDoctores.ItemsSource = RegistrarDoctorWindow.Veterinarios;

            MessageBox.Show("Doctor eliminado correctamente.");
        }


    }
}
