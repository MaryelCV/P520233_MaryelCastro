using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class MovimientoDetalle
    {



       public Producto MiProducto { get; set; }
        public MovimientoDetalle()
        {
            MiProducto = new Producto();
        }

        //Propiedades
        public decimal CantidadMovimiento { get; set; }
        public decimal Costo { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalIVA { get; set; }
        public decimal PrecioUnitario { get; set; }

















    }
}
