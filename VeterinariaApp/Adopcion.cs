using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VeterinariaApp
{
    public class Adopcion
    {
        public string NombreAdoptante { get; set; }
        public Mascota Mascota { get; set; }
        public DateTime FechaAdopcion { get; set; }
        public string Observaciones { get; set; }
    }
}


