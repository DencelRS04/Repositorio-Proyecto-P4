
//
namespace Inicio
{
    partial class Entrada_de_Productos
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelNumeroIngreso;
        private System.Windows.Forms.Label labelFechaCompra;
        private System.Windows.Forms.Label labelCedulaJuridica;
        private System.Windows.Forms.Label labelProductos;
        private System.Windows.Forms.TextBox txtNumeroIngreso;
        private System.Windows.Forms.TextBox txtFechaCompra;
        private System.Windows.Forms.TextBox txtCedulaJuridica;
        private System.Windows.Forms.DataGridView gridProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelNumeroIngreso = new System.Windows.Forms.Label();
            this.labelFechaCompra = new System.Windows.Forms.Label();
            this.labelCedulaJuridica = new System.Windows.Forms.Label();
            this.labelProductos = new System.Windows.Forms.Label();
            this.txtNumeroIngreso = new System.Windows.Forms.TextBox();
            this.txtFechaCompra = new System.Windows.Forms.TextBox();
            this.txtCedulaJuridica = new System.Windows.Forms.TextBox();
            this.gridProductos = new System.Windows.Forms.DataGridView();
            this.NumeroProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_num_producto = new System.Windows.Forms.TextBox();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(12, 373);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(120, 35);
            this.buttonAgregar.TabIndex = 9;
            this.buttonAgregar.Text = "Agregar Producto";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(157, 373);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(120, 35);
            this.buttonEnviar.TabIndex = 10;
            this.buttonEnviar.Text = "Enviar Entrada";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(468, 373);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(120, 35);
            this.buttonCerrar.TabIndex = 12;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(317, 373);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(120, 35);
            this.buttonLimpiar.TabIndex = 11;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.Location = new System.Drawing.Point(180, 20);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(263, 29);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Entrada de Productos";
            // 
            // labelNumeroIngreso
            // 
            this.labelNumeroIngreso.AutoSize = true;
            this.labelNumeroIngreso.Location = new System.Drawing.Point(15, 130);
            this.labelNumeroIngreso.Name = "labelNumeroIngreso";
            this.labelNumeroIngreso.Size = new System.Drawing.Size(125, 16);
            this.labelNumeroIngreso.TabIndex = 1;
            this.labelNumeroIngreso.Text = "Número de Ingreso:";
            // 
            // labelFechaCompra
            // 
            this.labelFechaCompra.AutoSize = true;
            this.labelFechaCompra.Location = new System.Drawing.Point(15, 171);
            this.labelFechaCompra.Name = "labelFechaCompra";
            this.labelFechaCompra.Size = new System.Drawing.Size(215, 16);
            this.labelFechaCompra.TabIndex = 3;
            this.labelFechaCompra.Text = "Fecha de Compra (AAAA-MM-DD):";
            // 
            // labelCedulaJuridica
            // 
            this.labelCedulaJuridica.AutoSize = true;
            this.labelCedulaJuridica.Location = new System.Drawing.Point(15, 206);
            this.labelCedulaJuridica.Name = "labelCedulaJuridica";
            this.labelCedulaJuridica.Size = new System.Drawing.Size(103, 16);
            this.labelCedulaJuridica.TabIndex = 5;
            this.labelCedulaJuridica.Text = "Cédula Jurídica:";
            // 
            // labelProductos
            // 
            this.labelProductos.AutoSize = true;
            this.labelProductos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.labelProductos.Location = new System.Drawing.Point(15, 229);
            this.labelProductos.Name = "labelProductos";
            this.labelProductos.Size = new System.Drawing.Size(145, 18);
            this.labelProductos.TabIndex = 7;
            this.labelProductos.Text = "Lista de Productos:";
            // 
            // txtNumeroIngreso
            // 
            this.txtNumeroIngreso.Location = new System.Drawing.Point(146, 127);
            this.txtNumeroIngreso.MaxLength = 10;
            this.txtNumeroIngreso.Name = "txtNumeroIngreso";
            this.txtNumeroIngreso.Size = new System.Drawing.Size(200, 22);
            this.txtNumeroIngreso.TabIndex = 2;
            // 
            // txtFechaCompra
            // 
            this.txtFechaCompra.Location = new System.Drawing.Point(236, 168);
            this.txtFechaCompra.MaxLength = 8;
            this.txtFechaCompra.Name = "txtFechaCompra";
            this.txtFechaCompra.Size = new System.Drawing.Size(160, 22);
            this.txtFechaCompra.TabIndex = 4;
            this.txtFechaCompra.Text = "2025-10-07";
            // 
            // txtCedulaJuridica
            // 
            this.txtCedulaJuridica.Location = new System.Drawing.Point(124, 203);
            this.txtCedulaJuridica.MaxLength = 10;
            this.txtCedulaJuridica.Name = "txtCedulaJuridica";
            this.txtCedulaJuridica.Size = new System.Drawing.Size(200, 22);
            this.txtCedulaJuridica.TabIndex = 6;
            // 
            // gridProductos
            // 
            this.gridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroProducto,
            this.Cantidad});
            this.gridProductos.Location = new System.Drawing.Point(55, 247);
            this.gridProductos.Name = "gridProductos";
            this.gridProductos.RowHeadersWidth = 51;
            this.gridProductos.RowTemplate.Height = 24;
            this.gridProductos.Size = new System.Drawing.Size(500, 120);
            this.gridProductos.TabIndex = 8;
            // 
            // NumeroProducto
            // 
            this.NumeroProducto.HeaderText = "No. Producto (10)";
            this.NumeroProducto.MaxInputLength = 10;
            this.NumeroProducto.MinimumWidth = 6;
            this.NumeroProducto.Name = "NumeroProducto";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad (7)";
            this.Cantidad.MaxInputLength = 7;
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            // 
            // txt_num_producto
            // 
            this.txt_num_producto.Location = new System.Drawing.Point(130, 52);
            this.txt_num_producto.Name = "txt_num_producto";
            this.txt_num_producto.Size = new System.Drawing.Size(100, 22);
            this.txt_num_producto.TabIndex = 13;
            this.txt_num_producto.TextChanged += new System.EventHandler(this.txt_num_producto_TextChanged);
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(130, 88);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(100, 22);
            this.txt_cantidad.TabIndex = 14;
            this.txt_cantidad.TextChanged += new System.EventHandler(this.txt_cantidad_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Numero Producto: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Cantidad: ";
            // 
            // Entrada_de_Productos
            // 
            this.ClientSize = new System.Drawing.Size(600, 420);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.txt_num_producto);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.gridProductos);
            this.Controls.Add(this.labelProductos);
            this.Controls.Add(this.txtCedulaJuridica);
            this.Controls.Add(this.labelCedulaJuridica);
            this.Controls.Add(this.txtFechaCompra);
            this.Controls.Add(this.labelFechaCompra);
            this.Controls.Add(this.txtNumeroIngreso);
            this.Controls.Add(this.labelNumeroIngreso);
            this.Controls.Add(this.labelTitulo);
            this.Name = "Entrada_de_Productos";
            this.Text = "Entrada de Productos";
            ((System.ComponentModel.ISupportInitialize)(this.gridProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_num_producto;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
