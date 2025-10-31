using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Inicio
{
    public partial class Mantenimientos_de_Clientes : Form
    {
        private List<Cliente> listaClientes = new List<Cliente>();

        public Mantenimientos_de_Clientes()
        {
            InitializeComponent();
            // Remover esta línea ya que el Designer ya inicializa los controles
            // CrearControles();
            AplicarEstiloClasicoModerno();
            CargarClientesExistentes();
        }

        private void AplicarEstiloClasicoModerno()
        {
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Clientes";
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.Size = new Size(950, 800);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Aplicar estilos a los controles existentes del Designer
            if (txtIdentificacion != null)
            {
                // Estilo de los TextBox
                TextBox[] textBoxes = { txtIdentificacion, txtNombre, txtPrimerApellido, txtSegundoApellido, txtCorreo, txtTelefono, txtDireccion };
                foreach (TextBox txt in textBoxes)
                {
                    if (txt != null)
                    {
                        txt.BackColor = Color.White;
                        txt.ForeColor = Color.FromArgb(45, 45, 48);
                        txt.BorderStyle = BorderStyle.FixedSingle;
                    }
                }

                // Estilo del ComboBox
                if (cmbTipoTransaccion != null)
                {
                    cmbTipoTransaccion.BackColor = Color.White;
                    cmbTipoTransaccion.ForeColor = Color.FromArgb(45, 45, 48);
                    cmbTipoTransaccion.FlatStyle = FlatStyle.Flat;
                }

                // Estilo de botones
                Button[] botones = { btnEjecutar, btnNuevo, btnSalir };
                foreach (Button btn in botones)
                {
                    if (btn != null)
                    {
                        btn.BackColor = Color.FromArgb(240, 240, 240);
                        btn.ForeColor = Color.FromArgb(45, 45, 48);
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
                        btn.FlatAppearance.BorderSize = 1;
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 230, 230);
                        btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(220, 220, 220);
                        btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        btn.Cursor = Cursors.Hand;
                    }
                }

                // Estilo especial para botón Ejecutar
                if (btnEjecutar != null)
                {
                    btnEjecutar.BackColor = Color.FromArgb(0, 120, 215);
                    btnEjecutar.ForeColor = Color.White;
                    btnEjecutar.FlatAppearance.BorderColor = Color.FromArgb(0, 100, 195);
                    btnEjecutar.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 140, 235);
                    btnEjecutar.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 90, 175);
                }

                // Estilo para botón Salir
                if (btnSalir != null)
                {
                    btnSalir.BackColor = Color.FromArgb(215, 80, 0);
                    btnSalir.ForeColor = Color.White;
                    btnSalir.FlatAppearance.BorderColor = Color.FromArgb(195, 60, 0);
                    btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 100, 0);
                    btnSalir.FlatAppearance.MouseDownBackColor = Color.FromArgb(175, 50, 0);
                }

                // Estilo del DataGridView
                if (dgvClientes != null)
                {
                    dgvClientes.BackgroundColor = Color.White;
                    dgvClientes.BorderStyle = BorderStyle.FixedSingle;
                    dgvClientes.DefaultCellStyle.BackColor = Color.White;
                    dgvClientes.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 48);
                    dgvClientes.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
                    dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
                    dgvClientes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(45, 45, 48);

                    dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 48);
                    dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    dgvClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    dgvClientes.EnableHeadersVisualStyles = false;
                    dgvClientes.GridColor = Color.FromArgb(230, 230, 230);
                    dgvClientes.RowHeadersVisible = false;
                    dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
                }
            }
        }

        // MÉTODOS DE TU CÓDIGO ORIGINAL
        private void Mantenimientos_de_Clientes_Load(object sender, EventArgs e)
        {
            // Datos de prueba
            listaClientes.Add(new Cliente("123", "Juan", "Pérez", "López", "San José", "8888-8888", "juan@test.com"));
            listaClientes.Add(new Cliente("456", "Ana", "Gómez", "Rodríguez", "Heredia", "9999-9999", "ana@test.com"));
            ActualizarGridClientes();
        }

        private void BtnEjecutar_Click(object sender, EventArgs e)
        {
            // Obtener el tipo de transacción
            string transaccion = cmbTipoTransaccion.SelectedItem?.ToString() ?? "Agregar";

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrimerApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Crear objeto cliente para serializar a JSON
                var clienteObj = new
                {
                    Identificacion = txtIdentificacion.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido1 = txtPrimerApellido.Text.Trim(),
                    Apellido2 = txtSegundoApellido.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    transaccion = transaccion.ToLower()
                };

                // Serializar a JSON
                string json = JsonConvert.SerializeObject(clienteObj, Formatting.Indented);

                // Mostrar JSON en consola para depuración
                Console.WriteLine("[DEBUG] JSON enviado al verificador:");
                Console.WriteLine(json);

                // Enviar JSON al servidor Python
                string respuesta = SocketHelper.EnviarAlVerificador(json);

                // Mostrar respuesta cruda
                MessageBox.Show("Respuesta del Verificador: " + respuesta, "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Parsear respuesta para obtener el status
                string status = "4"; // Por defecto error
                try
                {
                    var objRespuesta = Newtonsoft.Json.Linq.JObject.Parse(respuesta);
                    status = objRespuesta["status"]?.ToString() ?? "4";
                }
                catch
                {
                    status = "4";
                }

                if (status == "1") // Éxito
                {
                    MessageBox.Show("Cliente procesado correctamente.", "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (transaccion.Equals("agregar", StringComparison.OrdinalIgnoreCase))
                    {
                        listaClientes.Add(new Cliente(
                            txtIdentificacion.Text.Trim(),
                            txtNombre.Text.Trim(),
                            txtPrimerApellido.Text.Trim(),
                            txtSegundoApellido.Text.Trim(),
                            txtDireccion.Text.Trim(),
                            txtTelefono.Text.Trim(),
                            txtCorreo.Text.Trim()
                        ));
                    }
                    else if (transaccion.Equals("modificar", StringComparison.OrdinalIgnoreCase))
                    {
                        var cliente = listaClientes.FirstOrDefault(c => c.Identificacion == txtIdentificacion.Text.Trim());
                        if (cliente != null)
                        {
                            cliente.Nombre = txtNombre.Text.Trim();
                            cliente.PrimerApellido = txtPrimerApellido.Text.Trim();
                            cliente.SegundoApellido = txtSegundoApellido.Text.Trim();
                            cliente.Direccion = txtDireccion.Text.Trim();
                            cliente.Telefono = txtTelefono.Text.Trim();
                            cliente.Correo = txtCorreo.Text.Trim();
                        }
                    }
                    else if (transaccion.Equals("eliminar", StringComparison.OrdinalIgnoreCase))
                    {
                        listaClientes.RemoveAll(c => c.Identificacion == txtIdentificacion.Text.Trim());
                    }

                    ActualizarGridClientes();
                    LimpiarFormulario();
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BtnNuevo_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void BtnSalir_Click(object sender, EventArgs e) => this.Close();

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) CargarDatosSeleccionados();
        }

        private void ActualizarGridClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaClientes
                .Select(c => new
                {
                    c.Identificacion,
                    c.Nombre,
                    c.PrimerApellido,
                    c.SegundoApellido,
                    c.Direccion,
                    c.Telefono,
                    c.Correo
                }).ToList();
        }

        private void CargarDatosSeleccionados()
        {
            if (dgvClientes.CurrentRow == null) return;
            var row = dgvClientes.CurrentRow;

            txtIdentificacion.Text = row.Cells[0].Value?.ToString() ?? "";
            txtNombre.Text = row.Cells[1].Value?.ToString() ?? "";
            txtPrimerApellido.Text = row.Cells[2].Value?.ToString() ?? "";
            txtSegundoApellido.Text = row.Cells[3].Value?.ToString() ?? "";
            txtDireccion.Text = row.Cells[4].Value?.ToString() ?? "";
            txtTelefono.Text = row.Cells[5].Value?.ToString() ?? "";
            txtCorreo.Text = row.Cells[6].Value?.ToString() ?? "";

            cmbTipoTransaccion.SelectedItem = "Modificar";
        }

        private void LimpiarFormulario()
        {
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            cmbTipoTransaccion.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrimerApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void CargarClientesExistentes()
        {
            // Ya se carga en el Load
        }

        private void txtTrama_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipoTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class Cliente
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Cliente(string identificacion, string nombre, string primerApellido, string segundoApellido,
                       string direccion, string telefono, string correo)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
        }

        public override string ToString() => $"{Identificacion} - {Nombre} {PrimerApellido}";
    }
}