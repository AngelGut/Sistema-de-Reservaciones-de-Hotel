using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Reserva
{
    public interface ICancelable
    {
        /// <summary>
        /// Indica si el objeto está en un estado que permite cancelar.
        /// </summary>
        bool PuedeCancelar();

        /// <summary>
        /// Aplica la cancelación y cambia el estado interno.
        /// </summary>
        void Cancelar();
    }
}
