using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class MovimientoTipo
    {
        //Propiedades
        public int MovimientoTipoID { get; set; }
        public string MovimientoTipoDescripcion { get; set; }


        //Funciones
        public DataTable Listar()
        {
            DataTable R = new DataTable();

            Conexion MiCnn = new Conexion();

            R = MiCnn.EjecutarSelect("SPMovimientosListar");

            return R;


        }




    }
}
