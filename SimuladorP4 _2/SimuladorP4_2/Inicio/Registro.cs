using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Login;

namespace Inicio
{
    public partial class Registro : Form
    {
        // Controles como campos de clase para facilitar la validación
        private TextBox txtID, txtIdentificacion, txtNombre, txtPrimerApellido, txtSegundoApellido, txtCorreo, txtUsuario, txtContraseña;
        private ComboBox cmbTipo;

        public Registro()
        {
            InitializeComponent();
            PersonalizarInterfaz();
        }

        private void PersonalizarInterfaz()
        {
            // Configuración básica del formulario
            this.Text = "Registro de Usuario";
            this.Size = new Size(800, 1000);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Panel superior
            Panel panelSuperior = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(46, 204, 113)
            };
            this.Controls.Add(panelSuperior);

            Label lblTitulo = new Label
            {
                Text = "REGISTRO DE USUARIO",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(220, 25)
            };
            panelSuperior.Controls.Add(lblTitulo);

            // Panel de contenido
            Panel panelContenido = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(40),
                AutoScroll = true
            };
            this.Controls.Add(panelContenido);

            int yPos = 20;

            // -------------------- ID Usuario --------------------
            Label lblID = new Label();
            lblID.Text = "ID Usuario: *";
            lblID.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblID.ForeColor = Color.FromArgb(52, 73, 94);
            lblID.Location = new Point(50, yPos);
            lblID.AutoSize = true;
            panelContenido.Controls.Add(lblID);

