using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Inicio
{
    public partial class ModificacionUsuarios : Form
    {
        // Lista simulada de usuarios (en un sistema real esto vendría de una base de datos)
        private List<Usuario> usuarios = new List<Usuario>();
        private Usuario usuarioSeleccionado = null;

        public ModificacionUsuarios()
        {
            InitializeComponent();
            PersonalizarInterfaz();
            CargarUsuariosEjemplo();
        }

        private void PersonalizarInterfaz()
        {
            // Configuración básica del formulario
            this.Text = "Mantenimiento de Usuarios";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Panel superior
            Panel panelSuperior = new Panel();
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Height = 80;
            panelSuperior.BackColor = Color.FromArgb(52, 152, 219);
            this.Controls.Add(panelSuperior);

            Label lblTitulo = new Label();
            lblTitulo.Text = "MANTENIMIENTO DE USUARIOS";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(300, 25);
            panelSuperior.Controls.Add(lblTitulo);

            // Panel principal con split
            SplitContainer splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Orientation = Orientation.Vertical;
            splitContainer.SplitterDistance = 400;
            this.Controls.Add(splitContainer);

            // === PANEL IZQUIERDO (Lista de usuarios) ===
            Panel panelLista = new Panel();
            panelLista.Dock = DockStyle.Fill;
            panelLista.Padding = new Padding(20);
            splitContainer.Panel1.Controls.Add(panelLista);

            // Label para lista
            Label lblListaUsuarios = new Label();
            lblListaUsuarios.Text = "Lista de Usuarios:";
            lblListaUsuarios.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblListaUsuarios.ForeColor = Color.FromArgb(52, 73, 94);
            lblListaUsuarios.Location = new Point(10, 10);
            lblListaUsuarios.AutoSize = true;
            panelLista.Controls.Add(lblListaUsuarios);

            // ListBox para usuarios
            ListBox listBoxUsuarios = new ListBox();
            listBoxUsuarios.Name = "listBoxUsuarios";
            listBoxUsuarios.Location = new Point(10, 40);
            listBoxUsuarios.Size = new Size(360, 300);
            listBoxUsuarios.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            listBoxUsuarios.SelectedIndexChanged += ListBoxUsuarios_SelectedIndexChanged;
            panelLista.Controls.Add(listBoxUsuarios);

            // Botón Eliminar
            Button btnEliminar = new Button();
            btnEliminar.Text = "ELIMINAR USUARIO";
            btnEliminar.Location = new Point(10, 350);
            btnEliminar.Size = new Size(360, 35);
            btnEliminar.BackColor = Color.FromArgb(231, 76, 60);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Click += BtnEliminar_Click;
            panelLista.Controls.Add(btnEliminar);

            // === PANEL DERECHO (Datos del usuario) ===
            Panel panelDatos = new Panel();
            panelDatos.Dock = DockStyle.Fill;
            panelDatos.Padding = new Padding(20);
            panelDatos.AutoScroll = true;
            splitContainer.Panel2.Controls.Add(panelDatos);

            int yPos = 20;

            // Identificación
            Label lblIdentificacion = new Label();
            lblIdentificacion.Text = "Identificación: *";
            lblIdentificacion.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblIdentificacion.ForeColor = Color.FromArgb(52, 73, 94);
            lblIdentificacion.Location = new Point(20, yPos);
            lblIdentificacion.AutoSize = true;
            panelDatos.Controls.Add(lblIdentificacion);

            TextBox txtIdentificacion = new TextBox();
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Location = new Point(20, yPos + 25);
            txtIdentificacion.Size = new Size(400, 30);
            txtIdentificacion.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtIdentificacion.BorderStyle = BorderStyle.FixedSingle;
            panelDatos.Controls.Add(txtIdentificacion);
            yPos += 60;

            // Nombre
            Label lblNombre = new Label();
            lblNombre.Text = "Nombre: *";
            lblNombre.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblNombre.ForeColor = Color.FromArgb(52, 73, 94);
            lblNombre.Location = new Point(20, yPos);
            lblNombre.AutoSize = true;
            panelDatos.Controls.Add(lblNombre);

            TextBox txtNombre = new TextBox();
            txtNombre.Name = "txtNombre";
            txtNombre.Location = new Point(20, yPos + 25);
            txtNombre.Size = new Size(400, 30);
            txtNombre.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            panelDatos.Controls.Add(txtNombre);
            yPos += 60;

            // Primer Apellido
            Label lblPrimerApellido = new Label();
            lblPrimerApellido.Text = "Primer Apellido: *";
            lblPrimerApellido.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblPrimerApellido.ForeColor = Color.FromArgb(52, 73, 94);
            lblPrimerApellido.Location = new Point(20, yPos);
            lblPrimerApellido.AutoSize = true;
            panelDatos.Controls.Add(lblPrimerApellido);

            TextBox txtPrimerApellido = new TextBox();
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Location = new Point(20, yPos + 25);
            txtPrimerApellido.Size = new Size(400, 30);
            txtPrimerApellido.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtPrimerApellido.BorderStyle = BorderStyle.FixedSingle;
            panelDatos.Controls.Add(txtPrimerApellido);
            yPos += 60;

            // Segundo Apellido
            Label lblSegundoApellido = new Label();
            lblSegundoApellido.Text = "Segundo Apellido: *";
            lblSegundoApellido.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblSegundoApellido.ForeColor = Color.FromArgb(52, 73, 94);
            lblSegundoApellido.Location = new Point(20, yPos);
            lblSegundoApellido.AutoSize = true;
            panelDatos.Controls.Add(lblSegundoApellido);

            TextBox txtSegundoApellido = new TextBox();
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Location = new Point(20, yPos + 25);
            txtSegundoApellido.Size = new Size(400, 30);
            txtSegundoApellido.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtSegundoApellido.BorderStyle = BorderStyle.FixedSingle;
            panelDatos.Controls.Add(txtSegundoApellido);
            yPos += 60;

            // Correo Electrónico
            Label lblCorreo = new Label();
            lblCorreo.Text = "Correo Electrónico: *";
            lblCorreo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblCorreo.ForeColor = Color.FromArgb(52, 73, 94);
            lblCorreo.Location = new Point(20, yPos);
            lblCorreo.AutoSize = true;
            panelDatos.Controls.Add(lblCorreo);

            TextBox txtCorreo = new TextBox();
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Location = new Point(20, yPos + 25);
            txtCorreo.Size = new Size(400, 30);
            txtCorreo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            panelDatos.Controls.Add(txtCorreo);
            yPos += 60;

            // Usuario
            Label lblUsuario = new Label();
            lblUsuario.Text = "Usuario: *";
            lblUsuario.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblUsuario.ForeColor = Color.FromArgb(52, 73, 94);
            lblUsuario.Location = new Point(20, yPos);
            lblUsuario.AutoSize = true;
            panelDatos.Controls.Add(lblUsuario);

            TextBox txtUsuario = new TextBox();
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Location = new Point(20, yPos + 25);
            txtUsuario.Size = new Size(400, 30);
            txtUsuario.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            panelDatos.Controls.Add(txtUsuario);
            yPos += 60;

            // Contraseña
            Label lblContraseña = new Label();
            lblContraseña.Text = "Contraseña (14 caracteres): *";
            lblContraseña.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblContraseña.ForeColor = Color.FromArgb(52, 73, 94);
            lblContraseña.Location = new Point(20, yPos);
            lblContraseña.AutoSize = true;
            panelDatos.Controls.Add(lblContraseña);

            TextBox txtContraseña = new TextBox();
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Location = new Point(20, yPos + 25);
            txtContraseña.Size = new Size(400, 30);
            txtContraseña.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.UseSystemPasswordChar = true;
            panelDatos.Controls.Add(txtContraseña);

            // Label de requisitos de contraseña
            Label lblRequisitos = new Label();
            lblRequisitos.Text = "Debe contener: 1 mayúscula, 1 minúscula, 1 número, 1 carácter especial";
            lblRequisitos.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblRequisitos.ForeColor = Color.FromArgb(100, 100, 100);
            lblRequisitos.Location = new Point(20, yPos + 55);
            lblRequisitos.AutoSize = true;
            panelDatos.Controls.Add(lblRequisitos);
            yPos += 85;

            // Tipo de Usuario
            Label lblTipo = new Label();
            lblTipo.Text = "Tipo de Usuario: *";
            lblTipo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblTipo.ForeColor = Color.FromArgb(52, 73, 94);
            lblTipo.Location = new Point(20, yPos);
            lblTipo.AutoSize = true;
            panelDatos.Controls.Add(lblTipo);

            ComboBox cmbTipo = new ComboBox();
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Location = new Point(20, yPos + 25);
            cmbTipo.Size = new Size(400, 30);
            cmbTipo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Items.AddRange(new object[] { "1 - Empleado", "2 - Cliente" });
            panelDatos.Controls.Add(cmbTipo);
            yPos += 60;

            // Estado
            Label lblEstado = new Label();
            lblEstado.Text = "Estado: *";
            lblEstado.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblEstado.ForeColor = Color.FromArgb(52, 73, 94);
            lblEstado.Location = new Point(20, yPos);
            lblEstado.AutoSize = true;
            panelDatos.Controls.Add(lblEstado);

            ComboBox cmbEstado = new ComboBox();
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Location = new Point(20, yPos + 25);
            cmbEstado.Size = new Size(400, 30);
            cmbEstado.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            panelDatos.Controls.Add(cmbEstado);
            yPos += 70;

            // Botones de acción
            Button btnActualizar = new Button();
            btnActualizar.Text = "ACTUALIZAR USUARIO";
            btnActualizar.Location = new Point(20, yPos);
            btnActualizar.Size = new Size(195, 40);
            btnActualizar.BackColor = Color.FromArgb(46, 204, 113);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Click += BtnActualizar_Click;
            panelDatos.Controls.Add(btnActualizar);

            Button btnLimpiar = new Button();
            btnLimpiar.Text = "LIMPIAR CAMPOS";
            btnLimpiar.Location = new Point(225, yPos);
            btnLimpiar.Size = new Size(195, 40);
            btnLimpiar.BackColor = Color.FromArgb(241, 196, 15);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.Click += BtnLimpiar_Click;
            panelDatos.Controls.Add(btnLimpiar);
        }

        private void CargarUsuariosEjemplo()
        {
            // Usuarios de ejemplo
            usuarios.Add(new Usuario
            {
                Identificacion = "123456789",
                Nombre = "Juan",
                PrimerApellido = "Pérez",
                SegundoApellido = "Gómez",
                Correo = "juan.perez@email.com",
                UsuarioNombre = "jperez",
                Contraseña = "Abc123!@#456789",
                Tipo = 1,
                Estado = "Activo"
            });

            usuarios.Add(new Usuario
            {
                Identificacion = "987654321",
                Nombre = "María",
                PrimerApellido = "López",
                SegundoApellido = "Rodríguez",
                Correo = "maria.lopez@email.com",
                UsuarioNombre = "mlopez",
                Contraseña = "Xyz789$%^123456",
                Tipo = 2,
                Estado = "Activo"
            });

            ActualizarListaUsuarios();
        }

        private void ActualizarListaUsuarios()
        {
            ListBox listBox = this.Controls.Find("listBoxUsuarios", true)[0] as ListBox;
            listBox.Items.Clear();

            foreach (var usuario in usuarios)
            {
                listBox.Items.Add($"{usuario.Identificacion} - {usuario.Nombre} {usuario.PrimerApellido} ({usuario.UsuarioNombre})");
            }
        }

        private void ListBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox.SelectedIndex >= 0)
            {
                usuarioSeleccionado = usuarios[listBox.SelectedIndex];
                CargarDatosUsuario(usuarioSeleccionado);
            }
        }

        private void CargarDatosUsuario(Usuario usuario)
        {
            TextBox txtIdentificacion = this.Controls.Find("txtIdentificacion", true)[0] as TextBox;
            TextBox txtNombre = this.Controls.Find("txtNombre", true)[0] as TextBox;
            TextBox txtPrimerApellido = this.Controls.Find("txtPrimerApellido", true)[0] as TextBox;
            TextBox txtSegundoApellido = this.Controls.Find("txtSegundoApellido", true)[0] as TextBox;
            TextBox txtCorreo = this.Controls.Find("txtCorreo", true)[0] as TextBox;
            TextBox txtUsuario = this.Controls.Find("txtUsuario", true)[0] as TextBox;
            TextBox txtContraseña = this.Controls.Find("txtContraseña", true)[0] as TextBox;
            ComboBox cmbTipo = this.Controls.Find("cmbTipo", true)[0] as ComboBox;
            ComboBox cmbEstado = this.Controls.Find("cmbEstado", true)[0] as ComboBox;

            txtIdentificacion.Text = usuario.Identificacion;
            txtNombre.Text = usuario.Nombre;
            txtPrimerApellido.Text = usuario.PrimerApellido;
            txtSegundoApellido.Text = usuario.SegundoApellido;
            txtCorreo.Text = usuario.Correo;
            txtUsuario.Text = usuario.UsuarioNombre;
            txtContraseña.Text = usuario.Contraseña;
            cmbTipo.SelectedIndex = usuario.Tipo - 1;
            cmbEstado.SelectedItem = usuario.Estado;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarDatos())
            {
                // Actualizar usuario
                usuarioSeleccionado.Nombre = (this.Controls.Find("txtNombre", true)[0] as TextBox).Text;
                usuarioSeleccionado.PrimerApellido = (this.Controls.Find("txtPrimerApellido", true)[0] as TextBox).Text;
                usuarioSeleccionado.SegundoApellido = (this.Controls.Find("txtSegundoApellido", true)[0] as TextBox).Text;
                usuarioSeleccionado.Correo = (this.Controls.Find("txtCorreo", true)[0] as TextBox).Text;
                usuarioSeleccionado.UsuarioNombre = (this.Controls.Find("txtUsuario", true)[0] as TextBox).Text;
                usuarioSeleccionado.Contraseña = (this.Controls.Find("txtContraseña", true)[0] as TextBox).Text;
                usuarioSeleccionado.Tipo = (this.Controls.Find("cmbTipo", true)[0] as ComboBox).SelectedIndex + 1;
                usuarioSeleccionado.Estado = (this.Controls.Find("cmbEstado", true)[0] as ComboBox).SelectedItem.ToString();

                ActualizarListaUsuarios();
                MessageBox.Show("Usuario actualizado exitosamente!", "Actualización Exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show($"¿Está seguro que desea eliminar al usuario {usuarioSeleccionado.UsuarioNombre}?",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                usuarios.Remove(usuarioSeleccionado);
                usuarioSeleccionado = null;
                LimpiarCampos();
                ActualizarListaUsuarios();
                MessageBox.Show("Usuario eliminado exitosamente!", "Eliminación Exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            usuarioSeleccionado = null;
            ListBox listBox = this.Controls.Find("listBoxUsuarios", true)[0] as ListBox;
            listBox.ClearSelected();
        }

        private void LimpiarCampos()
        {
            TextBox txtIdentificacion = this.Controls.Find("txtIdentificacion", true)[0] as TextBox;
            TextBox txtNombre = this.Controls.Find("txtNombre", true)[0] as TextBox;
            TextBox txtPrimerApellido = this.Controls.Find("txtPrimerApellido", true)[0] as TextBox;
            TextBox txtSegundoApellido = this.Controls.Find("txtSegundoApellido", true)[0] as TextBox;
            TextBox txtCorreo = this.Controls.Find("txtCorreo", true)[0] as TextBox;
            TextBox txtUsuario = this.Controls.Find("txtUsuario", true)[0] as TextBox;
            TextBox txtContraseña = this.Controls.Find("txtContraseña", true)[0] as TextBox;
            ComboBox cmbTipo = this.Controls.Find("cmbTipo", true)[0] as ComboBox;
            ComboBox cmbEstado = this.Controls.Find("cmbEstado", true)[0] as ComboBox;

            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtCorreo.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            cmbTipo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
        }

        private bool ValidarDatos()
        {
            // Obtener controles
            TextBox txtIdentificacion = this.Controls.Find("txtIdentificacion", true)[0] as TextBox;
            TextBox txtNombre = this.Controls.Find("txtNombre", true)[0] as TextBox;
            TextBox txtPrimerApellido = this.Controls.Find("txtPrimerApellido", true)[0] as TextBox;
            TextBox txtSegundoApellido = this.Controls.Find("txtSegundoApellido", true)[0] as TextBox;
            TextBox txtCorreo = this.Controls.Find("txtCorreo", true)[0] as TextBox;
            TextBox txtUsuario = this.Controls.Find("txtUsuario", true)[0] as TextBox;
            TextBox txtContraseña = this.Controls.Find("txtContraseña", true)[0] as TextBox;
            ComboBox cmbTipo = this.Controls.Find("cmbTipo", true)[0] as ComboBox;
            ComboBox cmbEstado = this.Controls.Find("cmbEstado", true)[0] as ComboBox;

            // Validaciones (similares al formulario de registro)
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrimerApellido.Text) ||
                string.IsNullOrWhiteSpace(txtSegundoApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                cmbTipo.SelectedIndex == -1 ||
                cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos marcados con * son obligatorios.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar contraseña
            if (!EsContraseñaValida(txtContraseña.Text))
            {
                MessageBox.Show("La contraseña debe tener exactamente 14 caracteres y contener:\n" +
                    "- Al menos una letra mayúscula\n" +
                    "- Al menos una letra minúscula\n" +
                    "- Al menos un número\n" +
                    "- Al menos un carácter especial", "Error en Contraseña",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool EsContraseñaValida(string contraseña)
        {
            if (contraseña.Length != 14)
                return false;

            bool tieneMayuscula = contraseña.Any(char.IsUpper);
            bool tieneMinuscula = contraseña.Any(char.IsLower);
            bool tieneNumero = contraseña.Any(char.IsDigit);
            bool tieneEspecial = contraseña.Any(c => !char.IsLetterOrDigit(c));

            return tieneMayuscula && tieneMinuscula && tieneNumero && tieneEspecial;
        }

        private void ModificacionUsuarios_Load(object sender, EventArgs e)
        {
            // Código de carga adicional si es necesario
        }
    }

    // Clase Usuario para almacenar los datos
    public class Usuario
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string UsuarioNombre { get; set; }
        public string Contraseña { get; set; }
        public int Tipo { get; set; } // 1-Empleado, 2-Cliente
        public string Estado { get; set; } // Activo/Inactivo
    }
}