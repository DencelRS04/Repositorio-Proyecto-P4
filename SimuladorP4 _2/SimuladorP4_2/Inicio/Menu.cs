using System;
using System.Drawing;
using System.Windows.Forms;

namespace Inicio
{
    public partial class Menu : Form
    {
        private Panel sidebar;
        private Panel contentPanel;
        private Button currentButton;
        private Label titleLabel;

        public Menu()
        {
            InitializeComponent();
            AplicarEstiloModerno();
            CrearInterfazModerna();
        }

        private void AplicarEstiloModerno()
        {
            this.BackColor = Color.FromArgb(32, 33, 36);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema Principal";
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.Size = new Size(1000, 650);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(1);
        }

        private void CrearInterfazModerna()
        {
            CrearHeader();
            CrearSidebar();
            CrearContentPanel();
        }

        private void CrearHeader()
        {
            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 60;
            header.BackColor = Color.FromArgb(44, 45, 48);

            // Eventos de arrastre para mover ventana
            header.MouseDown += TitleBar_MouseDown;
            header.MouseMove += TitleBar_MouseMove;
            header.MouseUp += TitleBar_MouseUp;

            // Título
            titleLabel = new Label();
            titleLabel.Text = "MENÚ PRINCIPAL";
            titleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            titleLabel.Dock = DockStyle.Left;
            titleLabel.Padding = new Padding(20, 0, 0, 0);
            titleLabel.Height = 60;

            // Botón cerrar
            Button btnClose = new Button();
            btnClose.Text = "✕";
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 17, 35);
            btnClose.Dock = DockStyle.Right;
            btnClose.Width = 50;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += (s, e) => this.Close();

            // Botón minimizar
            Button btnMinimize = new Button();
            btnMinimize.Text = "–";
            btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.Width = 50;
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            header.Controls.Add(btnClose);
            header.Controls.Add(btnMinimize);
            header.Controls.Add(titleLabel);
            this.Controls.Add(header);
        }

        private void CrearSidebar()
        {
            sidebar = new Panel();
            sidebar.Dock = DockStyle.Left;
            sidebar.Width = 250;
            sidebar.BackColor = Color.FromArgb(44, 45, 48);
            sidebar.Padding = new Padding(10);

            // Logo/Header del sidebar
            Panel sidebarHeader = new Panel();
            sidebarHeader.Dock = DockStyle.Top;
            sidebarHeader.Height = 100;
            sidebarHeader.BackColor = Color.Transparent;

            Label logo = new Label();
            logo.Text = "🏢 SISTEMA";
            logo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            logo.ForeColor = Color.FromArgb(0, 122, 204);
            logo.TextAlign = ContentAlignment.MiddleLeft;
            logo.Dock = DockStyle.Fill;
            logo.Padding = new Padding(10, 20, 0, 0);

            sidebarHeader.Controls.Add(logo);
            sidebar.Controls.Add(sidebarHeader);

            // Crear botones del sidebar
            string[] botones = {
                "🛒 COMPRAS",
                "👥 PROVEEDORES",
                "📦 ENTRADA PRODUCTOS",
                "👨‍💼 CLIENTES",
                "📦🛒PRODUCTOS",
                "😎MODIFICACION USUARIOS"

            };

            for (int i = 0; i < botones.Length; i++)
            {
                CrearBotonSidebar(botones[i], i);
            }

            this.Controls.Add(sidebar);
        }