            txtID = new TextBox();
            txtID.Name = "txtID";
            txtID.Location = new Point(50, yPos + 25);
            txtID.Size = new Size(500, 30);
            txtID.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtID.BorderStyle = BorderStyle.FixedSingle;
            txtID.MaxLength = 15; // máximo 15 números
            txtID.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };
            panelContenido.Controls.Add(txtID);
            yPos += 60;

            // -------------------- Identificación --------------------
            Label lblIdentificacion = new Label();
            lblIdentificacion.Text = "Identificación: *";
            lblIdentificacion.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblIdentificacion.ForeColor = Color.FromArgb(52, 73, 94);
            lblIdentificacion.Location = new Point(50, yPos);
            lblIdentificacion.AutoSize = true;
            panelContenido.Controls.Add(lblIdentificacion);

            txtIdentificacion = new TextBox();
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Location = new Point(50, yPos + 25);
            txtIdentificacion.Size = new Size(500, 30);
            txtIdentificacion.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtIdentificacion.BorderStyle = BorderStyle.FixedSingle;
            panelContenido.Controls.Add(txtIdentificacion);
            yPos += 60;

            // -------------------- Nombre --------------------
            Label lblNombre = new Label();
            lblNombre.Text = "Nombre: *";
            lblNombre.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblNombre.ForeColor = Color.FromArgb(52, 73, 94);
            lblNombre.Location = new Point(50, yPos);
            lblNombre.AutoSize = true;
            panelContenido.Controls.Add(lblNombre);

            txtNombre = new TextBox();
            txtNombre.Name = "txtNombre";
            txtNombre.Location = new Point(50, yPos + 25);
            txtNombre.Size = new Size(500, 30);
            txtNombre.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            panelContenido.Controls.Add(txtNombre);
            yPos += 60;

            // -------------------- Primer Apellido --------------------
            Label lblPrimerApellido = new Label();
            lblPrimerApellido.Text = "Primer Apellido: *";
            lblPrimerApellido.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblPrimerApellido.ForeColor = Color.FromArgb(52, 73, 94);
            lblPrimerApellido.Location = new Point(50, yPos);
            lblPrimerApellido.AutoSize = true;
            panelContenido.Controls.Add(lblPrimerApellido);

            txtPrimerApellido = new TextBox();
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Location = new Point(50, yPos + 25);
            txtPrimerApellido.Size = new Size(500, 30);
            txtPrimerApellido.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtPrimerApellido.BorderStyle = BorderStyle.FixedSingle;
            panelContenido.Controls.Add(txtPrimerApellido);
            yPos += 60;

            // -------------------- Segundo Apellido --------------------
            Label lblSegundoApellido = new Label();
            lblSegundoApellido.Text = "Segundo Apellido: *";
            lblSegundoApellido.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblSegundoApellido.ForeColor = Color.FromArgb(52, 73, 94);
            lblSegundoApellido.Location = new Point(50, yPos);
            lblSegundoApellido.AutoSize = true;
            panelContenido.Controls.Add(lblSegundoApellido);

            txtSegundoApellido = new TextBox();
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Location = new Point(50, yPos + 25);
            txtSegundoApellido.Size = new Size(500, 30);
            txtSegundoApellido.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtSegundoApellido.BorderStyle = BorderStyle.FixedSingle;
            panelContenido.Controls.Add(txtSegundoApellido);
            yPos += 60;

            // -------------------- Correo Electrónico --------------------
            Label lblCorreo = new Label();
            lblCorreo.Text = "Correo Electrónico: *";
            lblCorreo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblCorreo.ForeColor = Color.FromArgb(52, 73, 94);
            lblCorreo.Location = new Point(50, yPos);
            lblCorreo.AutoSize = true;
            panelContenido.Controls.Add(lblCorreo);

            txtCorreo = new TextBox();
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Location = new Point(50, yPos + 25);
            txtCorreo.Size = new Size(500, 30);
            txtCorreo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            panelContenido.Controls.Add(txtCorreo);
            yPos += 60;

            // -------------------- Usuario --------------------
            Label lblUsuario = new Label();
            lblUsuario.Text = "Usuario: *";
            lblUsuario.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblUsuario.ForeColor = Color.FromArgb(52, 73, 94);
            lblUsuario.Location = new Point(50, yPos);
            lblUsuario.AutoSize = true;
            panelContenido.Controls.Add(lblUsuario);

            txtUsuario = new TextBox();
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Location = new Point(50, yPos + 25);
            txtUsuario.Size = new Size(500, 30);
            txtUsuario.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            panelContenido.Controls.Add(txtUsuario);
            yPos += 60;

            // -------------------- Contraseña --------------------
            Label lblContraseña = new Label();
            lblContraseña.Text = "Contraseña (14 caracteres): *";
            lblContraseña.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblContraseña.ForeColor = Color.FromArgb(52, 73, 94);
            lblContraseña.Location = new Point(50, yPos);
            lblContraseña.AutoSize = true;
            panelContenido.Controls.Add(lblContraseña);

            txtContraseña = new TextBox();
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Location = new Point(50, yPos + 25);
            txtContraseña.Size = new Size(500, 30);
            txtContraseña.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.UseSystemPasswordChar = true;
            panelContenido.Controls.Add(txtContraseña);

            Label lblRequisitos = new Label();
            lblRequisitos.Text = "Debe contener: 1 mayúscula, 1 minúscula, 1 número, 1 carácter especial";
            lblRequisitos.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblRequisitos.ForeColor = Color.FromArgb(100, 100, 100);
            lblRequisitos.Location = new Point(50, yPos + 55);
            lblRequisitos.AutoSize = true;
            panelContenido.Controls.Add(lblRequisitos);
            yPos += 85;

            // -------------------- Tipo de Usuario --------------------
            Label lblTipo = new Label();
            lblTipo.Text = "Tipo de Usuario: *";
            lblTipo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblTipo.ForeColor = Color.FromArgb(52, 73, 94);
            lblTipo.Location = new Point(50, yPos);
            lblTipo.AutoSize = true;
            panelContenido.Controls.Add(lblTipo);

            cmbTipo = new ComboBox();
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Location = new Point(50, yPos + 25);
            cmbTipo.Size = new Size(500, 30);
            cmbTipo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Items.AddRange(new object[] { "1 - Empleado", "2 - Cliente" });
            panelContenido.Controls.Add(cmbTipo);
            yPos += 60;

            // -------------------- Estado --------------------
            Label lblEstado = new Label();
            lblEstado.Text = "Estado: Activo (automático para nuevos usuarios)";
            lblEstado.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblEstado.ForeColor = Color.FromArgb(52, 73, 94);
            lblEstado.Location = new Point(50, yPos);
            lblEstado.AutoSize = true;
            panelContenido.Controls.Add(lblEstado);
            yPos += 40;

            // -------------------- Botones --------------------
            Button btnRegistrar = new Button();
            btnRegistrar.Text = "REGISTRAR USUARIO";
            btnRegistrar.Location = new Point(50, yPos);
            btnRegistrar.Size = new Size(500, 45);
            btnRegistrar.BackColor = Color.FromArgb(46, 204, 113);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.Click += BtnRegistrar_Click;
            panelContenido.Controls.Add(btnRegistrar);
            yPos += 60;

            Button btnCancelar = new Button();
            btnCancelar.Text = "CANCELAR";
            btnCancelar.Location = new Point(50, yPos);
            btnCancelar.Size = new Size(500, 40);
            btnCancelar.BackColor = Color.FromArgb(231, 76, 60);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Click += BtnCancelar_Click;
            panelContenido.Controls.Add(btnCancelar);

            // -------------------- Foco inicial en ID --------------------
            this.Load += (s, e) => { txtID.Focus(); };
        }

        // -------------------- Botones --------------------
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                MessageBox.Show("Usuario registrado exitosamente!", "Registro Exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginI nww = new LoginI();
                nww.ShowDialog();
                this.Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // -------------------- Validaciones --------------------
        private bool ValidarDatos()
        {
            string errores = "";

            // Validar ID Usuario
            string id = txtID.Text.Trim();
            if (string.IsNullOrEmpty(id))
                errores += "- El ID Usuario es obligatorio.\n";
            else if (!id.All(char.IsDigit))
                errores += "- El ID Usuario debe contener solo números.\n";
            else if (id.Length > 15)
                errores += "- El ID Usuario debe tener máximo 15 dígitos.\n";

            // Validar Identificación
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
                errores += "- La identificación es obligatoria.\n";
            else if (!EsIdentificacionValida(txtIdentificacion.Text))
                errores += "- La identificación debe contener solo números.\n";

            // Validar nombre y apellidos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || !EsNombreValido(txtNombre.Text))
                errores += "- El nombre solo puede contener letras y espacios.\n";

            if (string.IsNullOrWhiteSpace(txtPrimerApellido.Text) || !EsNombreValido(txtPrimerApellido.Text))
                errores += "- El primer apellido solo puede contener letras y espacios.\n";

            if (string.IsNullOrWhiteSpace(txtSegundoApellido.Text) || !EsNombreValido(txtSegundoApellido.Text))
                errores += "- El segundo apellido solo puede contener letras y espacios.\n";

            // Validar correo
            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || !EsCorreoValido(txtCorreo.Text))
                errores += "- El correo electrónico no tiene un formato válido.\n";

            // Validar usuario
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                errores += "- El usuario es obligatorio.\n";

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(txtContraseña.Text) || !EsContraseñaValida(txtContraseña.Text))
                errores += "- La contraseña debe tener exactamente 14 caracteres y contener 1 mayúscula, 1 minúscula, 1 número y 1 carácter especial.\n";

            // Validar tipo de usuario
            if (cmbTipo.SelectedIndex == -1)
                errores += "- Debe seleccionar un tipo de usuario.\n";

            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool EsIdentificacionValida(string identificacion)
        {
            return !string.IsNullOrWhiteSpace(identificacion) && identificacion.All(char.IsDigit);
        }

        private bool EsNombreValido(string nombre)
        {
            return !string.IsNullOrWhiteSpace(nombre) &&
                   Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
        }

        private bool EsCorreoValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

        private bool EsContraseñaValida(string contraseña)
        {
            if (contraseña.Length != 14) return false;
            bool mayus = contraseña.Any(char.IsUpper);
            bool minus = contraseña.Any(char.IsLower);
            bool num = contraseña.Any(char.IsDigit);
            bool especial = contraseña.Any(c => !char.IsLetterOrDigit(c));
            return mayus && minus && num && especial;
        }
        private void Registro_Load(object sender, EventArgs e)
        {
            // Establecer estado activo por defecto (se muestra en la etiqueta)
        }
    }
}
