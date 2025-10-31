using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;


namespace Inicio
{
    public partial class compras : Form
    {
        private List<ProveedorC> listaProveedores = new List<ProveedorC>();
        private List<ProductosT> listaProductos = new List<ProductosT>();
        private List<Compra> listaCompras = new List<Compra>();
        private List<DetalleCompra> detalleCompraActual = new List<DetalleCompra>();

        public compras()
        {
            InitializeComponent();
            AplicarEstiloClasicoModerno();
          
        }
        private void txtNoIngreso_KeyPress(object sender, KeyPressEventArgs e) { }
        private void txtFechaCompra_KeyPress(object sender, KeyPressEventArgs e) { }
        private void txtCedulaJuridica_KeyPress(object sender, KeyPressEventArgs e) { }
        private void txtNumeroTarjeta_KeyPress(object sender, KeyPressEventArgs e) { }
        private void txtFechaVencimiento_KeyPress(object sender, KeyPressEventArgs e) { }
        private void txtCodigoVerificacion_KeyPress(object sender, KeyPressEventArgs e) { }
        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e) { }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e) { }


        private void AplicarEstiloClasicoModerno()
        {
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10);

            foreach (Control control in this.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = Color.FromArgb(51, 51, 51);
                    label.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
                else if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.FromArgb(51, 51, 51);
                    textBox.Font = new Font("Segoe UI", 9);
                }
                else if (control is Button button)
                {
                    button.BackColor = Color.FromArgb(0, 122, 204);
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    button.Cursor = Cursors.Hand;
                    button.Height = 30;
                }
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.Font = new Font("Segoe UI", 9);
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    dgv.RowHeadersVisible = false;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
        }

        private void compras_Load(object sender, EventArgs e)
        {
            txtFechaCompra.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtNumeroTarjeta.SetPlaceholder("1234567812345678");
            txtFechaVencimiento.SetPlaceholder("MM/YY");
            txtCodigoVerificacion.SetPlaceholder("123");
        }


        private void ActualizarDetalleCompra()
        {
            txtDetalle.Clear();
            foreach (var d in detalleCompraActual)
            {
                var producto = listaProductos.FirstOrDefault(p => p.NoProducto == d.NoProducto);
                string nombre = producto?.Nombre ?? "N/A";
                decimal precio = producto?.Precio ?? 0;
                decimal subtotal = precio * d.Cantidad;

                txtDetalle.AppendText($"Producto: {nombre} | No: {d.NoProducto} | Cantidad: {d.Cantidad} | Precio: {precio:C} | Subtotal: {subtotal:C}\r\n");
            }
        }

        private void LimpiarCamposProducto()
        {
            txtProducto.Clear();
            txtCantidad.Clear();
            txtProducto.Focus();
        }

        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            if (ValidarProducto())
            {
                string noProducto = txtProducto.Text.Trim();
                int cantidad = int.Parse(txtCantidad.Text.Trim());
                string detalle = txtCantidad.Text.Trim();

                var producto = listaProductos.FirstOrDefault(p => p.NoProducto == noProducto);
                if (producto == null)
                {
                    MessageBox.Show("El producto no existe en el inventario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var detalleExistente = detalleCompraActual.FirstOrDefault(d => d.NoProducto == noProducto);
                if (detalleExistente != null)
                {
                    detalleExistente.Cantidad += cantidad;
                }
                else
                {
                    detalleCompraActual.Add(new DetalleCompra(noProducto, cantidad,detalle));
                }
                ActualizarDetalleCompra();
                LimpiarCamposProducto();
            }
        }

        private void btnEjecutars_Click(object sender, EventArgs e)
        {
            if (ValidarCompra() && ValidarDatosTarjeta())
            {
                try
                {
                    // Crear objeto de compra
                    var compra = new Compra(
                        txtNoIngreso.Text.Trim(),
                        txtFechaCompra.Text.Trim(),
                        txtCedulaJuridica.Text.Trim()
                    );

                    // Crear producto y agregarlo a la lista temporal
                    var producto = new DetalleCompra(
                        txtProducto.Text.Trim(),
                        int.Parse(txtCantidad.Text.Trim()),
                        txtDetalle.Text.Trim()
                    );
                    detalleCompraActual.Add(producto);

                    // Cifrar datos sensibles en Base64
                    string numeroTarjetaCifrado = Cifrar(txtNumeroTarjeta.Text.Trim());
                    string fechaVencimientoCifrado = Cifrar(txtFechaVencimiento.Text.Trim());
                    string codigoVerificacionCifrado = Cifrar(txtCodigoVerificacion.Text.Trim());

                    // Convertir lista de productos a JSON
                    var productosJsonArray = detalleCompraActual.Select(d =>
                        new
                        {
                            codigo = d.NoProducto,
                            cantidad = d.Cantidad,
                            detalle = d.Detalle
                        }).ToArray();

                    string productosJson = JsonConvert.SerializeObject(productosJsonArray);


                    // Construir JSON completo para enviar al servidor
                    string json = $@"
                    {{
                        ""datos"": {{
                            ""numero_compra"": ""{compra.NoIngreso}"",
                            ""cedula_juridica"": ""{compra.CedulaJuridica}"",
                            ""fecha_compra"": ""{compra.FechaCompra}"",
                            ""tarjeta"": ""{numeroTarjetaCifrado}"",
                            ""vencimiento"": ""{fechaVencimientoCifrado}"",
                            ""cvv"": ""{codigoVerificacionCifrado}"",
                            ""productos"": {productosJson}
                        }}
                    }}";


                    // Mostrar JSON en el textbox para depuración
                    txtTrama.Text = json;

                    // Enviar JSON al servidor Python
                    string respuesta = SocketHelper.EnviarAlVerificador(json);
                    MessageBox.Show("Respuesta del Verificador: " + respuesta, "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Manejar respuesta
                    if (respuesta.Contains("OK") || respuesta.Contains("1"))
                    {
                        listaCompras.Add(compra);
                        detalleCompraActual.Clear();
                        txtDetalle.Clear();
                        MessageBox.Show("Compra registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // ===== FUNCIONES AUXILIARES =====

        private string Cifrar(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return texto;
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            return Convert.ToBase64String(bytes);
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var d in detalleCompraActual)
            {
                var producto = listaProductos.FirstOrDefault(p => p.NoProducto == d.NoProducto);
                if (producto != null)
                    total += producto.Precio * d.Cantidad;
            }
            return total;
        }

        private bool ValidarProducto()
        {
            if (string.IsNullOrEmpty(txtProducto.Text.Trim()))
            {
                MessageBox.Show("Ingrese el número de producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProducto.Focus();
                return false;
            }
            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarCompra()
        {
            if (string.IsNullOrEmpty(txtNoIngreso.Text.Trim()))
            {
                MessageBox.Show("Ingrese el número de ingreso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoIngreso.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCedulaJuridica.Text.Trim()))
            {
                MessageBox.Show("Ingrese la cédula jurídica del proveedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedulaJuridica.Focus();
                return false;
            }
            /*if (detalleCompraActual.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }*/
            return true;
        }

        private bool ValidarDatosTarjeta()
        {
            if (string.IsNullOrEmpty(txtNumeroTarjeta.Text.Trim()) ||
                string.IsNullOrEmpty(txtFechaVencimiento.Text.Trim()) ||
                string.IsNullOrEmpty(txtCodigoVerificacion.Text.Trim()))
            {
                MessageBox.Show("Complete todos los datos de la tarjeta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNoIngreso.Clear();
            txtCedulaJuridica.Clear();
            txtProducto.Clear();
            txtCantidad.Clear();
            txtDetalle.Clear();
            txtNumeroTarjeta.Clear();
            txtFechaVencimiento.Clear();
            txtCodigoVerificacion.Clear();
            detalleCompraActual.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();

        private void txtCedulaJuridica_TextChanged(object sender, EventArgs e)
        {

        }
    }

    // ===== CLASES AUXILIARES =====
    public class Compra
    {
        public string NoIngreso { get; set; }
        public string FechaCompra { get; set; }
        public string CedulaJuridica { get; set; }

        public Compra(string noIngreso, string fechaCompra, string cedulaJuridica)
        {
            NoIngreso = noIngreso;
            FechaCompra = fechaCompra;
            CedulaJuridica = cedulaJuridica;
        }
    }

    public class ProveedorC
    {
        public string CedulaJuridica { get; set; }
        public string Nombre { get; set; }

        public ProveedorC(string cedulaJuridica, string nombre)
        {
            CedulaJuridica = cedulaJuridica;
            Nombre = nombre;
        }
    }


    public class DetalleCompra
    {
        public string NoProducto { get; set; }
        public int Cantidad { get; set; }
        
        public string Detalle { get; set; }

        public DetalleCompra(string noProducto, int cantidad,String detalle)
        {
            NoProducto = noProducto;
            Cantidad = cantidad;
            Detalle= detalle;
        }
    }

    // ===== PLACEHOLDERS =====
    public static class TextBoxExtensions
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public static void SetPlaceholder(this TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }
    }
    
}



