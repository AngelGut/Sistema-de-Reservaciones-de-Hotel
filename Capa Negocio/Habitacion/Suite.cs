using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Habitacion
{
    public class Suite : HabitacionBase
    {
        public Suite()
        {
            Tipo = TipoHabitacion.Suite;
            PrecioPorNoche = 4500m;
        }
    }
}
