using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Reserva
{
    public class Reserva : ICancelable
    {
        // Identidad generada por la BD
        public int IdReserva { get; internal set; }

        // Llaves foráneas
        public int IdHabitacion { get; set; }
        public int IdCliente { get; set; }

        // Fechas
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }

        public EstadoReserva EstadoReserva { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Snapshot del precio al reservar
        public decimal PrecioPorNoche { get; set; }

        public string Notas { get; set; } = string.Empty;

        // PROPIEDADES CALCULADAS
        public int Dias
        {
            get
            {
                return (FechaSalida.Date - FechaEntrada.Date).Days;
            }
        }

        public decimal Subtotal => PrecioPorNoche * Dias;

        public decimal Itbis => Subtotal * 0.18m;

        public decimal Total => Subtotal + Itbis;

        // ICancelable
        public bool PuedeCancelar()
        {
            return EstadoReserva == EstadoReserva.Reservada;
        }

        public void Cancelar()
        {
            if (!PuedeCancelar())
                throw new InvalidOperationException("La reserva no se puede cancelar en su estado actual.");

            EstadoReserva = EstadoReserva.Cancelada;
        }
    }
}

