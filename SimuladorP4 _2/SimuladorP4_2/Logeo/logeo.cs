using System;
using System.Drawing;
using System.Windows.Forms;

namespace Logeo
{
    public partial class logeo : Form
    {
        public logeo()
        {
            InitializeComponent();
            PersonalizarInterfaz();
        }

        private void PersonalizarInterfaz()
        {
            // Configuración básica del formulario
            this.Text = "Sistema de Login";
            this.Size = new Size(400, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Panel superior con color
            Panel panelSuperior = new Panel();
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Height = 120;
            panelSuperior.BackColor = Color.FromArgb(41, 128, 185);
            this.Controls.Add(panelSuperior);

            // Título en el panel superior
            Label lblTitulo = new Label();
            lblTitulo.Text = "BIENVENIDO";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(140, 45);
            panelSuperior.Controls.Add(lblTitulo);

            // Panel de contenido
            Panel panelContenido = new Panel();
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Padding = new Padding(40);
            this.Controls.Add(panelContenido);

            // Imagen de usuario
            PictureBox picUsuario = new PictureBox();
            picUsuario.Size = new Size(80, 80);
            picUsuario.Location = new Point(160, 20);
            picUsuario.BackColor = Color.FromArgb(230, 230, 230);
            picUsuario.SizeMode = PictureBoxSizeMode.CenterImage;
            picUsuario.Image = SystemIcons.User.ToBitmap();
            panelContenido.Controls.Add(picUsuario);

            // Etiqueta Usuario
            Label lblUsuario = new Label();
            lblUsuario.Text = "Usuario:";
            lblUsuario.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblUsuario.ForeColor = Color.FromArgb(52, 73, 94);
            lblUsuario.Location = new Point(50, 120);
            lblUsuario.AutoSize = true;
            panelContenido.Controls.Add(lblUsuario);

            // Campo de texto Usuario
            TextBox txtUsuario = new TextBox();
            txtUsuario.Name = "txt_usuario";
            txtUsuario.Location = new Point(50, 145);
            txtUsuario.Size = new Size(300, 35);
            txtUsuario.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Padding = new Padding(10);
            txtUsuario.TextChanged += txt_usuario_TextChanged;
            panelContenido.Controls.Add(txtUsuario);

            // Etiqueta Contraseña
            Label lblContraseña = new Label();
            lblContraseña.Text = "Contraseña:";
            lblContraseña.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblContraseña.ForeColor = Color.FromArgb(52, 73, 94);
            lblContraseña.Location = new Point(50, 200);
            lblContraseña.AutoSize = true;
            panelContenido.Controls.Add(lblContraseña);

            // Campo de texto Contraseña
            TextBox txtContraseña = new TextBox();
            txtContraseña.Name = "txt_contraseña";
            txtContraseña.Location = new Point(50, 225);
            txtContraseña.Size = new Size(300, 35);
            txtContraseña.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.Padding = new Padding(10);
            txtContraseña.TextChanged += txt_contraseña_TextChanged;
            panelContenido.Controls.Add(txtContraseña);

            // Botón de Login
            Button btnLogin = new Button();
            btnLogin.Text = "INICIAR SESIÓN";
            btnLogin.Location = new Point(50, 290);
            btnLogin.Size = new Size(300, 45);
            btnLogin.BackColor = Color.FromArgb(41, 128, 185);
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Click += BtnLogin_Click;
            panelContenido.Controls.Add(btnLogin);

            // Botón de Registro
            Button btnRegistro = new Button();
            btnRegistro.Text = "CREAR CUENTA";
            btnRegistro.Location = new Point(50, 345);
            btnRegistro.Size = new Size(300, 40);
            btnRegistro.BackColor = Color.FromArgb(46, 204, 113);
            btnRegistro.ForeColor = Color.White;
            btnRegistro.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRegistro.FlatStyle = FlatStyle.Flat;
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.Cursor = Cursors.Hand;
            btnRegistro.Click += BtnRegistro_Click;
            panelContenido.Controls.Add(btnRegistro);

            // Panel inferior con botones adicionales
            Panel panelInferior = new Panel();
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Height = 60;
            panelInferior.BackColor = Color.FromArgb(240, 240, 240);
            this.Controls.Add(panelInferior);

            // Botón de Inicio
            Button btnInicio = new Button();
            btnInicio.Text = "Inicio";
            btnInicio.Size = new Size(80, 30);
            btnInicio.Location = new Point(20, 15);
            btnInicio.BackColor = Color.FromArgb(52, 152, 219);
            btnInicio.ForeColor = Color.White;
            btnInicio.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.Click += BtnInicio_Click;
            panelInferior.Controls.Add(btnInicio);

            // Enlace para olvidó contraseña
            LinkLabel lnkOlvido = new LinkLabel();
            lnkOlvido.Text = "¿Olvidaste tu contraseña?";
            lnkOlvido.Location = new Point(120, 395);
            lnkOlvido.AutoSize = true;
            lnkOlvido.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lnkOlvido.LinkColor = Color.FromArgb(41, 128, 185);
            lnkOlvido.Click += LnkOlvido_Click;
            panelContenido.Controls.Add(lnkOlvido);

            // Menú strip
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem usuarioMenu = new ToolStripMenuItem("Tipo de Usuario");
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

            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación de login exitoso
            MessageBox.Show($"Bienvenido {txtUsuario.Text}", "Login Exitoso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Aquí puedes abrir el formulario principal después del login
            AbrirFormularioPrincipal();
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            // Aquí solo redirige a la ventana de registro que tú vas a crear
            // Reemplaza "FormRegistro" con el nombre de tu formulario de registro
            try
            {
                // FormRegistro formRegistro = new FormRegistro();
                // formRegistro.Show();
                // this.Hide();

                MessageBox.Show("Redirigiendo a ventana de registro...", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir ventana de registro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInicio_Click(object sender, EventArgs e)
        {
            // Limpiar campos y volver al estado inicial
            TextBox txtUsuario = this.Controls.Find("txt_usuario", true)[0] as TextBox;
            TextBox txtContraseña = this.Controls.Find("txt_contraseña", true)[0] as TextBox;

            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtUsuario.Focus();

            MessageBox.Show("Campos limpiados. Listo para ingresar nuevos datos.", "Inicio",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AbrirFormularioPrincipal()
        {
            // Aquí puedes crear y mostrar el formulario principal de tu aplicación
            // FormPrincipal formPrincipal = new FormPrincipal();
            // formPrincipal.Show();
            // this.Hide();

            MessageBox.Show("Abriendo formulario principal...", "Principal",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LnkOlvido_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de recuperación de contraseña no implementada.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Métodos existentes
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }

        private void usuarioTipo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selección de tipo de usuario", "Tipo de Usuario",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void txt_usuario_TextChanged(object sender, EventArgs e) { }

        private void txt_contraseña_TextChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }
    }
}