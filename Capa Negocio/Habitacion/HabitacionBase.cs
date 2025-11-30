using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Habitacion
{
    public abstract class HabitacionBase
    {
        // Corresponde a: IdHabitacion
        public int IdHabitacion { get; set; }

        // Corresponde a: Numero
        public int Numero { get; set; }

        // Corresponde a: Tipo
        // En la BD es INT, en C# usamos enum para hacerlo más legible.
        public TipoHabitacion Tipo { get; protected set; }

        // Corresponde a: Nombre
        public string Nombre { get; set; }

        // Corresponde a: PrecioPorNoche
        public decimal PrecioPorNoche { get; set; }

        // Corresponde a: Estado 
        public EstadoHabitacion Estado { get; set; }

        // Corresponde a: Descripcion
        public string Descripcion { get; set; }
    }
}
