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
    public partial class FrmProductosGestion : Form
    {

        //Objeto local tipo producto
        private Logica.Models.Producto MiProductoLocal { get; set; }

        public FrmProductosGestion()
        {
            InitializeComponent();

            MiProductoLocal = new Logica.Models.Producto();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {






        }








        //NO
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FrmProductosGestion_Load(object sender, EventArgs e)
        {
            MdiParent = Globales.ObjetosGlobales.MiFormularioPrincipal;

            CargarComboRolesProducto();

            CargarListaProductos(CbVerActivos.Checked);

            ActivarBotonAgregar();
        }

        private void CargarComboRolesProducto()
        {
            Logica.Models.ProductoCategoria MiRol = new Logica.Models.ProductoCategoria();
            DataTable dt = new DataTable();

            dt = MiRol.Listar();

            if (dt != null && dt.Rows.Count > 0)
            {


                //na vez asegurado que el dt tenga valores, los dibujos en el combobox

                CboxProductoCategoria.ValueMember = "id";
                CboxProductoCategoria.DisplayMember = "Descripcion";

                CboxProductoCategoria.DataSource = dt;
                CboxProductoCategoria.SelectedIndex = -1;
            }
        }



        private void CargarListaProductos(bool VerActivos, string FiltroBusqueda = "")
        {
            Logica.Models.Producto miproducto = new Logica.Models.Producto();

            DataTable lista = new DataTable();

            if (VerActivos)
            {
                //si se quieren ver los usuarios activos
                lista = miproducto.ListarActivos(FiltroBusqueda);
                DgvListaProductos.DataSource = lista;
            }
            else
            {
                //Usuarios inactivos
                lista = miproducto.ListarInactivos(FiltroBusqueda);
                DgvListaProductos.DataSource = lista;
            }
        }


        private bool ValidarDatosRequeridos()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtProductoNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProductoCodigoBarras.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProductoCosto.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProductoUtilidad.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProductoSubTotal.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProductoTasaImpuesto.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProductoPrecioUnitario.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtProductoCantidadStock.Text.Trim()) &&

                CboxProductoCategoria.SelectedIndex > -1)
            {
                R = true;
            }
            else
                {
                if (string.IsNullOrEmpty(TxtProductoNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el nombre del producto", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

                if(string.IsNullOrEmpty(TxtProductoCodigoBarras.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el código de barras", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (string.IsNullOrEmpty(TxtProductoCosto.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el costo", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (string.IsNullOrEmpty(TxtProductoUtilidad.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la utilidad", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

                if (string.IsNullOrEmpty(TxtProductoSubTotal.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el Sub.Total", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (string.IsNullOrEmpty(TxtProductoTasaImpuesto.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la Tasa Impuesto", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (string.IsNullOrEmpty(TxtProductoPrecioUnitario.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el precio unitario", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                if (string.IsNullOrEmpty(TxtProductoCantidadStock.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la cantidad de stock", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

            }

            return R;
        }



        private void BtnAgregar_Click(object sender, EventArgs e)
        {
           

            if (ValidarDatosRequeridos())
            {

                MiProductoLocal = new Logica.Models.Producto();

                //Trim ignora los espacios escritos
                MiProductoLocal.NombreProducto = TxtProductoNombre.Text.Trim();
                MiProductoLocal.CodigoBarras = TxtProductoCodigoBarras.Text.Trim();
                MiProductoLocal.Costo = Convert.ToDecimal( TxtProductoCosto.Text.Trim());
                MiProductoLocal.Utilidad = Convert.ToDecimal(TxtProductoUtilidad.Text.Trim());
                MiProductoLocal.SubTotal = Convert.ToDecimal(TxtProductoSubTotal.Text.Trim());
                MiProductoLocal.TasaImpuesto = Convert.ToDecimal(TxtProductoTasaImpuesto.Text.Trim());
                MiProductoLocal.PrecioUnitario = Convert.ToDecimal(TxtProductoPrecioUnitario.Text.Trim());
                MiProductoLocal.CantidadStock = Convert.ToDecimal(TxtProductoCantidadStock.Text.Trim());
                MiProductoLocal.TasaImpuesto = Convert.ToDecimal(TxtProductoTasaImpuesto.Text.Trim());

                //Con el combo de rol hay que extraer el valuemember 
                MiProductoLocal.MiCategoria.ProductoCategoriaID = Convert.ToInt32(CboxProductoCategoria.SelectedValue);


                bool CodigoBarrasOk = MiProductoLocal.ConsultarPorCodigoBarras(MiProductoLocal.CodigoBarras);


                if (CodigoBarrasOk == false && CodigoBarrasOk == false)
                {


                    string Pregunta = string.Format("Está seguro de agregar al Producto {0}??", MiProductoLocal.NombreProducto);
                    DialogResult respuesta = MessageBox.Show(Pregunta, "???", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {

                        //Procedemos a Agregar el usuario

                        bool ok = MiProductoLocal.Agregar();

                        if (ok)
                        {
                            MessageBox.Show("Producto ingresado correctamente!", ":)", MessageBoxButtons.OK);

                            LimpiarForm();
                            CargarListaProductos(CbVerActivos.Checked);
                        }
                        else
                        {
                            MessageBox.Show("Producto no se logró agregar!", ":(", MessageBoxButtons.OK);
                        }
                    }
                }


            }


        }



        private void LimpiarForm()
        {
            TxtProductoCodigo.Clear();
            TxtProductoNombre.Clear();
            TxtProductoCodigoBarras.Clear();
            TxtProductoCosto.Clear();
            TxtProductoSubTotal.Clear();
            TxtProductoTasaImpuesto.Clear();
            TxtProductoPrecioUnitario.Clear();
            TxtProductoCantidadStock.Clear();
            TxtProductoUtilidad.Clear();

            CboxProductoCategoria.SelectedIndex = -1;

            CbProductoActivo.Checked = false;

        }

        private void ActivarBotonAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;


        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
           LimpiarForm();
          ActivarBotonAgregar();
        }


        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 3)
            {
                CargarListaProductos(CbVerActivos.Checked, TxtBuscar.Text.Trim());
            }
            else
            {
                CargarListaProductos(CbVerActivos.Checked);
            }


        }

        private void CbVerActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarListaProductos(CbVerActivos.Checked);

            if (CbVerActivos.Checked)

            {
                BtnEliminar.Text = "ELIMINAR";

            }
            else
            {
                BtnEliminar.Text = "ACTIVAR";
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }






        //FIN
    }
}
