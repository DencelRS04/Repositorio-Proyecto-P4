using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Inicio
{

    public class Proveedor
    {
        public string CedulaJuridica { get; set; }
        public string Nombre { get; set; }
        public string NombreContacto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Estado { get; set; }

        public Proveedor(string cedula, string nombre, string contacto, string telefono, string correo, int estado)
        {
            CedulaJuridica = cedula;
            Nombre = nombre;
            NombreContacto = contacto;
            Telefono = telefono;
            Correo = correo;
            Estado = estado;
        }
    }

    public partial class Mantenimiento_de_Proveedores : Form
    {
        private List<Proveedor> listaProveedores = new List<Proveedor>();

        public Mantenimiento_de_Proveedores()
        {
            InitializeComponent();
        }

        private void Mantenimiento_de_Proveedores_Load(object sender, EventArgs e)
        {
            listaProveedores.Add(new Proveedor("3100550000", "Soluciones Integrales CR", "Javier Fonseca", "89403536", "ventas@cr.com", 1));
            listaProveedores.Add(new Proveedor("3100660000", "Tecnologías Avanzadas", "Laura Méndez", "87501234", "info@ta.cr", 1));
            ActualizarGridProveedores();
        }

        private void BtnEjecutar_Click(object sender, EventArgs e)
        {
            string tipo = cmbTipoTransaccion.SelectedItem?.ToString() ?? "Ingreso";
            string codigoTipo = tipo == "Ingreso" ? "3" : "4";

            string validacion = ValidarCampos();
            if (validacion != "VALIDO")
            {
                MessageBox.Show(validacion, "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var proveedorObj = new
                {
                    op_code = codigoTipo,
                    CedulaJuridica = txtCedulaJuridica.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    NombreContacto = txtContacto.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Estado = (cmbEstado.SelectedIndex + 1).ToString()
                };

                string json = JsonConvert.SerializeObject(proveedorObj, Formatting.None);
                txtTrama.Text = json;

                string respuesta = SocketHelper.EnviarAlAlmacen(json); // asegúrate de usar el método correcto
                MessageBox.Show($"Respuesta del servidor: {respuesta}", "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (respuesta.Contains("EXITOSO"))
                {
                    if (codigoTipo == "3")
                    {
                        listaProveedores.Add(new Proveedor(
                            txtCedulaJuridica.Text.Trim(),
                            txtNombre.Text.Trim(),
                            txtContacto.Text.Trim(),
                            txtTelefono.Text.Trim(),
                            txtCorreo.Text.Trim(),
                            cmbEstado.SelectedIndex + 1
                        ));
                    }
                    else if (codigoTipo == "4")
                    {
                        var p = listaProveedores.FirstOrDefault(x => x.CedulaJuridica == txtCedulaJuridica.Text.Trim());
                        if (p != null)
                        {
                            p.Nombre = txtNombre.Text.Trim();
                            p.NombreContacto = txtContacto.Text.Trim();
                            p.Telefono = txtTelefono.Text.Trim();
                            p.Correo = txtCorreo.Text.Trim();
                            p.Estado = cmbEstado.SelectedIndex + 1;
                        }
                    }

                    ActualizarGridProveedores();
                    LimpiarFormulario();
                }
                else if (respuesta.Contains("DUPLICADO"))
                {
                    MessageBox.Show("El proveedor ya existe.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (respuesta.Contains("DATO INVÁLIDO"))
                {
                    MessageBox.Show("Dato inválido detectado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error en el proceso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidarCampos()
        {
            if (!Regex.IsMatch(txtCedulaJuridica.Text.Trim(), @"^\d{10}$"))
                return "La cédula jurídica debe tener 10 dígitos numéricos.";

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text.All(char.IsDigit))
                return "El nombre del proveedor no es válido.";

            if (string.IsNullOrWhiteSpace(txtContacto.Text) || txtContacto.Text.All(char.IsDigit))
                return "El nombre de contacto no es válido.";

            if (!Regex.IsMatch(txtTelefono.Text.Trim(), @"^\d{8}$"))
                return "El teléfono debe tener 8 dígitos.";

            if (!Regex.IsMatch(txtCorreo.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "El correo electrónico no es válido.";

            if (cmbEstado.SelectedIndex < 0)
                return "Debe seleccionar un estado.";

            if (listaProveedores.Any(p => p.CedulaJuridica == txtCedulaJuridica.Text.Trim()) &&
                cmbTipoTransaccion.SelectedItem?.ToString() == "Ingreso")
                return "DUPLICADO";

            return "VALIDO";
        }

        private void ActualizarGridProveedores()
        {
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = listaProveedores.Select(p => new
            {
                p.CedulaJuridica,
                p.Nombre,
                p.NombreContacto,
                p.Telefono,
                p.Correo,
                Estado = p.Estado == 1 ? "Activo" : "Inactivo"
            }).ToList();
        }

        private void LimpiarFormulario()
        {
            txtCedulaJuridica.Clear();
            txtNombre.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            cmbEstado.SelectedIndex = 0;
            cmbTipoTransaccion.SelectedIndex = 0;
            txtTrama.Clear();
        }

        private void DgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvProveedores.Rows[e.RowIndex];
                txtCedulaJuridica.Text = row.Cells[0].Value.ToString();
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtContacto.Text = row.Cells[2].Value.ToString();
                txtTelefono.Text = row.Cells[3].Value.ToString();
                txtCorreo.Text = row.Cells[4].Value.ToString();
                cmbEstado.SelectedIndex = row.Cells[5].Value.ToString() == "Activo" ? 0 : 1;
                cmbTipoTransaccion.SelectedItem = "Modificación";
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e) => LimpiarFormulario();
        private void BtnSalir_Click(object sender, EventArgs e) => this.Close();
        private void txtTrama_TextChanged(object sender, EventArgs e) { }
    }
}
