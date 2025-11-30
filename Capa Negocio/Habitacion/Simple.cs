using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Habitacion
{
    public class Simple : HabitacionBase
    {
        public override decimal CalcularPrecio()
        {
            return PrecioBase;
        }
    }
}
