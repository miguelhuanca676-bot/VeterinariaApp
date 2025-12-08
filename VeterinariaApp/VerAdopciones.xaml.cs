using System.Collections.Generic;
using System.Windows;

namespace VeterinariaApp
{
    public partial class VerAdopcionesWindow : Window
    {
        private List<Adopcion> adopciones;

        public VerAdopcionesWindow()
        {
            InitializeComponent();

            // Cargar adopciones desde JSON
            adopciones = AdopcionesHelper.CargarAdopciones();

            // Asignar al DataGrid
            dgAdopciones.ItemsSource = adopciones;
        }
    }
}