        private void CrearBotonSidebar(string texto, int index)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.Tag = index;
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btn.ForeColor = Color.White;
            btn.BackColor = Color.Transparent;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 122, 204);
            btn.Height = 50;
            btn.Dock = DockStyle.Top;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.Cursor = Cursors.Hand;

            // Evento click
            btn.Click += (s, e) =>
            {
                ActivarBoton(btn);
                EjecutarFuncionalidad(index);
            };

            sidebar.Controls.Add(btn);
            btn.BringToFront();
        }

        private void ActivarBoton(Button botonActivo)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Transparent;
                currentButton.ForeColor = Color.White;
            }

            currentButton = botonActivo;
            currentButton.BackColor = Color.FromArgb(0, 122, 204);
            currentButton.ForeColor = Color.White;
        }

        private void EjecutarFuncionalidad(int index)
        {
            switch (index)
            {
                case 0:
                    btn_Compras_Click(null, null);
                    break;
                case 1:
                    Btn_Proveedores_Click(null, null);
                    break;
                case 2:
                    Btn_EntradaProduc_Click(null, null);
                    break;
                case 3:
                    Btn_Clientes_Click(null, null);
                    break;
                case 4: Btn_Productos_Click(null, null);
                    break;
                case 5: Btn_MantenientoUsu_Click(null,null);
                    break;
            }
        }

        private void CrearContentPanel()
        {
            contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.FromArgb(40, 41, 44);

            // Panel centrado
            Panel centerPanel = new Panel();
            centerPanel.Dock = DockStyle.Fill;
            centerPanel.BackColor = Color.Transparent;

            // Tarjeta de bienvenida
            Panel card = new Panel();
            card.Size = new Size(450, 400);
            card.BackColor = Color.FromArgb(50, 51, 54);
            card.Anchor = AnchorStyles.None;
            card.Padding = new Padding(20);
            card.Location = new Point(
                (this.ClientSize.Width - card.Width) / 80,  // Centrado horizontal
                (this.ClientSize.Height - card.Height) / 2 - 200 // Subido 50 píxeles
                        );

            Label welcomeTitle = new Label();
            welcomeTitle.Text = "👋 Bienvenido ";
            welcomeTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            welcomeTitle.ForeColor = Color.White;
            welcomeTitle.Location = new Point(20, 20);
            welcomeTitle.Size = new Size(350, 60);

            Label welcomeText = new Label();
            welcomeText.Text = "Selecciona una opción del menú para comenzar a utilizar el sistema.";
            welcomeText.Font = new Font("Segoe UI", 15F, FontStyle.Regular);
            welcomeText.ForeColor = Color.FromArgb(200, 200, 200);
            welcomeText.Location = new Point(20, 80);
            welcomeText.Size = new Size(400, 70);

            string[] stats = {
                "Bienvenido al sistema de almacén",
                "✓ Base de datos conectada",
                "✓ LISTO PARA SU USO",
                "Esperando su acción",
                " Recuerde ingresar bien los datos" , "  en sus respectivos campos"
            };

            for (int i = 0; i < stats.Length; i++)
            {
                Label stat = new Label();
                stat.Text = stats[i];
                stat.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
                stat.ForeColor = Color.FromArgb(0, 122, 204);
                stat.Location = new Point(20, 150 + (i * 25));
                stat.Size = new Size(300, 20);
                card.Controls.Add(stat);
            }

            card.Controls.Add(welcomeTitle);
            card.Controls.Add(welcomeText);
            centerPanel.Controls.Add(card);
            contentPanel.Controls.Add(centerPanel);
            this.Controls.Add(contentPanel);
        }

        // Métodos de formularios
        private void btn_Compras_Click(object sender, EventArgs e)
        {
            // Sustituye "compras" por el nombre de tu formulario real
            compras frm = new compras();
            frm.ShowDialog();
        }

        private void Btn_Proveedores_Click(object sender, EventArgs e)
        {
    
            // Sustituye "Mantenimiento_de_Proveedores" por el nombre real
            Mantenimiento_de_Proveedores frm = new Mantenimiento_de_Proveedores();
            frm.ShowDialog();
        }

        private void Btn_EntradaProduc_Click(object sender, EventArgs e)
        {
            // Sustituye "Entrada_de_Productos" por el nombre real
            Entrada_de_Productos frm = new Entrada_de_Productos();
            frm.ShowDialog();
        }
        private void Btn_MantenientoUsu_Click(object sender, EventArgs e)
        {
            ModificacionUsuarios fre = new ModificacionUsuarios();
            fre.ShowDialog();
        }

        private void Btn_Clientes_Click(object sender, EventArgs e)
        {
            // Sustituye "Mantenimientos_de_Clientes" por el nombre real
            Mantenimientos_de_Clientes frm = new Mantenimientos_de_Clientes();
            frm.ShowDialog();
        }
        private void Btn_Productos_Click(object sender, EventArgs e)
        {
            // Sustituye "Entrada_de_Productos" por el nombre real
            productos frm = new productos();
            frm.ShowDialog();
        }

        // -------- Drag Form --------
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Menu_Load1(object sender, EventArgs e)
        {
            MessageBox.Show(" inicio exitoso");

        }
    }
}
