using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Reserva
{
    enum EstadoReserva
    {
        Reservada = 0,   // Reserva creada, pendiente de check-in
        CheckIn = 1,   // El huésped ya hizo check-in
        CheckOut = 2,   // El huésped realizó check-out
        Cancelada = 3    // La reserva fue cancelada
    }
}
