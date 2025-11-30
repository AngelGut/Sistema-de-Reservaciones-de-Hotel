using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Habitacion
{
    public class Doble : HabitacionBase
    {
        public Doble()
        {
            Tipo = TipoHabitacion.Doble;
            PrecioPorNoche = 2800m;
        }
    }
}
