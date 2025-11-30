using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Habitacion
{
    public abstract class HabitacionBase
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioBase { get; set; }
        public int Estado { get; set; } // Libre, Ocupada, Mantenimiento


        public abstract decimal CalcularPrecio();
    }
}
