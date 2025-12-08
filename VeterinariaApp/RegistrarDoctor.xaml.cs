using System;
using System.Windows;

namespace VeterinariaApp
{
    public partial class RegistrarDoctorWindow : Window
    {
        public static System.Collections.Generic.List<Veterinario> Veterinarios = new System.Collections.Generic.List<Veterinario>();

        public RegistrarDoctorWindow()
        {
            InitializeComponent();
            if (Veterinarios.Count == 0)
                Veterinarios.AddRange(ArchivoDoctores.CargarDoctores());
        }

        private void BtnGuardarDoctor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Primero validamos
                if (ExisteDoctor(txtNombre.Text, txtApellido.Text))
                {
                    MessageBox.Show("Ya existe un doctor con este nombre.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Si no existe, lo creamos
                Veterinario v = new Veterinario(
                    txtNombre.Text,
                    txtApellido.Text,
                    int.Parse(txtEdad.Text),
                    txtEspecialidad.Text,
                    int.Parse(txtExperiencia.Text)
                );

                Veterinarios.Add(v);
                ArchivoDoctores.GuardarDoctor(v);

                MessageBox.Show("Doctor guardado correctamente");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error al guardar doctor. Revisa los datos.");
            }
        }

        private bool ExisteDoctor(string nombre, string apellido)
        {
            foreach (var doc in Veterinarios)
            {
                if (doc.Nombre.Trim().Equals(nombre.Trim(), StringComparison.OrdinalIgnoreCase) &&
                    doc.Apellido.Trim().Equals(apellido.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Ya existe
                }
            }
            return false;
        }


    }
}
