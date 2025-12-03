using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Habitacion
{
    //interfaz para habitaciones reservables
    public interface IReservable
    {
        bool EstaDisponible();
    }

    public abstract class HabitacionBase : IReservable
    {
        public int IdHabitacion { get; set; }
        public int Numero { get; set; }
        public TipoHabitacion Tipo { get; protected set; }
        public string Nombre { get; set; }

        // ===========================
        //  ENCAPSULAMIENTO, este es con motivo de tener una capa de seguridad adicional para el precio
        // ===========================
        private decimal _precioPorNoche;

        public decimal PrecioPorNoche
        {
            get => _precioPorNoche;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio por noche debe ser mayor que cero.");
                _precioPorNoche = value;
            }
        }

        public EstadoHabitacion Estado { get; set; }
        public string Descripcion { get; set; }

        public bool EstaDisponible()
        {
            return Estado == EstadoHabitacion.Disponible;
        }
    }

}
