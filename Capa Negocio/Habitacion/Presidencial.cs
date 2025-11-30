using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Habitacion
{
    public class Presidencial : HabitacionBase
    {
        public Presidencial()
        {
            Tipo = TipoHabitacion.Presidencial;
            PrecioPorNoche = 9000m;
        }
    }
}
