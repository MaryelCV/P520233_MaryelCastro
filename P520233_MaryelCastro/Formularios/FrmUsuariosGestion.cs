using Logica.Models;
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

            CargarListaUsuarios(CbVerActivos.Checked);

            ActivarBotonAgregar();

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

        private void CargarListaUsuarios(bool VerActivos, string FiltroBusqueda = "")
        {

            Logica.Models.Usuario miusuario = new Logica.Models.Usuario();

            DataTable lista = new DataTable();

            if (VerActivos)
            {
                //si se quieren ver los usuarios activos
                lista = miusuario.ListarActivos(FiltroBusqueda);
                DgvListaUsuarios.DataSource = lista;
            }
            else
            {
                //Usuarios inactivos
                lista = miusuario.ListarInactivos(FiltroBusqueda);
                DgvListaUsuarios.DataSource = lista;
            }


        }

        private bool ValidarDatosRequeridos(bool OmitirContrasennia = false)
        {


            bool R = false;

            //validan que se hayan validado valores en los campos obligatorios
            if (!string.IsNullOrEmpty(TxtUsuarioCedula.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUsuarioCorreo.Text.Trim()) &&

                CboxUsuarioTipoRol.SelectedIndex > -1
                )
            {


                if (OmitirContrasennia)
                {

                    //Si se omite la contra entonces se pasa a true
                    R = true;
                }
                else
                {

                    //Si no se omite la contra debemos validar tambien ese campo
                    if (!string.IsNullOrEmpty(TxtUsuarioContrasennia.Text.Trim()))
                    {
                        R = true;
                    }
                    else
                    {
                        //Contrasennia
                        if (string.IsNullOrEmpty(TxtUsuarioContrasennia.Text.Trim()))
                        {
                            MessageBox.Show("Debe digitar la contraseña", "Error de validación", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }

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



                //ROLL DE USUARIO
                if (CboxUsuarioTipoRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un Rol de Usuario", "Error de validación", MessageBoxButtons.OK);
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
                            CargarListaUsuarios(CbVerActivos.Checked);
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

        private void DgvListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void DgvListaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Primero validamos que se haya seleccionado una linea del DGV (cuadro gris) y 
            //que sea solo una.

            if (DgvListaUsuarios.SelectedRows.Count == 1)
            {
                LimpiarForm();

                // ColUsuarioID
                //Necesito consultar por el ID del Usuario, se debe estraer el 
                //valor de la comlumna correspondiente del DGV, en este caso "ColusuarioID"

                DataGridViewRow MiDgvFila = DgvListaUsuarios.SelectedRows[0];
                int IDUsuario = Convert.ToInt32(MiDgvFila.Cells["ColUsuarioID"].Value);

                MiUsuarioLocal = new Logica.Models.Usuario();
                MiUsuarioLocal = MiUsuarioLocal.ConsultarPorID(IDUsuario);

                if (MiUsuarioLocal != null && MiUsuarioLocal.UsuarioID > 0)

                {
                    //Una vez que se ha aseguyrado que existe el usuaurio y que tiene datos se "dibujan" esos
                    //datos en los controles correspondientes del formulario

                    TxtUsuarioCodigo.Text = MiUsuarioLocal.UsuarioID.ToString();
                    TxtUsuarioCedula.Text = MiUsuarioLocal.Cedula;
                    TxtUsuarioNombre.Text = MiUsuarioLocal.Name;
                    TxtUsuarioCorreo.Text = MiUsuarioLocal.Correo;
                    TxtUsuarioTelefono.Text = MiUsuarioLocal.Telefono;
                    TxtUsuarioDireccion.Text = MiUsuarioLocal.Direccion;

                    //No quiero que se muestre la contrasena ya que esta encriptada y no se 
                    //requiere actualizarla y se deja en blanco el campo del texto


                    CboxUsuarioTipoRol.SelectedValue = MiUsuarioLocal.MiUsuarioRol.UsuarioRolID;
                    CbUsuarioActivo.Checked = MiUsuarioLocal.Activo;

                    ActivarBotonesModificarYEliminar();


                }

            }



        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {

            LimpiarForm();
            ActivarBotonAgregar();

        }



        private void ActivarBotonAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;


        }

        private void ActivarBotonesModificarYEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnModificar.Enabled = true;
            BtnEliminar.Enabled = true;
        }

        private void DgvListaUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            //Esto limpia la seleccion de la fla autmatica que es el comportamiento estandar del control
            DgvListaUsuarios.ClearSelection();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            // Al igual que con el agregar, se deben validar los datos requeridos pero 
            //el campo de a contrasena debe ser opcional en este caso

            if (ValidarDatosRequeridos(true))
            {

                //Transferirmos al objeto local los posibles cambios que se hayan hecho en los datos usuario

                MiUsuarioLocal.Name = TxtUsuarioNombre.Text.Trim();
                MiUsuarioLocal.Cedula = TxtUsuarioCedula.Text.Trim();
                MiUsuarioLocal.Correo = TxtUsuarioCorreo.Text.Trim();
                MiUsuarioLocal.Telefono = TxtUsuarioTelefono.Text.Trim();
                MiUsuarioLocal.Direccion = TxtUsuarioDireccion.Text.Trim();
                MiUsuarioLocal.MiUsuarioRol.UsuarioRolID = Convert.ToInt32(CboxUsuarioTipoRol.SelectedValue);

                //Depende de si digito o no una contrasena, habra dos distintos UPDATE en los SPS
                MiUsuarioLocal.Contrasennia = TxtUsuarioContrasennia.Text.Trim();


                //En el diagrama expandido de casos de uso para el tema del usuario, se indica que para 
                // modificar o eliminar primero se debe consultar por ID.
                if (MiUsuarioLocal.ConsultarPorID())
                {

                    DialogResult Resp = MessageBox.Show("Desea modificar el usuario?", "???", MessageBoxButtons.YesNo);

                    if (Resp == DialogResult.Yes)
                    {
                        //Procede a modificar el regustro del usuario
                        if (MiUsuarioLocal.Actualizar())
                        {
                            MessageBox.Show("Usuario modificado correctamente!!", ";)", MessageBoxButtons.OK);

                            LimpiarForm();
                            CargarListaUsuarios(CbVerActivos.Checked);
                            ActivarBotonAgregar();
                        }
                    }
                }
            }
        }




        private void TxtUsuarioNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresTexto(e);
        }

        private void TxtUsuarioCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresTexto(e,false,true);
        }

        private void TxtUsuarioTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresNumeros(e);
        }


        //este no
        private void TxtUsuarioContrasennia_TextChanged(object sender, EventArgs e)
        {

        }

        //este no

        private void TxtUsuarioContrasennia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresTexto(e);
        }

        private void TxtUsuarioDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresTexto(e);
        }

        private void TxtUsuarioCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.Validaciones.CaracteresNumeros(e);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }









        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (CbVerActivos.Checked)
            {
                //se procede a eliminar
                if (MiUsuarioLocal.UsuarioID > 0)
                {
                    string msg = string.Format("¿Está seguro de eliminar al usuario {0}?", MiUsuarioLocal.Name);

                    DialogResult respuesta = MessageBox.Show(msg, "Confirmación requerida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes && MiUsuarioLocal.Eliminar())
                    {
                        MessageBox.Show("El Usuario ha sido eliminado", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarForm();
                        CargarListaUsuarios(CbVerActivos.Checked);
                        ActivarBotonAgregar();
                    }
                }
            }
            else
            {
                //se procede a activar 
                if (MiUsuarioLocal.UsuarioID > 0)
                {
                    string msg = string.Format("¿Está seguro de activar al usuario {0}?", MiUsuarioLocal.Name);

                    DialogResult respuesta = MessageBox.Show(msg, "Confirmación requerida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes && MiUsuarioLocal.Activar())
                    {
                        MessageBox.Show("El Usuario ha sido activado", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarForm();
                        CargarListaUsuarios(CbVerActivos.Checked);
                        ActivarBotonAgregar();
                    }
                }


            }



        }















        private void CbVerActivos_CheckedChanged(object sender, EventArgs e)
        {

            CargarListaUsuarios(CbVerActivos.Checked);




            if (CbVerActivos.Checked)

            {
                BtnEliminar.Text = "ELIMINAR";

            }
            else {
                BtnEliminar.Text = "ACTIVAR";
            }


        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
            {
                CargarListaUsuarios(CbVerActivos.Checked, TxtBuscar.Text.Trim());
            }
            else
            {
                CargarListaUsuarios(CbVerActivos.Checked);
            }



        }








        //Fin
    }
}
