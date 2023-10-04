using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Producto
    {
        

        //Propiedades
        public int ProductoID { get; set; }
        public string CodigoBarras { get; set; }
        public string NombreProducto { get; set; }
        public decimal Costo { get; set; }
        public decimal Utilidad { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TasaImpuesto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal CantidadStock { get; set; }
        public bool Activo { get; set; }

        ProductoCategoria MiCategoria { get; set; }
        public Producto()
        {
            MiCategoria = new ProductoCategoria();

        }

        //Funciones
        public bool Agregar()
        {
            bool R = false;

            return R;
        }
        public bool Actualizar()
        {
            bool R = false;

            return R;
        }
        public bool Eliminar()
        {
            bool R = false;

            return R;
        }
        public bool ConsultarPorID()
        {
            bool R = false;

            return R;
        }
        public bool ConsutarPorCodigoBarras(string CodigoBarras)
        {
            bool R = false;

            return R;

        }
        public DataTable Listar(bool VerActivos = true)
        {
            DataTable R = new DataTable();

            return R;
        }












    }
}
