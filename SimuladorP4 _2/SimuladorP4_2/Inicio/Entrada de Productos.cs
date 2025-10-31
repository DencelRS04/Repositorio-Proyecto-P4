using System;
using System.Drawing;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Inicio
{
    public partial class Entrada_de_Productos : Form
    {
        public Entrada_de_Productos()
        {
            InitializeComponent();
            InicializarCampos();
        }

        private void InicializarCampos()
        {
            txtFechaCompra.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (gridProductos.Columns.Count == 0)
            {
                gridProductos.Columns.Add("NumeroProducto", "No. Producto (10)");
                gridProductos.Columns.Add("Cantidad", "Cantidad (7)");
            }

            txt_num_producto.TextChanged += txt_num_producto_TextChanged;
            txt_cantidad.TextChanged += txt_cantidad_TextChanged;
            buttonAgregar.Click += buttonAgregar_Click;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            txtNumeroIngreso.Clear();
            txtFechaCompra.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtCedulaJuridica.Clear();
            gridProductos.Rows.Clear();
            txt_num_producto.Clear();
            txt_cantidad.Clear();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumeroIngreso.Text) ||
                    string.IsNullOrWhiteSpace(txtCedulaJuridica.Text) ||
                    string.IsNullOrWhiteSpace(txtFechaCompra.Text))
                {
                    MessageBox.Show("Debe completar todos los campos principales.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DateTime.TryParse(txtFechaCompra.Text, out DateTime fechaCompra))
                {
                    MessageBox.Show("La fecha de compra no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool hayDatos = false;
                foreach (DataGridViewRow row in gridProductos.Rows)
                {
                    if (!row.IsNewRow &&
                        row.Cells["NumeroProducto"].Value != null &&
                        row.Cells["Cantidad"].Value != null &&
                        !string.IsNullOrWhiteSpace(row.Cells["NumeroProducto"].Value.ToString()) &&
                        !string.IsNullOrWhiteSpace(row.Cells["Cantidad"].Value.ToString()))
                    {
                        hayDatos = true;
                        break;
                    }
                }

                if (!hayDatos)
                {
                    MessageBox.Show("Debe agregar al menos un producto con número y cantidad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string jsonTrama = GenerarJSON(fechaCompra);

                MessageBox.Show($"JSON a enviar:\n{jsonTrama}", "DEBUG - JSON Generado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                string respuesta = EnviarAlAlmacen(jsonTrama);

                if (respuesta == "EXITOSO")
                {
                    MessageBox.Show($"✅ Respuesta del almacén: {respuesta}", "Resultado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"❌ Respuesta del almacén: {respuesta}", "Resultado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar entrada de productos:\n{ex.GetType().Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerarJSON(DateTime fechaCompra)
        {
            var listaProductos = new List<object>();

            foreach (DataGridViewRow row in gridProductos.Rows)
            {
                if (!row.IsNewRow &&
                    row.Cells["NumeroProducto"].Value != null &&
                    row.Cells["Cantidad"].Value != null)
                {
                    string codigo = row.Cells["NumeroProducto"].Value.ToString().Trim();
                    string cantidadStr = row.Cells["Cantidad"].Value.ToString().Trim();

                    if (!int.TryParse(cantidadStr, out int cantidad) || cantidad <= 0)
                        continue; // Ignorar productos con cantidad inválida

                    listaProductos.Add(new
                    {
                        Codigo = codigo.PadLeft(10, '0'),
                        Cantidad = cantidad.ToString().PadLeft(7, '0')
                    });
                }
            }

            var compraData = new
            {
                op_code = "5",
                NumeroCompra = txtNumeroIngreso.Text.Trim(),
                Fecha = fechaCompra.ToString("yyyy-MM-dd"),
                CedulaJuridica = txtCedulaJuridica.Text.Trim(),
                ListaProductos = listaProductos
            };

            return JsonConvert.SerializeObject(compraData, Formatting.None).TrimStart('?');
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string numProducto = txt_num_producto.Text.Trim();
            string cantidad = txt_cantidad.Text.Trim();

            if (!int.TryParse(cantidad, out int cantidadInt) || cantidadInt <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número mayor que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in gridProductos.Rows)
            {
                if (!row.IsNewRow &&
                    row.Cells["NumeroProducto"].Value?.ToString().Trim() == numProducto)
                {
                    MessageBox.Show("Este producto ya fue agregado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            gridProductos.Rows.Add(numProducto, cantidad);
            txt_num_producto.Clear();
            txt_cantidad.Clear();
        }

        private string EnviarAlAlmacen(string jsonData)
        {
            try
            {
                string host = "localhost";
                int port = 8080;

                using (TcpClient client = new TcpClient(host, port))
                using (NetworkStream stream = client.GetStream())
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    writer.WriteLine(jsonData.TrimStart('?')); // Elimina cualquier carácter corrupto
                    string respuesta = reader.ReadLine();
                    return respuesta ?? "ERROR: Sin respuesta del servidor";
                }
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }

        private void txt_num_producto_TextChanged(object sender, EventArgs e)
        {
            txt_num_producto.BackColor = string.IsNullOrWhiteSpace(txt_num_producto.Text)
                ? Color.MistyRose
                : SystemColors.Window;
        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {
            txt_cantidad.BackColor = string.IsNullOrWhiteSpace(txt_cantidad.Text)
                ? Color.MistyRose
                : SystemColors.Window;
        }
    }
}
