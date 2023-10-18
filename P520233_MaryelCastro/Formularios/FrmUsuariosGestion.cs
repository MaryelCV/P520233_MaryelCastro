using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P520233_MaryelCastro.Formularios
{
    public partial class FrmUsuariosGestion : Form
    {

        //Objeto Local de tipo Usuario
        //SE ESTA CREANDO MiUsuarioLocal
        private Logica.Models.Usuario MiUsuarioLocal { get; set; }



        //Constructor
        public FrmUsuariosGestion()
        {
            InitializeComponent();

            MiUsuarioLocal = new Logica.Models.Usuario();


        }



        private void FrmUsuariosGestion_Load(object sender, EventArgs e)
        {
            MdiParent = Globales.ObjetosGlobales.MiFormularioPrincipal;

            CargarComboRolesUsuario();

            CargarListaUsuarios();

        }

        private void CargarComboRolesUsuario()
        {
            Logica.Models.UsuarioRol MiRol = new Logica.Models.UsuarioRol();
            DataTable dt = new DataTable();

            dt = MiRol.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {


                //na vez asegurado que el dt tenga valores, los dibujos en el combobox

                CboxUsuarioTipoRol.ValueMember = "id";
                CboxUsuarioTipoRol.DisplayMember = "Descripcion";

                CboxUsuarioTipoRol.DataSource = dt;
                CboxUsuarioTipoRol.SelectedIndex = -1;
            }
        }





        //Aqui van a estar todas las funcionalidades especificas y
        //que se pueden reutilizar DEBEN ser encapsuladas.

        private void CargarListaUsuarios()
        {

            Logica.Models.Usuario miusuario = new Logica.Models.Usuario();

            DataTable lista = new DataTable();

            lista = miusuario.ListarActivos();

            DgvListaUsuarios.DataSource = lista;


        }

        private bool ValidarDatosRequeridos()
        {
            bool R = false;

            //validan que se hayan validado valores en los campos obligatorios
            if (!string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioContrasennia.Text.Trim()) &&
                CboxUsuarioTipoRol.SelectedIndex > -1
                )
            {
                R = true;
            }
            else
            {
                //Indicar al usuario que validacion está faltano

                //CEDULA
                if (string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la cédula", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

                //NOMBRE
                if (string.IsNullOrEmpty(TxtUsuarioNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el nombre", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

                //CORREO
                if (string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el correo", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                //Contrasennia
                if (string.IsNullOrEmpty(TxtUsuarioContrasennia.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la contraseña", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

              

            }


            return R;
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            //Primero es validar los datos minimos requeridos.
            //Esto se hace para evitar registros sin datos a nivel de base de datos 
            //pero tambien si un campo de base de datos no acepta valores NULL
            // y se llama al INSERT, dará error.

            //Luego de esto y tomando en consideracion el diagrama de casos de uso expandido 
            // de usuario, hay que hacer validar que NO existan un usuario con cedula y/o 
            //correo que digitaron. (No se pueden repetir estos datos en distintas filas en la tabla usuario

            //Si ambas validaciones son negativas entonces se procede a Agregar() el usuario

            //Usaremos en objeto local de tipo usuario que sera al que daremos forma para luego 
            //usar las funciones como agregar, modificar,


            if (ValidarDatosRequeridos())
            {


                MiUsuarioLocal = new Logica.Models.Usuario();

                //Trim ignora los espacios escritos
                MiUsuarioLocal.Cedula = TxtUsuarioCedula.Text.Trim();
                MiUsuarioLocal.Name = TxtUsuarioNombre.Text.Trim();
                MiUsuarioLocal.Correo = TxtUsuarioCorreo.Text.Trim();
                MiUsuarioLocal.Telefono = TxtUsuarioTelefono.Text.Trim();

                //Con el combo de rol hay que extraer el valuemember 
                MiUsuarioLocal.MiUsuarioRol.UsuarioRolID = Convert.ToInt32(CboxUsuarioTipoRol.SelectedValue);

                MiUsuarioLocal.Contrasennia = TxtUsuarioContrasennia.Text.Trim();
                MiUsuarioLocal.Direccion = TxtUsuarioDireccion.Text.Trim();

                bool CedulaOk = MiUsuarioLocal.ConsultarPorCedula(MiUsuarioLocal.Cedula);
                bool CorreoOk = MiUsuarioLocal.ConsultarPorCorreo(MiUsuarioLocal.Correo);

                if (CedulaOk == false && CorreoOk == false)
                {

                    //Se solicita confirmacion por parte del usuario 

                    string Pregunta = string.Format("Está seguro de agregar al usuario {0}??", MiUsuarioLocal.Name);
                    DialogResult respuesta = MessageBox.Show(Pregunta, "???", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {

                        //Procedemos a Agregar el usuario

                        bool ok = MiUsuarioLocal.Agregar();

                        if (ok)
                        {
                            MessageBox.Show("Usuario ingresado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();
                            CargarListaUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Usuario no se logró agregar!", ":(", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void LimpiarForm()
        {
            TxtUsuarioCodigo.Clear();
            TxtUsuarioCedula.Clear();
            TxtUsuarioNombre.Clear();
            TxtUsuarioCorreo.Clear();
            TxtUsuarioTelefono.Clear();
            TxtUsuarioContrasennia.Clear();
            TxtUsuarioDireccion.Clear();

            CboxUsuarioTipoRol.SelectedIndex = -1;

            CbUsuarioActivo.Checked = false;

        }











        //Fin
    }
}
