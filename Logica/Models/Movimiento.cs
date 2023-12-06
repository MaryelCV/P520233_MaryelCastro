using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Xml.Linq;


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


            //Primero Hacemos un insert en el encabezado y RECOLECTAMOS que se genera, esto es 
            //indispensable ya que se necesita como FK en la tabla de Detalle

            Conexion MyCnn = new Conexion();

            MyCnn.ListaDeParametros.Add(new SqlParameter("@Fecha", this.Fecha));
            MyCnn.ListaDeParametros.Add(new SqlParameter("@Anotaciones", this.Anotaciones));
            MyCnn.ListaDeParametros.Add(new SqlParameter("@TipoMovimiento", this.MiTipo.MovimientoTipoID));
            MyCnn.ListaDeParametros.Add(new SqlParameter("@UsuarioID", this.MiUsuario.UsuarioID));

            //Generico
            Object RetornoSPAgregar = MyCnn.EjecutarSELECTEscalar("SPMovimientosAgregarEncabezado");

            int IDMovimientoRecienCreado;

            if (RetornoSPAgregar != null)
            {
                //Especializado
                IDMovimientoRecienCreado = Convert.ToInt32(RetornoSPAgregar.ToString());

                //Asignamos al objeto ID generado por el SP

                this.MovimientoID = IDMovimientoRecienCreado;



                foreach (MovimientoDetalle item in this.Detalles)
                {
                    //por cada iteración en la lista de detalles hacemos un insert en la 
                    //tabla de detalles 

                    Conexion MyCnnDetalle = new Conexion();


                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@IDMovimiento", IDMovimientoRecienCreado));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@IDProducto", item.MiProducto.ProductoID));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@Cantidad", item.CantidadMovimiento));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@Costo", item.Costo));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@SubTotal", item.SubTotal));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@TotalIVA", item.TotalIVA));
                    MyCnnDetalle.ListaDeParametros.Add(new SqlParameter("@PrecioUnitario", item.PrecioUnitario));


                    MyCnnDetalle.EjecutarDML("SPMovimientosAgregarDetalle");

                }

                R = true;

            }


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

        public List<MovimientoDetalle> Detalles { get; set; }



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

        public ReportDocument Imprimir(ReportDocument document)
        {
            ReportDocument R = document;
            //Hacemos un objeto de tipo Crystal (la clase que creamos)
            Tools.Crystal ObjCrystal = new Tools.Crystal(R);

            DataTable datos = new DataTable();
            Conexion MyCnn = new Conexion();

            MyCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.MovimientoID));

            datos = MyCnn.EjecutarSelect("SPMovimientoImprimir");

            if (datos != null && datos.Rows.Count > 0)
            {
                ObjCrystal.Datos = datos;

                R = ObjCrystal.GenerarReporte();

            }
            return R;

        }






            //FIN

        }
    }
