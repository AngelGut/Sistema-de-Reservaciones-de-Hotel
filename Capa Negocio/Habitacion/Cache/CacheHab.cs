using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Capa_Negocio.Habitacion; // Para HabitacionBase, Simple, Doble...

namespace Capa_Negocio.Habitacion.Cache
{
    /// <summary>
    /// CacheHab representa una fuente de datos en memoria.
    /// Sirve para simular un segundo origen de consulta, permitiendo
    /// usar Task.WhenAny() contra consultas a la base de datos real.
    /// </summary>
    public class CacheHab
    {
        // Lista pública de solo lectura (la lista como tal es modificable).
        public List<HabitacionBase> Habitaciones { get; } = new List<HabitacionBase>();

        public CacheHab()
        {
            CargarHabitacionesIniciales();
        }

        /// <summary>
        /// Carga 20 habitaciones predeterminadas del hotel.
        /// Puedes modificar precios, estados, descripciones...
        /// </summary>
        private void CargarHabitacionesIniciales()
        {
            Habitaciones.Add(new Simple { IdHabitacion = 1, Numero = 101, PrecioPorNoche = 2000m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Simple { IdHabitacion = 2, Numero = 102, PrecioPorNoche = 2000m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Doble { IdHabitacion = 3, Numero = 201, PrecioPorNoche = 2800m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Doble { IdHabitacion = 4, Numero = 202, PrecioPorNoche = 2800m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Suite { IdHabitacion = 5, Numero = 301, PrecioPorNoche = 4500m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Suite { IdHabitacion = 6, Numero = 302, PrecioPorNoche = 4500m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Presidencial { IdHabitacion = 7, Numero = 401, PrecioPorNoche = 9000m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Presidencial { IdHabitacion = 8, Numero = 402, PrecioPorNoche = 9000m, Estado = EstadoHabitacion.Disponible });

            // Resto hasta 20 habitaciones
            Habitaciones.Add(new Simple { IdHabitacion = 9, Numero = 103, PrecioPorNoche = 2100m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Doble { IdHabitacion = 10, Numero = 203, PrecioPorNoche = 2900m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Suite { IdHabitacion = 11, Numero = 303, PrecioPorNoche = 4600m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Simple { IdHabitacion = 12, Numero = 104, PrecioPorNoche = 2100m, Estado = EstadoHabitacion.Mantenimiento });
            Habitaciones.Add(new Doble { IdHabitacion = 13, Numero = 204, PrecioPorNoche = 2800m, Estado = EstadoHabitacion.Ocupada });
            Habitaciones.Add(new Suite { IdHabitacion = 14, Numero = 304, PrecioPorNoche = 4500m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Simple { IdHabitacion = 15, Numero = 105, PrecioPorNoche = 2200m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Presidencial { IdHabitacion = 16, Numero = 403, PrecioPorNoche = 9000m, Estado = EstadoHabitacion.Ocupada });
            Habitaciones.Add(new Simple { IdHabitacion = 17, Numero = 106, PrecioPorNoche = 2000m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Doble { IdHabitacion = 18, Numero = 205, PrecioPorNoche = 2700m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Suite { IdHabitacion = 19, Numero = 305, PrecioPorNoche = 4600m, Estado = EstadoHabitacion.Disponible });
            Habitaciones.Add(new Simple { IdHabitacion = 20, Numero = 107, PrecioPorNoche = 2300m, Estado = EstadoHabitacion.Disponible });
        }
    }
}
