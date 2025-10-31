using System;
using System.Windows.Forms;

namespace Inicio
{
    partial class Mantenimientos_de_Clientes
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtIdentificacion;
        private TextBox txtNombre;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtTrama;
        private ComboBox cmbTipoTransaccion;
        private DataGridView dgvClientes;
        private Button btnEjecutar;
        private Button btnNuevo;
        private Button btnSalir;

        // Etiquetas
        private Label lblIdentificacion;
        private Label lblNombre;
        private Label lblPrimerApellido;
        private Label lblSegundoApellido;
        private Label lblDireccion;
        private Label lblTelefono;
        private Label lblCorreo;
        private Label lblTipoTransaccion;
        private Label lblTrama;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTrama = new System.Windows.Forms.TextBox();
            this.cmbTipoTransaccion = new System.Windows.Forms.ComboBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrimerApellido = new System.Windows.Forms.Label();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblTipoTransaccion = new System.Windows.Forms.Label();
            this.lblTrama = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(30, 30);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(200, 20);
            this.txtIdentificacion.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(30, 80);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.Location = new System.Drawing.Point(30, 130);
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(200, 20);
            this.txtPrimerApellido.TabIndex = 5;
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.Location = new System.Drawing.Point(30, 180);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(200, 20);
            this.txtSegundoApellido.TabIndex = 7;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(30, 230);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 20);
            this.txtDireccion.TabIndex = 9;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(30, 280);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 11;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(30, 330);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(200, 20);
            this.txtCorreo.TabIndex = 13;
            // 
            // txtTrama
            // 
            this.txtTrama.Location = new System.Drawing.Point(30, 440);
            this.txtTrama.Multiline = true;
            this.txtTrama.Name = "txtTrama";
            this.txtTrama.ReadOnly = true;
            this.txtTrama.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTrama.Size = new System.Drawing.Size(830, 150);
            this.txtTrama.TabIndex = 17;
            this.txtTrama.TextChanged += new System.EventHandler(this.txtTrama_TextChanged);
            // 
            // cmbTipoTransaccion
            // 
            this.cmbTipoTransaccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoTransaccion.Items.AddRange(new object[] {
            "Agregar",
            "Eliminar",
            "Modificar"});
            this.cmbTipoTransaccion.Location = new System.Drawing.Point(30, 380);
            this.cmbTipoTransaccion.Name = "cmbTipoTransaccion";
            this.cmbTipoTransaccion.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoTransaccion.TabIndex = 15;
            this.cmbTipoTransaccion.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTransaccion_SelectedIndexChanged);
            // 
            // dgvClientes
            // 
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.Location = new System.Drawing.Point(260, 30);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(600, 350);
            this.dgvClientes.TabIndex = 18;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(30, 610);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(80, 30);
            this.btnEjecutar.TabIndex = 19;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.Click += new System.EventHandler(this.BtnEjecutar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(120, 610);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(80, 30);
            this.btnNuevo.TabIndex = 20;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(210, 610);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 30);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblIdentificacion.Location = new System.Drawing.Point(30, 10);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(200, 15);
            this.lblIdentificacion.TabIndex = 0;
            this.lblIdentificacion.Text = "Identificación:";
            // 
            // lblNombre
            // 
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblNombre.Location = new System.Drawing.Point(30, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(200, 15);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblPrimerApellido
            // 
            this.lblPrimerApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblPrimerApellido.Location = new System.Drawing.Point(30, 110);
            this.lblPrimerApellido.Name = "lblPrimerApellido";
            this.lblPrimerApellido.Size = new System.Drawing.Size(200, 15);
            this.lblPrimerApellido.TabIndex = 4;
            this.lblPrimerApellido.Text = "Primer Apellido:";
            // 
            // lblSegundoApellido
            // 
            this.lblSegundoApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblSegundoApellido.Location = new System.Drawing.Point(30, 160);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(200, 15);
            this.lblSegundoApellido.TabIndex = 6;
            this.lblSegundoApellido.Text = "Segundo Apellido:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblDireccion.Location = new System.Drawing.Point(30, 210);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(200, 15);
            this.lblDireccion.TabIndex = 8;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTelefono.Location = new System.Drawing.Point(30, 260);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(200, 15);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblCorreo
            // 
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblCorreo.Location = new System.Drawing.Point(30, 310);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(200, 15);
            this.lblCorreo.TabIndex = 12;
            this.lblCorreo.Text = "Correo:";
            // 
            // lblTipoTransaccion
            // 
            this.lblTipoTransaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTipoTransaccion.Location = new System.Drawing.Point(30, 360);
            this.lblTipoTransaccion.Name = "lblTipoTransaccion";
            this.lblTipoTransaccion.Size = new System.Drawing.Size(200, 15);
            this.lblTipoTransaccion.TabIndex = 14;
            this.lblTipoTransaccion.Text = "Tipo de Transacción:";
            // 
            // lblTrama
            // 
            this.lblTrama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTrama.Location = new System.Drawing.Point(30, 420);
            this.lblTrama.Name = "lblTrama";
            this.lblTrama.Size = new System.Drawing.Size(200, 15);
            this.lblTrama.TabIndex = 16;
            this.lblTrama.Text = "Trama:";
            // 
            // Mantenimientos_de_Clientes
            // 
            this.ClientSize = new System.Drawing.Size(900, 670);
            this.Controls.Add(this.lblIdentificacion);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblPrimerApellido);
            this.Controls.Add(this.txtPrimerApellido);
            this.Controls.Add(this.lblSegundoApellido);
            this.Controls.Add(this.txtSegundoApellido);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblTipoTransaccion);
            this.Controls.Add(this.cmbTipoTransaccion);
            this.Controls.Add(this.lblTrama);
            this.Controls.Add(this.txtTrama);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Name = "Mantenimientos_de_Clientes";
            this.Text = "Mantenimientos de Clientes";
            this.Load += new System.EventHandler(this.Mantenimientos_de_Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}