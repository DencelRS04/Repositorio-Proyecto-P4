using System;
using System.Windows.Forms;

namespace Inicio
{
    partial class compras
    {
        private System.ComponentModel.IContainer components = null;

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
            this.txtNoIngreso = new System.Windows.Forms.TextBox();
            this.txtFechaCompra = new System.Windows.Forms.TextBox();
            this.txtCedulaJuridica = new System.Windows.Forms.TextBox();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.txtFechaVencimiento = new System.Windows.Forms.TextBox();
            this.txtCodigoVerificacion = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.txtTrama = new System.Windows.Forms.TextBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblNoIngreso = new System.Windows.Forms.Label();
            this.lblFechaCompra = new System.Windows.Forms.Label();
            this.lblCedulaJuridica = new System.Windows.Forms.Label();
            this.lblNumeroTarjeta = new System.Windows.Forms.Label();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.lblCodigoVerificacion = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblTrama = new System.Windows.Forms.Label();
            this.lblInfoTarjeta = new System.Windows.Forms.Label();
            this.groupCompra = new System.Windows.Forms.GroupBox();
            this.groupTarjeta = new System.Windows.Forms.GroupBox();
            this.groupProducto = new System.Windows.Forms.GroupBox();
            this.groupDetalle = new System.Windows.Forms.GroupBox();
            this.groupTrama = new System.Windows.Forms.GroupBox();
            this.groupCompra.SuspendLayout();
            this.groupTarjeta.SuspendLayout();
            this.groupProducto.SuspendLayout();
            this.groupDetalle.SuspendLayout();
            this.groupTrama.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNoIngreso
            // 
            this.txtNoIngreso.Location = new System.Drawing.Point(12, 43);
            this.txtNoIngreso.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNoIngreso.MaxLength = 10;
            this.txtNoIngreso.Name = "txtNoIngreso";
            this.txtNoIngreso.Size = new System.Drawing.Size(296, 22);
            this.txtNoIngreso.TabIndex = 1;
            this.txtNoIngreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoIngreso_KeyPress);
            // 
            // txtFechaCompra
            // 
            this.txtFechaCompra.Location = new System.Drawing.Point(12, 91);
            this.txtFechaCompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFechaCompra.MaxLength = 10;
            this.txtFechaCompra.Name = "txtFechaCompra";
            this.txtFechaCompra.Size = new System.Drawing.Size(296, 22);
            this.txtFechaCompra.TabIndex = 3;
            this.txtFechaCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFechaCompra_KeyPress);
            // 
            // txtCedulaJuridica
            // 
            this.txtCedulaJuridica.Location = new System.Drawing.Point(12, 139);
            this.txtCedulaJuridica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCedulaJuridica.MaxLength = 10;
            this.txtCedulaJuridica.Name = "txtCedulaJuridica";
            this.txtCedulaJuridica.Size = new System.Drawing.Size(296, 22);
            this.txtCedulaJuridica.TabIndex = 5;
            this.txtCedulaJuridica.TextChanged += new System.EventHandler(this.txtCedulaJuridica_TextChanged);
            this.txtCedulaJuridica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedulaJuridica_KeyPress);
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(12, 43);
            this.txtNumeroTarjeta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumeroTarjeta.MaxLength = 16;
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(296, 22);
            this.txtNumeroTarjeta.TabIndex = 1;
            this.txtNumeroTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroTarjeta_KeyPress);
            // 
            // txtFechaVencimiento
            // 
            this.txtFechaVencimiento.Location = new System.Drawing.Point(12, 91);
            this.txtFechaVencimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFechaVencimiento.MaxLength = 5;
            this.txtFechaVencimiento.Name = "txtFechaVencimiento";
            this.txtFechaVencimiento.Size = new System.Drawing.Size(136, 22);
            this.txtFechaVencimiento.TabIndex = 3;
            this.txtFechaVencimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFechaVencimiento_KeyPress);
            // 
            // txtCodigoVerificacion
            // 
            this.txtCodigoVerificacion.Location = new System.Drawing.Point(160, 91);
            this.txtCodigoVerificacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigoVerificacion.MaxLength = 4;
            this.txtCodigoVerificacion.Name = "txtCodigoVerificacion";
            this.txtCodigoVerificacion.Size = new System.Drawing.Size(148, 22);
            this.txtCodigoVerificacion.TabIndex = 5;
            this.txtCodigoVerificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoVerificacion_KeyPress);
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(12, 43);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProducto.MaxLength = 10;
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(171, 22);
            this.txtProducto.TabIndex = 1;
            this.txtProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProducto_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(195, 43);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantidad.MaxLength = 7;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(91, 22);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtDetalle
            // 
            this.txtDetalle.AcceptsReturn = true;
            this.txtDetalle.AcceptsTab = true;
            this.txtDetalle.BackColor = System.Drawing.Color.White;
            this.txtDetalle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDetalle.Location = new System.Drawing.Point(12, 27);
            this.txtDetalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalle.Size = new System.Drawing.Size(673, 224);
            this.txtDetalle.TabIndex = 0;
            // 
            // txtTrama
            // 
            this.txtTrama.Location = new System.Drawing.Point(12, 27);
            this.txtTrama.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTrama.Multiline = true;
            this.txtTrama.Name = "txtTrama";
            this.txtTrama.ReadOnly = true;
            this.txtTrama.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTrama.Size = new System.Drawing.Size(673, 122);
            this.txtTrama.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(68, 75);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(172, 27);
            this.btnAgregarProducto.TabIndex = 4;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProductos_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(365, 469);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(92, 32);
            this.btnEjecutar.TabIndex = 5;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutars_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(480, 469);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(92, 32);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(595, 469);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 32);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblNoIngreso
            // 
            this.lblNoIngreso.AutoSize = true;
            this.lblNoIngreso.Location = new System.Drawing.Point(12, 21);
            this.lblNoIngreso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoIngreso.Name = "lblNoIngreso";
            this.lblNoIngreso.Size = new System.Drawing.Size(125, 16);
            this.lblNoIngreso.TabIndex = 0;
            this.lblNoIngreso.Text = "Número de Ingreso:";
            // 
            // lblFechaCompra
            // 
            this.lblFechaCompra.AutoSize = true;
            this.lblFechaCompra.Location = new System.Drawing.Point(12, 69);
            this.lblFechaCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaCompra.Name = "lblFechaCompra";
            this.lblFechaCompra.Size = new System.Drawing.Size(196, 16);
            this.lblFechaCompra.TabIndex = 2;
            this.lblFechaCompra.Text = "Fecha Compra (AAAA-MM-DD):";
            // 
            // lblCedulaJuridica
            // 
            this.lblCedulaJuridica.AutoSize = true;
            this.lblCedulaJuridica.Location = new System.Drawing.Point(12, 117);
            this.lblCedulaJuridica.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCedulaJuridica.Name = "lblCedulaJuridica";
            this.lblCedulaJuridica.Size = new System.Drawing.Size(103, 16);
            this.lblCedulaJuridica.TabIndex = 4;
            this.lblCedulaJuridica.Text = "Cédula Jurídica:";
            // 
            // lblNumeroTarjeta
            // 
            this.lblNumeroTarjeta.AutoSize = true;
            this.lblNumeroTarjeta.Location = new System.Drawing.Point(12, 21);
            this.lblNumeroTarjeta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumeroTarjeta.Name = "lblNumeroTarjeta";
            this.lblNumeroTarjeta.Size = new System.Drawing.Size(104, 16);
            this.lblNumeroTarjeta.TabIndex = 0;
            this.lblNumeroTarjeta.Text = "Número Tarjeta:";
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Location = new System.Drawing.Point(12, 69);
            this.lblFechaVencimiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(84, 16);
            this.lblFechaVencimiento.TabIndex = 2;
            this.lblFechaVencimiento.Text = "Vencimiento:";
            // 
            // lblCodigoVerificacion
            // 
            this.lblCodigoVerificacion.AutoSize = true;
            this.lblCodigoVerificacion.Location = new System.Drawing.Point(160, 69);
            this.lblCodigoVerificacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigoVerificacion.Name = "lblCodigoVerificacion";
            this.lblCodigoVerificacion.Size = new System.Drawing.Size(54, 16);
            this.lblCodigoVerificacion.TabIndex = 4;
            this.lblCodigoVerificacion.Text = "Código:";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(12, 21);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(134, 16);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Número de Producto:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(195, 21);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(64, 16);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblDetalle
            // 
            this.lblDetalle.Location = new System.Drawing.Point(0, 0);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(100, 23);
            this.lblDetalle.TabIndex = 0;
            // 
            // lblTrama
            // 
            this.lblTrama.Location = new System.Drawing.Point(0, 0);
            this.lblTrama.Name = "lblTrama";
            this.lblTrama.Size = new System.Drawing.Size(100, 23);
            this.lblTrama.TabIndex = 0;
            // 
            // lblInfoTarjeta
            // 
            this.lblInfoTarjeta.AutoSize = true;
            this.lblInfoTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoTarjeta.Location = new System.Drawing.Point(12, 123);
            this.lblInfoTarjeta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoTarjeta.Name = "lblInfoTarjeta";
            this.lblInfoTarjeta.Size = new System.Drawing.Size(156, 16);
            this.lblInfoTarjeta.TabIndex = 6;
            this.lblInfoTarjeta.Text = "Datos cifrados y seguros";
            // 
            // groupCompra
            // 
            this.groupCompra.Controls.Add(this.lblNoIngreso);
            this.groupCompra.Controls.Add(this.txtNoIngreso);
            this.groupCompra.Controls.Add(this.lblFechaCompra);
            this.groupCompra.Controls.Add(this.txtFechaCompra);
            this.groupCompra.Controls.Add(this.lblCedulaJuridica);
            this.groupCompra.Controls.Add(this.txtCedulaJuridica);
            this.groupCompra.Location = new System.Drawing.Point(12, 11);
            this.groupCompra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupCompra.Name = "groupCompra";
            this.groupCompra.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupCompra.Size = new System.Drawing.Size(343, 226);
            this.groupCompra.TabIndex = 0;
            this.groupCompra.TabStop = false;
            this.groupCompra.Text = "Información de Compra";
            // 
            // groupTarjeta
            // 
            this.groupTarjeta.Controls.Add(this.lblNumeroTarjeta);
            this.groupTarjeta.Controls.Add(this.txtNumeroTarjeta);
            this.groupTarjeta.Controls.Add(this.lblFechaVencimiento);
            this.groupTarjeta.Controls.Add(this.txtFechaVencimiento);
            this.groupTarjeta.Controls.Add(this.lblCodigoVerificacion);
            this.groupTarjeta.Controls.Add(this.txtCodigoVerificacion);
            this.groupTarjeta.Controls.Add(this.lblInfoTarjeta);
            this.groupTarjeta.Location = new System.Drawing.Point(16, 281);
            this.groupTarjeta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupTarjeta.Name = "groupTarjeta";
            this.groupTarjeta.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupTarjeta.Size = new System.Drawing.Size(343, 158);
            this.groupTarjeta.TabIndex = 1;
            this.groupTarjeta.TabStop = false;
            this.groupTarjeta.Text = "Datos de Pago Seguro";
            // 
            // groupProducto
            // 
            this.groupProducto.Controls.Add(this.lblProducto);
            this.groupProducto.Controls.Add(this.txtProducto);
            this.groupProducto.Controls.Add(this.lblCantidad);
            this.groupProducto.Controls.Add(this.txtCantidad);
            this.groupProducto.Controls.Add(this.btnAgregarProducto);
            this.groupProducto.Location = new System.Drawing.Point(12, 446);
            this.groupProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupProducto.Name = "groupProducto";
            this.groupProducto.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupProducto.Size = new System.Drawing.Size(343, 139);
            this.groupProducto.TabIndex = 2;
            this.groupProducto.TabStop = false;
            this.groupProducto.Text = "Agregar Producto";
            // 
            // groupDetalle
            // 
            this.groupDetalle.Controls.Add(this.txtDetalle);
            this.groupDetalle.Location = new System.Drawing.Point(365, 11);
            this.groupDetalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupDetalle.Name = "groupDetalle";
            this.groupDetalle.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupDetalle.Size = new System.Drawing.Size(697, 267);
            this.groupDetalle.TabIndex = 3;
            this.groupDetalle.TabStop = false;
            this.groupDetalle.Text = "Detalle de Compra";
            // 
            // groupTrama
            // 
            this.groupTrama.Controls.Add(this.txtTrama);
            this.groupTrama.Location = new System.Drawing.Point(365, 288);
            this.groupTrama.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupTrama.Name = "groupTrama";
            this.groupTrama.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupTrama.Size = new System.Drawing.Size(697, 160);
            this.groupTrama.TabIndex = 4;
            this.groupTrama.TabStop = false;
            this.groupTrama.Text = "Trama Generada";
            // 
            // compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 747);
            this.Controls.Add(this.groupCompra);
            this.Controls.Add(this.groupTarjeta);
            this.Controls.Add(this.groupProducto);
            this.Controls.Add(this.groupDetalle);
            this.Controls.Add(this.groupTrama);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "compras";
            this.Text = "Compras de Productos - Sistema de Pago Seguro";
            this.Load += new System.EventHandler(this.compras_Load);
            this.groupCompra.ResumeLayout(false);
            this.groupCompra.PerformLayout();
            this.groupTarjeta.ResumeLayout(false);
            this.groupTarjeta.PerformLayout();
            this.groupProducto.ResumeLayout(false);
            this.groupProducto.PerformLayout();
            this.groupDetalle.ResumeLayout(false);
            this.groupDetalle.PerformLayout();
            this.groupTrama.ResumeLayout(false);
            this.groupTrama.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtNoIngreso;
        private TextBox txtFechaCompra;
        private TextBox txtCedulaJuridica;
        private TextBox txtNumeroTarjeta;
        private TextBox txtFechaVencimiento;
        private TextBox txtCodigoVerificacion;
        private TextBox txtProducto;
        private TextBox txtCantidad;
        private TextBox txtDetalle;
        private TextBox txtTrama;
        private Button btnAgregarProducto;
        private Button btnEjecutar;
        private Button btnNuevo;
        private Button btnSalir;
        private Label lblNoIngreso;
        private Label lblFechaCompra;
        private Label lblCedulaJuridica;
        private Label lblNumeroTarjeta;
        private Label lblFechaVencimiento;
        private Label lblCodigoVerificacion;
        private Label lblProducto;
        private Label lblCantidad;
        private Label lblDetalle;
        private Label lblTrama;
        private Label lblInfoTarjeta;
        private GroupBox groupCompra;
        private GroupBox groupTarjeta;
        private GroupBox groupProducto;
        private GroupBox groupDetalle;
        private GroupBox groupTrama;
    }
}