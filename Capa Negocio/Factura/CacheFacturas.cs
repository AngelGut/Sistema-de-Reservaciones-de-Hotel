using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio.Factura.Cache
{
    // Clase de cache en memoria para facturas.
    // Usa Dictionary<int, Factura> como pide el enunciado.
    public class CacheFacturas
    {
        // Dictionary donde:
        //  - Key   = IdFactura (número de factura)
        //  - Value = objeto Factura asociado
        public Dictionary<int, Factura> Facturas { get; } = new Dictionary<int, Factura>();

        // Agrega una factura nueva o actualiza si ya existe la clave.
        public void AgregarOActualizar(Factura factura)
        {
            // Si ya existe la factura con ese Id, se reemplaza.
            Facturas[factura.IdFactura] = factura;
        }

        // Intenta obtener una factura del diccionario.
        // Devuelve true si la encuentra, false si no.
        public bool TryObtener(int idFactura, out Factura factura)
        {
            return Facturas.TryGetValue(idFactura, out factura);
        }

        // Limpia toda la cache (opcional, por si quieres recargar todo).
        public void Limpiar()
        {
            Facturas.Clear();
        }
    }
}
