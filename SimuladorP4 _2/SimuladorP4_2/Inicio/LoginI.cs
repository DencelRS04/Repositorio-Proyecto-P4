using Inicio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Login
{
    public partial class LoginI : Form
    {
        public LoginI()
        {
            InitializeComponenta();
            PersonalizarInterfaz();
        }

        private void InitializeComponenta()
        {
            this.SuspendLayout();
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(800, 955);
            this.Name = "Login";
            this.ResumeLayout(false);
        }

        private void PersonalizarInterfaz()
        {
            // Configuración básica del formulario
            this.Text = "Sistema de Login";
            this.Size = new Size(800, 955);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // === Panel Superior ===
            Panel panelSuperior = new Panel
            {
                Dock = DockStyle.Top,
                Height = 150,
                BackColor = Color.FromArgb(41, 128, 185)
            };
            this.Controls.Add(panelSuperior);

            // Título
            Label lblTitulo = new Label
            {
                Text = "BIENVENIDO",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(300, 60)
            };
            panelSuperior.Controls.Add(lblTitulo);

            // === Panel de Contenido ===
            Panel panelContenido = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(100)
            };
            this.Controls.Add(panelContenido);

            // Imagen de usuario
            PictureBox picUsuario = new PictureBox
            {
                Size = new Size(120, 120),
                Location = new Point(290, 30),
                BackColor = Color.FromArgb(230, 230, 230),
                SizeMode = PictureBoxSizeMode.CenterImage,
            };
            panelContenido.Controls.Add(picUsuario);

            // Lista de selección de Tipo de Usuario
            Label lblTipoUsuario = new Label
            {
                Text = "Tipo de Usuario:",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(100, 180),
                AutoSize = true
            };
            panelContenido.Controls.Add(lblTipoUsuario);

            ComboBox cmbTipoUsuario = new ComboBox
            {
                Name = "cmb_tipo_usuario",
                Location = new Point(100, 210),
                Size = new Size(400, 35),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTipoUsuario.Items.AddRange(new object[] { "Usuario Tipo 1", "Usuario Tipo 2" });
            cmbTipoUsuario.SelectedIndex = 0;
            panelContenido.Controls.Add(cmbTipoUsuario);

            // Etiqueta Usuario
            Label lblUsuario = new Label
            {
                Text = "Usuario:",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(100, 270),
                AutoSize = true
            };
            panelContenido.Controls.Add(lblUsuario);

            // Campo Usuario
            TextBox txtUsuario = new TextBox
            {
                Name = "txt_usuario",
                Location = new Point(100, 300),
                Size = new Size(400, 35),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                BorderStyle = BorderStyle.FixedSingle
            };
            txtUsuario.TextChanged += txt_usuario_TextChanged;
            panelContenido.Controls.Add(txtUsuario);

            // Etiqueta Contraseña
            Label lblContraseña = new Label
            {
                Text = "Contraseña:",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(100, 360),
                AutoSize = true
            };
            panelContenido.Controls.Add(lblContraseña);

            // Campo Contraseña
            TextBox txtContraseña = new TextBox
            {
                Name = "txt_contraseña",
                Location = new Point(100, 390),
                Size = new Size(400, 35),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                BorderStyle = BorderStyle.FixedSingle,
                UseSystemPasswordChar = true
            };
            txtContraseña.TextChanged += txt_contraseña_TextChanged;
            panelContenido.Controls.Add(txtContraseña);

            // Botón Login
            Button btnLogin = new Button
            {
                Text = "INICIAR SESIÓN",
                Location = new Point(100, 460),
                Size = new Size(400, 50),
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;
            panelContenido.Controls.Add(btnLogin);

            // Botón Registro
            Button btnRegistro = new Button
            {
                Text = "CREAR CUENTA",
                Location = new Point(100, 530),
                Size = new Size(400, 45),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.Click += BtnRegistro_Click;
            panelContenido.Controls.Add(btnRegistro);

            // Enlace Olvido
            LinkLabel lnkOlvido = new LinkLabel
            {
                Text = "¿Olvidaste tu contraseña?",
                Location = new Point(220, 590),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                LinkColor = Color.FromArgb(41, 128, 185)
            };
            lnkOlvido.Click += LnkOlvido_Click;
            panelContenido.Controls.Add(lnkOlvido);

            // === Panel Inferior ===
            Panel panelInferior = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                BackColor = Color.FromArgb(240, 240, 240)
            };
            this.Controls.Add(panelInferior);

            Button btnInicio = new Button
            {
                Text = "Inicio",
                Size = new Size(100, 35),
                Location = new Point(30, 18),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.Click += BtnInicio_Click;
            panelInferior.Controls.Add(btnInicio);

            // === Menú ===
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem usuarioMenu = new ToolStripMenuItem("Opciones");
            usuarioMenu.DropDownItems.Add("Administrador", null, usuarioTipo1ToolStripMenuItem_Click);
            usuarioMenu.DropDownItems.Add("Usuario Regular", null, usuarioTipo1ToolStripMenuItem_Click);
            menuStrip.Items.Add(usuarioMenu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            TextBox txtUsuario = this.Controls.Find("txt_usuario", true)[0] as TextBox;
            TextBox txtContraseña = this.Controls.Find("txt_contraseña", true)[0] as TextBox;
            ComboBox cmbTipoUsuario = this.Controls.Find("cmb_tipo_usuario", true)[0] as ComboBox;

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipoUsuario = cmbTipoUsuario.SelectedItem.ToString();

            if (tipoUsuario == "Usuario Tipo 1")
            {
                Inicio.Menu menuForm = new Inicio.Menu();
                this.Hide();
                menuForm.ShowDialog();
                this.Close();
            }
            else if (tipoUsuario == "Usuario Tipo 2")
            {
                Inicio.compras comprasForm = new Inicio.compras();
                this.Hide(); // Oculta el login
                comprasForm.ShowDialog(); // Muestra compras
                this.Close(); // Cierra el login después de que se cierre compras
            }
            else
            {
                MessageBox.Show("Tipo de usuario no reconocido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Redirigiendo a ventana de registro...", "Registro",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Registro reg = new Registro();
            reg.ShowDialog();

        }

        private void BtnInicio_Click(object sender, EventArgs e)
        {
            TextBox txtUsuario = this.Controls.Find("txt_usuario", true)[0] as TextBox;
            TextBox txtContraseña = this.Controls.Find("txt_contraseña", true)[0] as TextBox;
            ComboBox cmbTipoUsuario = this.Controls.Find("cmb_tipo_usuario", true)[0] as ComboBox;

            txtUsuario.Clear();
            txtContraseña.Clear();
            cmbTipoUsuario.SelectedIndex = 0;
            txtUsuario.Focus();

            MessageBox.Show("Campos limpiados. Listo para ingresar nuevos datos.", "Inicio",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AbrirFormularioPrincipal()
        {
            MessageBox.Show("Abriendo formulario principal...", "Principal",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LnkOlvido_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de recuperación de contraseña no implementada.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void usuarioTipo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selección de tipo de usuario", "Tipo de Usuario",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_usuario_TextChanged(object sender, EventArgs e) { }
        private void txt_contraseña_TextChanged(object sender, EventArgs e) { }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}