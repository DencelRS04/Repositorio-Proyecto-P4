using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Inicio
{
    public partial class productos : Form
    {
        private List<ProductosT> listaProductos = new List<ProductosT>();

        public productos()
        {
            InitializeComponent();
            AplicarEstiloClasicoModerno();
            CargarProductosExistentes();
        }

        private void AplicarEstiloClasicoModerno()
        {
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Productos";
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.Size = new Size(950, 700);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Estilo de los TextBox
            TextBox[] textBoxes = { txtNoProducto, txtNombre, txtPrecio, txtTrama };
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
            if (dgvProductos != null)
            {
                dgvProductos.BackgroundColor = Color.White;
                dgvProductos.BorderStyle = BorderStyle.FixedSingle;
                dgvProductos.DefaultCellStyle.BackColor = Color.White;
                dgvProductos.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 48);
                dgvProductos.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
                dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
                dgvProductos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(45, 45, 48);

                dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 48);
                dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgvProductos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvProductos.EnableHeadersVisualStyles = false;
                dgvProductos.GridColor = Color.FromArgb(230, 230, 230);
                dgvProductos.RowHeadersVisible = false;
                dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
            }

            // Estilo del TextBox de Trama
            if (txtTrama != null)
            {
                txtTrama.Multiline = true;
                txtTrama.ScrollBars = ScrollBars.Vertical;
                txtTrama.ReadOnly = true;
                txtTrama.BackColor = Color.FromArgb(248, 248, 248);
            }
        }

        private void productos_Load(object sender, EventArgs e)
        {
            // Datos de prueba
          
            ActualizarGridProductos();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            string transaccion = cmbTipoTransaccion.SelectedItem?.ToString() ?? "Ingreso";

            if (transaccion == "Ingreso")
            {
                string resultado = ValidarIngresoProducto();

                if (resultado == "VALIDO")
                {
                    

                    txtTrama.Text = GenerarTrama("1", txtNoProducto.Text.Trim(), txtNombre.Text.Trim(), txtPrecio.Text.Trim());
                    MessageBox.Show("EXITOSO - Producto agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (transaccion == "Modificación")
            {
                string resultado = ValidarModificacionProducto();

                if (resultado == "VALIDO")
                {
                    var producto = listaProductos.FirstOrDefault(p => p.NoProducto == txtNoProducto.Text.Trim());
                    if (producto != null)
                    {
                        producto.Nombre = txtNombre.Text.Trim();
                        producto.Precio = decimal.Parse(txtPrecio.Text.Trim());

                        txtTrama.Text = GenerarTrama("2", txtNoProducto.Text.Trim(), txtNombre.Text.Trim(), txtPrecio.Text.Trim());
                        MessageBox.Show("EXITOSO - Producto modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ActualizarGridProductos();
            LimpiarFormulario();
        }

        private string ValidarIngresoProducto()
        {
            // Validar número de producto
            if (string.IsNullOrWhiteSpace(txtNoProducto.Text))
                return "DATO INVÁLIDO - Número de producto requerido";

            if (txtNoProducto.Text.Trim().Length > 10)
                return "DATO INVÁLIDO - Número de producto no puede tener más de 10 caracteres";

            if (!long.TryParse(txtNoProducto.Text.Trim(), out long noProducto) || noProducto <= 0)
                return "DATO INVÁLIDO - Número de producto debe ser numérico y positivo";

            // Validar si el producto ya existe
            if (listaProductos.Any(p => p.NoProducto == txtNoProducto.Text.Trim()))
                return "DUPLICADO - El producto ya existe";

            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
                return "DATO INVÁLIDO - Nombre requerido";

            if (txtNombre.Text.Trim().Length > 90)
                return "DATO INVÁLIDO - Nombre no puede tener más de 90 caracteres";

            if (EsTextoValido(txtNombre.Text.Trim()))
                return "DATO INVÁLIDO - Nombre no válido";

            // Validar precio
            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
                return "DATO INVÁLIDO - Precio requerido";

            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio <= 0)
                return "DATO INVÁLIDO - Precio debe ser numérico y positivo";

            return "VALIDO";
        }

        private string ValidarModificacionProducto()
        {
            // Validar que el producto exista
            if (!listaProductos.Any(p => p.NoProducto == txtNoProducto.Text.Trim()))
                return "PRODUCTO INVÁLIDO - El producto no existe";

            // Validar nombre
            if (!string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                if (txtNombre.Text.Trim().Length > 90)
                    return "DATO INVÁLIDO - Nombre no puede tener más de 90 caracteres";

                if (EsTextoValido(txtNombre.Text.Trim()))
                    return "DATO INVÁLIDO - Nombre no válido";
            }

            // Validar precio
            if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio <= 0)
                    return "DATO INVÁLIDO - Precio debe ser numérico y positivo";
            }

            return "VALIDO";
        }

        private bool EsTextoValido(string texto)
        {
            // Verificar si el texto es puros números o está lleno de espacios
            return string.IsNullOrWhiteSpace(texto) || texto.All(char.IsDigit);
        }

        private string GenerarTrama(string tipoTransaccion, string noProducto, string nombre, string precio)
        {
            // Formatear según los requisitos
            string noProductoFormateado = noProducto.PadLeft(10, '0');
            string nombreFormateado = nombre.PadRight(90, ' ').Substring(0, 90);

            // Convertir precio a formato de 8 dígitos (incluyendo 2 decimales)
            decimal precioDecimal = decimal.Parse(precio);
            string precioFormateado = ((int)(precioDecimal * 100)).ToString().PadLeft(8, '0');

            return $"{tipoTransaccion}{noProductoFormateado}{nombreFormateado}{precioFormateado}";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CargarDatosSeleccionados();
            }
        }

        private void ActualizarGridProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaProductos
                .Select(p => new
                {
                    p.NoProducto,
                    p.Nombre,
                    Precio = p.Precio.ToString("C2")
                }).ToList();
        }

        private void CargarDatosSeleccionados()
        {
            if (dgvProductos.CurrentRow == null) return;
            var row = dgvProductos.CurrentRow;

            txtNoProducto.Text = row.Cells[0].Value?.ToString() ?? "";
            txtNombre.Text = row.Cells[1].Value?.ToString() ?? "";

            // Extraer el valor numérico del precio formateado
            if (row.Cells[2].Value != null)
            {
                string precioFormateado = row.Cells[2].Value.ToString();
                if (decimal.TryParse(precioFormateado.Replace("$", "").Replace(",", "").Trim(), out decimal precio))
                {
                    txtPrecio.Text = precio.ToString("F2");
                }
            }

            cmbTipoTransaccion.SelectedItem = "Modificación";
        }

        private void LimpiarFormulario()
        {
            txtNoProducto.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtTrama.Clear();
            cmbTipoTransaccion.SelectedIndex = 0;
        }

        private void CargarProductosExistentes()
        {
            // Ya se carga en el Load
        }

        // Validación en tiempo real para número de producto (solo números)
        private void txtNoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Validación en tiempo real para precio (solo números y punto decimal)
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }

   
}