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
        }

        private void BtnGuardarDoctor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Veterinario v = new Veterinario(
                    txtNombre.Text,
                    txtApellido.Text,
                    int.Parse(txtEdad.Text),
                    txtEspecialidad.Text,
                    int.Parse(txtExperiencia.Text)
                );

                Veterinarios.Add(v);
                MessageBox.Show("Doctor guardado correctamente");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error al guardar doctor. Revisa los datos.");
            }
        }
    }
}
