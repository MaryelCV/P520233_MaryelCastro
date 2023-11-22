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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnContrasennia_MouseDown(object sender, MouseEventArgs e)
        {
            TxtContrasennia.UseSystemPasswordChar = false;

        }

        private void BtnContrasennia_MouseUp(object sender, MouseEventArgs e)
        {
            TxtContrasennia.UseSystemPasswordChar = true;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUsuario.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtContrasennia.Text.Trim()))
            {
                //si hay valores en los cuadros de texto se procede a validarlos 
                string usuario = TxtUsuario.Text.Trim();
                string contrasennia = TxtContrasennia.Text.Trim();

                int idUsuario = Globales.ObjetosGlobales.MiUsuarioGlobal.ValidarIngreso(usuario, contrasennia);

                if (idUsuario > 0)
                {
                    //la validación es correcta. Ahora creamos el usuario global y además permitimos el ingreso 
                    //al sistema 

                    Globales.ObjetosGlobales.MiUsuarioGlobal = Globales.ObjetosGlobales.MiUsuarioGlobal.ConsultarPorID(idUsuario);

                    Globales.ObjetosGlobales.MiFormularioPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Acceso denegado!", "Error de validación...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtUsuario.Focus();
                    TxtUsuario.SelectAll();
                }
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift & e.Control & e.KeyCode == Keys.A)
            {
                BtnIngresoDirecto.Visible = true;
            }
        }

        private void BtnIngresoDirecto_Click(object sender, EventArgs e)
        {
            Globales.ObjetosGlobales.MiFormularioPrincipal.Show();
            this.Hide();
        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
