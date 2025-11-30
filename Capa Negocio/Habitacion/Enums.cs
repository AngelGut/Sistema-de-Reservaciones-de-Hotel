using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Habitacion
{
    // ---------------------------------------------------------
    // Enumeración para el tipo de habitación.
    // Estos valores coinciden con la columna Tipo (INT) de la tabla.
    // ---------------------------------------------------------
    public enum TipoHabitacion
    {
        Simple = 1,
        Doble = 2,
        Suite = 3,
        Presidencial = 4
    }

    // ---------------------------------------------------------
    // Enumeración para el estado de la habitación.
    // Estos valores coinciden con la columna Estado (INT) de la tabla.
    // ---------------------------------------------------------
    public enum EstadoHabitacion
    {
        Disponible = 0,
        Ocupada = 1,
        Mantenimiento = 2
    }
}
