namespace P520233_MaryelCastro.Formularios
{
    partial class FrmProductosGestion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.CbVerActivos = new System.Windows.Forms.CheckBox();
            this.DgvListaProductos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtProductoCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtProductoCodigoBarras = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtProductoNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtProductoCosto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtProductoSubTotal = new System.Windows.Forms.TextBox();
            this.TxtProductoTasaImpuesto = new System.Windows.Forms.TextBox();
            this.TxtProductoPrecioUnitario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtProductoCantidadStock = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CboxProductoCategoria = new System.Windows.Forms.ComboBox();
            this.CbProductoActivo = new System.Windows.Forms.CheckBox();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ColProductoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductoCategoriaDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTasaImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidadStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtProductoUtilidad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaProductos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(58, 6);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(234, 20);
            this.TxtBuscar.TabIndex = 1;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // CbVerActivos
            // 
            this.CbVerActivos.AutoSize = true;
            this.CbVerActivos.Checked = true;
            this.CbVerActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbVerActivos.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbVerActivos.Location = new System.Drawing.Point(564, 8);
            this.CbVerActivos.Name = "CbVerActivos";
            this.CbVerActivos.Size = new System.Drawing.Size(140, 18);
            this.CbVerActivos.TabIndex = 2;
            this.CbVerActivos.Text = "Ver Productos Activos";
            this.CbVerActivos.UseVisualStyleBackColor = true;
            this.CbVerActivos.CheckedChanged += new System.EventHandler(this.CbVerActivos_CheckedChanged);
            // 
            // DgvListaProductos
            // 
            this.DgvListaProductos.AllowUserToAddRows = false;
            this.DgvListaProductos.AllowUserToDeleteRows = false;
            this.DgvListaProductos.AllowUserToOrderColumns = true;
            this.DgvListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColProductoID,
            this.ColProductoCategoriaDescripcion,
            this.ColNombreProducto,
            this.ColCosto,
            this.ColSubTotal,
            this.ColTasaImpuesto,
            this.ColPrecioUnitario,
            this.ColCodigoBarras,
            this.ColCantidadStock});
            this.DgvListaProductos.Location = new System.Drawing.Point(15, 43);
            this.DgvListaProductos.MultiSelect = false;
            this.DgvListaProductos.Name = "DgvListaProductos";
            this.DgvListaProductos.ReadOnly = true;
            this.DgvListaProductos.RowHeadersVisible = false;
            this.DgvListaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaProductos.Size = new System.Drawing.Size(827, 168);
            this.DgvListaProductos.TabIndex = 3;
            this.DgvListaProductos.VirtualMode = true;
            this.DgvListaProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtProductoUtilidad);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.CbProductoActivo);
            this.groupBox1.Controls.Add(this.CboxProductoCategoria);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.TxtProductoCantidadStock);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.TxtProductoNombre);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.TxtProductoPrecioUnitario);
            this.groupBox1.Controls.Add(this.TxtProductoTasaImpuesto);
            this.groupBox1.Controls.Add(this.TxtProductoSubTotal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtProductoCosto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtProductoCodigoBarras);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtProductoCodigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 287);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles del Producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cód. de Producto";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TxtProductoCodigo
            // 
            this.TxtProductoCodigo.Enabled = false;
            this.TxtProductoCodigo.Location = new System.Drawing.Point(6, 34);
            this.TxtProductoCodigo.Name = "TxtProductoCodigo";
            this.TxtProductoCodigo.Size = new System.Drawing.Size(145, 21);
            this.TxtProductoCodigo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cód. de Barras";
            // 
            // TxtProductoCodigoBarras
            // 
            this.TxtProductoCodigoBarras.Location = new System.Drawing.Point(6, 132);
            this.TxtProductoCodigoBarras.Name = "TxtProductoCodigoBarras";
            this.TxtProductoCodigoBarras.Size = new System.Drawing.Size(145, 21);
            this.TxtProductoCodigoBarras.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nombre del Producto";
            // 
            // TxtProductoNombre
            // 
            this.TxtProductoNombre.Location = new System.Drawing.Point(6, 88);
            this.TxtProductoNombre.Name = "TxtProductoNombre";
            this.TxtProductoNombre.Size = new System.Drawing.Size(269, 21);
            this.TxtProductoNombre.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Costo";
            // 
            // TxtProductoCosto
            // 
            this.TxtProductoCosto.Location = new System.Drawing.Point(6, 178);
            this.TxtProductoCosto.Name = "TxtProductoCosto";
            this.TxtProductoCosto.Size = new System.Drawing.Size(145, 21);
            this.TxtProductoCosto.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 14);
            this.label6.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "Sub. Total";
            // 
            // TxtProductoSubTotal
            // 
            this.TxtProductoSubTotal.Location = new System.Drawing.Point(320, 34);
            this.TxtProductoSubTotal.Name = "TxtProductoSubTotal";
            this.TxtProductoSubTotal.Size = new System.Drawing.Size(144, 21);
            this.TxtProductoSubTotal.TabIndex = 11;
            // 
            // TxtProductoTasaImpuesto
            // 
            this.TxtProductoTasaImpuesto.Location = new System.Drawing.Point(320, 88);
            this.TxtProductoTasaImpuesto.Name = "TxtProductoTasaImpuesto";
            this.TxtProductoTasaImpuesto.Size = new System.Drawing.Size(144, 21);
            this.TxtProductoTasaImpuesto.TabIndex = 12;
            // 
            // TxtProductoPrecioUnitario
            // 
            this.TxtProductoPrecioUnitario.Location = new System.Drawing.Point(320, 132);
            this.TxtProductoPrecioUnitario.Name = "TxtProductoPrecioUnitario";
            this.TxtProductoPrecioUnitario.Size = new System.Drawing.Size(144, 21);
            this.TxtProductoPrecioUnitario.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(320, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 14);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tasa de Impuesto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 14);
            this.label9.TabIndex = 15;
            this.label9.Text = "Precio Unitario";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(317, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "Cantidad Stock";
            // 
            // TxtProductoCantidadStock
            // 
            this.TxtProductoCantidadStock.Location = new System.Drawing.Point(320, 178);
            this.TxtProductoCantidadStock.Name = "TxtProductoCantidadStock";
            this.TxtProductoCantidadStock.Size = new System.Drawing.Size(144, 21);
            this.TxtProductoCantidadStock.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(317, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 14);
            this.label11.TabIndex = 18;
            this.label11.Text = "Categoría";
            // 
            // CboxProductoCategoria
            // 
            this.CboxProductoCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxProductoCategoria.FormattingEnabled = true;
            this.CboxProductoCategoria.Location = new System.Drawing.Point(320, 229);
            this.CboxProductoCategoria.Name = "CboxProductoCategoria";
            this.CboxProductoCategoria.Size = new System.Drawing.Size(177, 22);
            this.CboxProductoCategoria.TabIndex = 19;
            // 
            // CbProductoActivo
            // 
            this.CbProductoActivo.AutoSize = true;
            this.CbProductoActivo.Enabled = false;
            this.CbProductoActivo.Location = new System.Drawing.Point(173, 37);
            this.CbProductoActivo.Name = "CbProductoActivo";
            this.CbProductoActivo.Size = new System.Drawing.Size(59, 18);
            this.CbProductoActivo.TabIndex = 20;
            this.CbProductoActivo.Text = "Activo";
            this.CbProductoActivo.UseVisualStyleBackColor = true;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.Green;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.ForeColor = System.Drawing.Color.White;
            this.BtnAgregar.Location = new System.Drawing.Point(619, 258);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(145, 31);
            this.BtnAgregar.TabIndex = 5;
            this.BtnAgregar.Text = "AGREGAR";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.Color.Turquoise;
            this.BtnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.ForeColor = System.Drawing.Color.White;
            this.BtnModificar.Location = new System.Drawing.Point(619, 313);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(145, 31);
            this.BtnModificar.TabIndex = 6;
            this.BtnModificar.Text = "MODIFICAR";
            this.BtnModificar.UseVisualStyleBackColor = false;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.Maroon;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.White;
            this.BtnEliminar.Location = new System.Drawing.Point(619, 366);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(145, 31);
            this.BtnEliminar.TabIndex = 7;
            this.BtnEliminar.Text = "ELIMINAR";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.Gray;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.Location = new System.Drawing.Point(585, 446);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(99, 31);
            this.BtnLimpiar.TabIndex = 9;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackColor = System.Drawing.Color.Gray;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrar.ForeColor = System.Drawing.Color.White;
            this.BtnCerrar.Location = new System.Drawing.Point(699, 446);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(99, 31);
            this.BtnCerrar.TabIndex = 10;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.Location = new System.Drawing.Point(18, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 14);
            this.label12.TabIndex = 21;
            this.label12.Text = "Todos los datos son Requeridos ";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(6, 265);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 19);
            this.label13.TabIndex = 22;
            this.label13.Text = "*";
            // 
            // ColProductoID
            // 
            this.ColProductoID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColProductoID.DataPropertyName = "ProductoID";
            this.ColProductoID.HeaderText = "CÓDIGO";
            this.ColProductoID.Name = "ColProductoID";
            this.ColProductoID.ReadOnly = true;
            this.ColProductoID.Width = 80;
            // 
            // ColProductoCategoriaDescripcion
            // 
            this.ColProductoCategoriaDescripcion.DataPropertyName = "ProductoCategoriaDescripcion";
            this.ColProductoCategoriaDescripcion.HeaderText = "CATEGORÍA DEL PROD.";
            this.ColProductoCategoriaDescripcion.Name = "ColProductoCategoriaDescripcion";
            this.ColProductoCategoriaDescripcion.ReadOnly = true;
            // 
            // ColNombreProducto
            // 
            this.ColNombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNombreProducto.DataPropertyName = "NombreProducto";
            this.ColNombreProducto.HeaderText = "NOMBRE PRODUCTO";
            this.ColNombreProducto.Name = "ColNombreProducto";
            this.ColNombreProducto.ReadOnly = true;
            // 
            // ColCosto
            // 
            this.ColCosto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColCosto.DataPropertyName = "Costo";
            this.ColCosto.HeaderText = "COSTO";
            this.ColCosto.Name = "ColCosto";
            this.ColCosto.ReadOnly = true;
            this.ColCosto.Width = 80;
            // 
            // ColSubTotal
            // 
            this.ColSubTotal.DataPropertyName = "SubTotal";
            this.ColSubTotal.HeaderText = "SUB TOTAL";
            this.ColSubTotal.Name = "ColSubTotal";
            this.ColSubTotal.ReadOnly = true;
            // 
            // ColTasaImpuesto
            // 
            this.ColTasaImpuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColTasaImpuesto.DataPropertyName = "TasaImpuesto";
            this.ColTasaImpuesto.HeaderText = "%";
            this.ColTasaImpuesto.Name = "ColTasaImpuesto";
            this.ColTasaImpuesto.ReadOnly = true;
            this.ColTasaImpuesto.Width = 30;
            // 
            // ColPrecioUnitario
            // 
            this.ColPrecioUnitario.DataPropertyName = "PrecioUnitario";
            this.ColPrecioUnitario.HeaderText = "PRECIO C/U";
            this.ColPrecioUnitario.Name = "ColPrecioUnitario";
            this.ColPrecioUnitario.ReadOnly = true;
            // 
            // ColCodigoBarras
            // 
            this.ColCodigoBarras.DataPropertyName = "CodigoBarras";
            this.ColCodigoBarras.HeaderText = "CÓD. BARRAS";
            this.ColCodigoBarras.Name = "ColCodigoBarras";
            this.ColCodigoBarras.ReadOnly = true;
            // 
            // ColCantidadStock
            // 
            this.ColCantidadStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColCantidadStock.DataPropertyName = "CantidadStock";
            this.ColCantidadStock.HeaderText = "STOCK";
            this.ColCantidadStock.Name = "ColCantidadStock";
            this.ColCantidadStock.ReadOnly = true;
            this.ColCantidadStock.Width = 80;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 212);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 14);
            this.label14.TabIndex = 23;
            this.label14.Text = "Utilidad";
            // 
            // TxtProductoUtilidad
            // 
            this.TxtProductoUtilidad.Location = new System.Drawing.Point(6, 229);
            this.TxtProductoUtilidad.Name = "TxtProductoUtilidad";
            this.TxtProductoUtilidad.Size = new System.Drawing.Size(145, 21);
            this.TxtProductoUtilidad.TabIndex = 24;
            // 
            // FrmProductosGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 516);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvListaProductos);
            this.Controls.Add(this.CbVerActivos);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmProductosGestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Productos";
            this.Load += new System.EventHandler(this.FrmProductosGestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaProductos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.CheckBox CbVerActivos;
        private System.Windows.Forms.DataGridView DgvListaProductos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtProductoCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtProductoNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtProductoCodigoBarras;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtProductoPrecioUnitario;
        private System.Windows.Forms.TextBox TxtProductoTasaImpuesto;
        private System.Windows.Forms.TextBox TxtProductoSubTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtProductoCosto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtProductoCantidadStock;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CboxProductoCategoria;
        private System.Windows.Forms.CheckBox CbProductoActivo;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductoCategoriaDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTasaImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidadStock;
        private System.Windows.Forms.TextBox TxtProductoUtilidad;
        private System.Windows.Forms.Label label14;
    }
}