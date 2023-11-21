using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Logica.Models
{
    public class Usuario
    {

        //ctor automatico
        public Usuario()
        {
            MiUsuarioRol = new UsuarioRol();

        }

        public int UsuarioID { get; set; }
        public string Cedula { get; set; }
        public string Name { get; set; }
        public string Correo { get; set; }
        public string Contrasennia { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        public UsuarioRol MiUsuarioRol { get; set; }


        //Funciones, metodos

        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            //Agregamos todos los parametros que solicita el SP de agregar
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.Name));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.Correo));
            //Encriptar la contraseña

            Tools.Crypto MiEncriptador = new Tools.Crypto();
            string ContrasenniaEncriptada = MiEncriptador.EncriptarEnUnSentido(this.Contrasennia);



            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasennia", this.Contrasennia));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.Direccion));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@UsuarioRolID", this.MiUsuarioRol.UsuarioRolID));

            int resultado = MiCnn.EjecutarDML("SPUsuariosAgregar");

            if (resultado > 0) R = true;
            
            return R;
        }
        public bool Actualizar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            //Agregamos todos los parametros que solicita el SP de agregar
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", this.Cedula));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Nombre", this.Name));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", this.Correo));
            //Encriptar la contraseña


            Tools.Crypto MiEncriptador = new Tools.Crypto();
            string ContrasenniaEncriptada = MiEncriptador.EncriptarEnUnSentido(this.Contrasennia);
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Contrasennia", this.Contrasennia));


            MiCnn.ListaDeParametros.Add(new SqlParameter("@Telefono", this.Telefono));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@Direccion", this.Direccion));
            MiCnn.ListaDeParametros.Add(new SqlParameter("@UsuarioRolID", this.MiUsuarioRol.UsuarioRolID));

            MiCnn.ListaDeParametros.Add(new SqlParameter("ID", this.UsuarioID));

            int resultado = MiCnn.EjecutarDML("SPUsuariosActualizar");

            if (resultado > 0) R = true;
             

            return R;
        }
        public bool Eliminar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            int resultado = MiCnn.EjecutarDML("SPUsuariosEliminar");

            if (resultado > 0) R = true;
          

            return R;
        }

        public bool ConsultarPorID()
        {
            bool R = false;


            Conexion MyCnn = new Conexion();

            MyCnn.ListaDeParametros.Add(new SqlParameter("@ID", this.UsuarioID));

            DataTable DatosUsuario = new DataTable();

            DatosUsuario = MyCnn.EjecutarSelect("SPUsuariosConsultarPorID");

            if (DatosUsuario != null && DatosUsuario.Rows.Count > 0)
            {

                //El usuario existe
                R = true;

            }

            return R;
        }





        public Usuario ConsultarPorID(int IdUsuario)
        {
            Usuario R = new Usuario();

            //Esta Funcion retorna un objeto de tipo usuario con datos en los atributos,
            //Es una variedad de ConsultarPorId que me permite manipular el objeto y no solo 
            //saber si el usuario existe o no a traves de un bool.

            Conexion MyCnn = new Conexion();

            MyCnn.ListaDeParametros.Add(new SqlParameter("@ID", IdUsuario));

            DataTable DatosUsuario = new DataTable();

            DatosUsuario = MyCnn.EjecutarSelect("SPUsuariosConsultarPorID");

            if (DatosUsuario != null && DatosUsuario.Rows.Count > 0)
            {
                //Como tenemos que llenar un objeto compuesto(Por el rol usuario)
                //Debemos extraer los datos de la consulta y llenar los atributos
                //correspondientes del objetivo de tipo Usuario R.


                //Aca capturamos los datos de la fila 0 del resultado
                DataRow MiFila = DatosUsuario.Rows[0];

                R.UsuarioID = Convert.ToInt32(MiFila["UsuarioID"]);
                R.Name = Convert.ToString(MiFila["Nombre"]);
                R.Cedula = Convert.ToString(MiFila["Cedula"]);
                R.Correo = Convert.ToString(MiFila["Correo"]);
                R.Telefono = Convert.ToString(MiFila["Telefono"]);
                R.Contrasennia = Convert.ToString(MiFila["Contrasennia"]);
                R.Direccion = Convert.ToString(MiFila["Direccion"]);
                R.Activo = Convert.ToBoolean(MiFila["Activo"]);
                R.MiUsuarioRol.UsuarioRolID = Convert.ToInt32(MiFila["UsuarioRolID"]);
                R.MiUsuarioRol.Rol = Convert.ToString(MiFila["Rol"]);
              

            }

            return R;
        }


        public bool ConsultarPorCedula(string pCedula)
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Cedula", pCedula));


            DataTable dt = new DataTable();
            dt = MiCnn.EjecutarSelect("SPUsuariosConsultarPorCedula");


            if (dt != null && dt.Rows.Count > 0) R = true;

            return R;
        }


        public bool ConsultarPorCorreo(string pCorreo)
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            MiCnn.ListaDeParametros.Add(new SqlParameter("@Correo", pCorreo));


            DataTable dt = new DataTable();
            dt = MiCnn.EjecutarSelect("SPUsuariosConsultarPorCorreo");


            if (dt != null && dt.Rows.Count > 0) R = true;


            return R;

        }
        public DataTable ListarActivos()
        {
            DataTable R = new DataTable();


            //instancia de la clase conexion
            Conexion MiCnn = new Conexion();

            //El SP para listar requiere un parametro, hay que agregarlo
            MiCnn.ListaDeParametros.Add(new SqlParameter("@VerActivos", true));

            R = MiCnn.EjecutarSelect("SPUsuariosListar");


            return R;
        }
        public DataTable ListarInactivos()
        {
            DataTable R = new DataTable();

            return R;
        }


    }
}
