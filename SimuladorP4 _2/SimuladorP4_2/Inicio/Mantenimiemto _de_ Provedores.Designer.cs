using System;
using System.Windows.Forms;

namespace Inicio
{
    partial class Mantenimiento_de_Proveedores
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtCedulaJuridica;
        private TextBox txtNombre;
        private TextBox txtContacto;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtTrama;
        private ComboBox cmbTipoTransaccion;
        private ComboBox cmbEstado;
        private DataGridView dgvProveedores;
        private Button btnEjecutar;
        private Button btnNuevo;
        private Button btnSalir;
        private Label lblCedula;
        private Label lblNombre;
        private Label lblContacto;
        private Label lblTelefono;
        private Label lblCorreo;
        private Label lblEstado;
        private Label lblTipoTransaccion;
        private Label lblTrama;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtCedulaJuridica = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTrama = new System.Windows.Forms.TextBox();
            this.cmbTipoTransaccion = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTipoTransaccion = new System.Windows.Forms.Label();
            this.lblTrama = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCedulaJuridica
            // 
            this.txtCedulaJuridica.Location = new System.Drawing.Point(30, 40);
            this.txtCedulaJuridica.Name = "txtCedulaJuridica";
            this.txtCedulaJuridica.Size = new System.Drawing.Size(100, 22);
            this.txtCedulaJuridica.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(30, 100);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 22);
            this.txtNombre.TabIndex = 3;
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(30, 160);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(100, 22);
            this.txtContacto.TabIndex = 5;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(30, 220);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 22);
            this.txtTelefono.TabIndex = 7;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(30, 280);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(100, 22);
            this.txtCorreo.TabIndex = 9;
            // 
            // txtTrama
            // 
            this.txtTrama.Location = new System.Drawing.Point(30, 460);
            this.txtTrama.Multiline = true;
            this.txtTrama.Name = "txtTrama";
            this.txtTrama.ReadOnly = true;
            this.txtTrama.Size = new System.Drawing.Size(830, 150);
            this.txtTrama.TabIndex = 15;
            this.txtTrama.TextChanged += new System.EventHandler(this.txtTrama_TextChanged);
            // 
            // cmbTipoTransaccion
            // 
            this.cmbTipoTransaccion.Items.AddRange(new object[] {
            "Ingreso",
            "Modificación"});
            this.cmbTipoTransaccion.Location = new System.Drawing.Point(30, 400);
            this.cmbTipoTransaccion.Name = "cmbTipoTransaccion";
            this.cmbTipoTransaccion.Size = new System.Drawing.Size(121, 24);
            this.cmbTipoTransaccion.TabIndex = 13;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(30, 340);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 24);
            this.cmbEstado.TabIndex = 11;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.ColumnHeadersHeight = 29;
            this.dgvProveedores.Location = new System.Drawing.Point(280, 40);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersWidth = 51;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(580, 350);
            this.dgvProveedores.TabIndex = 16;
            this.dgvProveedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProveedores_CellClick);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(30, 630);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(154, 35);
            this.btnEjecutar.TabIndex = 17;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.Click += new System.EventHandler(this.BtnEjecutar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(190, 630);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(154, 35);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(361, 630);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(154, 35);
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // lblCedula
            // 
            this.lblCedula.Location = new System.Drawing.Point(30, 20);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(100, 23);
            this.lblCedula.TabIndex = 0;
            this.lblCedula.Text = "Cédula Jurídica:";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(30, 80);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblContacto
            // 
            this.lblContacto.Location = new System.Drawing.Point(30, 140);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(100, 23);
            this.lblContacto.TabIndex = 4;
            this.lblContacto.Text = "Nombre del Contacto:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.Location = new System.Drawing.Point(30, 200);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(100, 23);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblCorreo
            // 
            this.lblCorreo.Location = new System.Drawing.Point(30, 260);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(100, 23);
            this.lblCorreo.TabIndex = 8;
            this.lblCorreo.Text = "Correo Electrónico:";
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(30, 320);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 23);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado:";
            // 
            // lblTipoTransaccion
            // 
            this.lblTipoTransaccion.Location = new System.Drawing.Point(30, 380);
            this.lblTipoTransaccion.Name = "lblTipoTransaccion";
            this.lblTipoTransaccion.Size = new System.Drawing.Size(100, 23);
            this.lblTipoTransaccion.TabIndex = 12;
            this.lblTipoTransaccion.Text = "Tipo de Transacción:";
            // 
            // lblTrama
            // 
            this.lblTrama.Location = new System.Drawing.Point(30, 440);
            this.lblTrama.Name = "lblTrama";
            this.lblTrama.Size = new System.Drawing.Size(100, 23);
            this.lblTrama.TabIndex = 14;
            this.lblTrama.Text = "Trama (JSON):";
            // 
            // Mantenimiento_de_Proveedores
            // 
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.txtCedulaJuridica);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lblTipoTransaccion);
            this.Controls.Add(this.cmbTipoTransaccion);
            this.Controls.Add(this.lblTrama);
            this.Controls.Add(this.txtTrama);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Name = "Mantenimiento_de_Proveedores";
            this.Text = "Mantenimiento de Proveedores";
            this.Load += new System.EventHandler(this.Mantenimiento_de_Proveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
