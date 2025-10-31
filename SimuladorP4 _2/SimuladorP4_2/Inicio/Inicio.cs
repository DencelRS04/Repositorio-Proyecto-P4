using Login;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Inicio
{
    public partial class Inicio : Form
    {
        // Controles del formulario
        private Panel panelPrincipal;
        private Panel panelContenido;
        private Button btnInicio;
        private Button btnCerrar;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private PictureBox picIcono;

        public Inicio()
        {
            InitializeComponent();
            CrearControles();
            AplicarEstilosSupermercado();
        }

        private void CrearControles()
        {
            // Configuración básica del formulario
            this.Text = "Sistema Supermercado";
            this.Size = new Size(800, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(245, 241, 235); // Color crema claro

            // Panel principal
            panelPrincipal = new Panel();
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.BackColor = Color.FromArgb(245, 241, 235);

            // Panel de contenido con sombra
            panelContenido = new Panel();
            panelContenido.Size = new Size(500, 450);
            panelContenido.Location = new Point(
                (this.ClientSize.Width - panelContenido.Width) / 2,
                (this.ClientSize.Height - panelContenido.Height) / 2
            );
            panelContenido.BackColor = Color.FromArgb(255, 253, 250);
            panelContenido.BorderStyle = BorderStyle.FixedSingle;
            panelContenido.Padding = new Padding(20);

            // Icono o imagen (usaremos un carácter Unicode como carrito)
            picIcono = new PictureBox();
            picIcono.Size = new Size(100, 100);
            picIcono.Location = new Point((panelContenido.Width - 100) / 2, 30);
            picIcono.BackColor = Color.Transparent;
            picIcono.Image = CrearIconoCarrito();
            picIcono.SizeMode = PictureBoxSizeMode.CenterImage;

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "SUPERMERCADO";
            lblTitulo.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(139, 108, 66); // Color beige oscuro
            lblTitulo.Size = new Size(panelContenido.Width - 40, 50);
            lblTitulo.Location = new Point(20, 150);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Subtítulo
            lblSubtitulo = new Label();
            lblSubtitulo.Text = "Sistema de Gestión";
            lblSubtitulo.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            lblSubtitulo.ForeColor = Color.FromArgb(166, 134, 103); // Color beige medio
            lblSubtitulo.Size = new Size(panelContenido.Width - 40, 40);
            lblSubtitulo.Location = new Point(20, 210);
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Botón de inicio
            btnInicio = new Button();
            btnInicio.Text = "INICIAR SISTEMA";
            btnInicio.Size = new Size(300, 60);
            btnInicio.Location = new Point((panelContenido.Width - 300) / 2, 280);
            btnInicio.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnInicio.Cursor = Cursors.Hand;

            // Botón cerrar
            btnCerrar = new Button();
            btnCerrar.Text = "✕";
            btnCerrar.Size = new Size(40, 40);
            btnCerrar.Location = new Point(this.ClientSize.Width - 55, 15);
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnCerrar.Cursor = Cursors.Hand;

            // Agregar controles al panel de contenido
            panelContenido.Controls.AddRange(new Control[] {
                picIcono, lblTitulo, lblSubtitulo, btnInicio
            });

            // Agregar controles al panel principal
            panelPrincipal.Controls.Add(panelContenido);
            panelPrincipal.Controls.Add(btnCerrar);

            this.Controls.Add(panelPrincipal);
        }

        private Bitmap CrearIconoCarrito()
        {
            // Crear un icono simple de carrito de compras
            Bitmap bmp = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Fondo circular
                using (Brush brush = new SolidBrush(Color.FromArgb(250, 240, 230)))
                {
                    g.FillEllipse(brush, 15, 15, 70, 70);
                }

                // Icono de carrito
                using (Pen pen = new Pen(Color.FromArgb(139, 108, 66), 4))
                {
                    // Cuerpo del carrito
                    g.DrawArc(pen, 25, 30, 50, 35, 0, 180);
                    g.DrawLine(pen, 25, 50, 20, 70);
                    g.DrawLine(pen, 75, 50, 80, 70);

                    // Ruedas
                    g.DrawEllipse(pen, 20, 65, 12, 12);
                    g.DrawEllipse(pen, 68, 65, 12, 12);
                }
            }
            return bmp;
        }

        private void AplicarEstilosSupermercado()
        {
            // Estilo panel de contenido
            panelContenido.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panelContenido.ClientRectangle,
                    Color.FromArgb(220, 210, 200), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(220, 210, 200), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(220, 210, 200), 1, ButtonBorderStyle.Solid,
                    Color.FromArgb(220, 210, 200), 1, ButtonBorderStyle.Solid);
            };

            // Estilo botón inicio
            btnInicio.BackColor = Color.FromArgb(139, 108, 66); // Beige oscuro
            btnInicio.ForeColor = Color.White;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(166, 134, 103); // Beige medio
            btnInicio.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 90, 60);  // Beige más oscuro

            // Estilo botón cerrar
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.ForeColor = Color.FromArgb(139, 108, 66);
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 17, 35);

            // Evento hover para el texto del botón cerrar
            btnCerrar.MouseEnter += (s, e) =>
            {
                btnCerrar.ForeColor = Color.White;
            };
            btnCerrar.MouseLeave += (s, e) =>
            {
                btnCerrar.ForeColor = Color.FromArgb(139, 108, 66);
            };

            // Eventos
            btnInicio.Click += button1_Click;
            btnCerrar.Click += (s, e) => this.Close();

            // Efecto hover en el panel de contenido
            panelContenido.MouseEnter += (s, e) =>
            {
                panelContenido.BackColor = Color.FromArgb(255, 255, 252);
            };
            panelContenido.MouseLeave += (s, e) =>
            {
                panelContenido.BackColor = Color.FromArgb(255, 253, 250);
            };

            // Permitir arrastrar el formulario
            panelPrincipal.MouseDown += PanelPrincipal_MouseDown;
            panelContenido.MouseDown += PanelPrincipal_MouseDown;
            lblTitulo.MouseDown += PanelPrincipal_MouseDown;
        }

        private void PanelPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            LoginI nuevaVentana = new LoginI();
            this.Hide();
            nuevaVentana.ShowDialog();
            this.Close();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // Código de carga si es necesario
        }
    }

    internal static class NativeMethods
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}
