using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Movimiento
    {
        //Constructor
        public Movimiento()
        {
            MiTipo = new MovimientoTipo();
            MiUsuario = new Usuario();
            Detalles = new List<MovimientoDetalle>();
        }
        public int MovimientoID { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroMovimiento { get; set; }
        public string Anotaciones { get; set; }

        //Funciones
        public bool Agregar()
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
        public DataTable Listar()
        {
            DataTable R = new DataTable();

            return R;
        }

        public MovimientoTipo MiTipo { get; set; }
        public Usuario MiUsuario { get; set; }

        //Detalle, si analizamos el diagrama de clases 
        //vemos que al llegar a la clase de detalle termina en "muchos"
        //1..*. Eso significa que el atributo tiene multiplicidad
        //o sea se puede repetir n veces

        List<MovimientoDetalle> Detalles { get; set; }



        public DataTable AsignarEsquemaDelDetalle()
        {
            DataTable R = new DataTable();

            Conexion MyCnn = new Conexion();

            //queremos cargar el esquema del datatable, NO los datos
            R = MyCnn.EjecutarSelect("SPMovimientoCargarDetalle", true);

            //para evitar el identity (1,1) que está originalmente en la tabla
            //me genere numeros unicos que impidan repetir registros
            R.PrimaryKey = null;

            return R;
        }


    }
}
