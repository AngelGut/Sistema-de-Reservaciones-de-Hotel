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
            // Fijamos el tipo para que siempre coincida con la jerarquía.
            Tipo = TipoHabitacion.Simple;

            // Puedes poner un precio por defecto si quieres.
            // Luego lo puedes sobreescribir desde el formulario.
            PrecioPorNoche = 2000m;
        }
    }
}
