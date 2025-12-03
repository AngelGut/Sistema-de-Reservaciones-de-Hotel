using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Habitacion
{
    public class Simple : HabitacionBase
    {
        public Simple()
        {
            Tipo = TipoHabitacion.Simple;
            PrecioPorNoche = 2000m;   // pasa por el setter validado
        }
    }

}
