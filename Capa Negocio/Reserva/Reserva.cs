using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Reserva
{
    public class Reserva : ICancelable
    {
        // -------------------------------------------------------------
        // PROPIEDADES QUE MAPEAN LA TABLA dbo.Reserva
        // -------------------------------------------------------------

        /// <summary>
        /// Clave primaria (IDENTITY) de la reserva.
        /// </summary>
        public int IdReserva { get; set; }

        /// <summary>
        /// Id de la habitación reservada (FK a dbo.Habitacion).
        /// </summary>
        public int IdHabitacion { get; set; }

        /// <summary>
        /// Id del cliente que realiza la reserva (FK a dbo.Cliente).
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Fecha de entrada al hotel (sin hora para simplificar).
        /// </summary>
        public DateTime FechaEntrada { get; set; }

        /// <summary>
        /// Fecha de salida del hotel (sin hora para simplificar).
        /// Debe ser mayor a FechaEntrada.
        /// </summary>
        public DateTime FechaSalida { get; set; }

        /// <summary>
        /// Estado actual de la reserva (Reservada, CheckIn, etc.).
        /// Se almacena como INT en la base de datos.
        /// </summary>
        public EstadoReserva EstadoReserva { get; set; }

        /// <summary>
        /// Fecha en que se creó la reserva. 
        /// En la BD tiene DEFAULT(GETDATE()).
        /// </summary>
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        /// <summary>
        /// Precio por noche de la habitación al momento de reservar.
        /// Este valor es un "snapshot" que no cambia aunque luego
        /// cambie el precio de la habitación.
        /// </summary>
        public decimal PrecioPorNoche { get; set; }

        /// <summary>
        /// Notas adicionales sobre la reserva (opcional).
        /// </summary>
        public string Notas { get; set; } = string.Empty;

        // -------------------------------------------------------------
        // PROPIEDADES CALCULADAS (NO se guardan en la tabla Reserva)
        // -------------------------------------------------------------

        /// <summary>
        /// Cantidad de noches de hospedaje.
        /// Si la fecha de salida es menor o igual que la de entrada,
        /// el resultado será 0 o negativo, por lo que se recomienda
        /// validar antes de crear la reserva.
        /// </summary>
        public int Dias
        {
            get
            {
                // Usamos Date para ignorar la hora y trabajar solo con día/mes/año
                var entrada = FechaEntrada.Date;
                var salida = FechaSalida.Date;

                return (salida - entrada).Days;
            }
        }

        /// <summary>
        /// Subtotal de la reserva (sin ITBIS).
        /// Se calcula como PrecioPorNoche * Dias.
        /// </summary>
        public decimal Subtotal => PrecioPorNoche * Dias;

        /// <summary>
        /// ITBIS calculado al 18% del subtotal.
        /// </summary>
        public decimal Itbis => Subtotal * 0.18m;

        /// <summary>
        /// Total a pagar (Subtotal + ITBIS).
        /// </summary>
        public decimal Total => Subtotal + Itbis;

        // -------------------------------------------------------------
        // IMPLEMENTACIÓN DE ICancelable
        // -------------------------------------------------------------

        /// <summary>
        /// Indica si la reserva está en un estado que permite cancelar.
        /// Por ejemplo, solo cuando está en estado "Reservada".
        /// </summary>
        public bool PuedeCancelar()
        {
            // Regla básica: solo reservas en estado "Reservada" pueden cancelarse.
            return EstadoReserva == EstadoReserva.Reservada;
        }

        /// <summary>
        /// Cambia el estado de la reserva a "Cancelada" si es posible;
        /// de lo contrario, lanza una excepción.
        /// </summary>
        public void Cancelar()
        {
            if (!PuedeCancelar())
                throw new InvalidOperationException("No se puede cancelar esta reserva en su estado actual.");

            EstadoReserva = EstadoReserva.Cancelada;
        }
    }
}
