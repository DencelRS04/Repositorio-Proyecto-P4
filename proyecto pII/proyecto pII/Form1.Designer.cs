namespace proyecto_pII
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificacionDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resevarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservarViajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeReservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rutasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroToolStripMenuItem,
            this.resevarToolStripMenuItem,
            this.consultarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroDeUsuarioToolStripMenuItem,
            this.modificacionDeDatosToolStripMenuItem});
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(120, 32);
            this.registroToolStripMenuItem.Text = "Registro";
            // 
            // registroDeUsuarioToolStripMenuItem
            // 
            this.registroDeUsuarioToolStripMenuItem.Name = "registroDeUsuarioToolStripMenuItem";
            this.registroDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(345, 32);
            this.registroDeUsuarioToolStripMenuItem.Text = "Registro de Usuario";
            // 
            // modificacionDeDatosToolStripMenuItem
            // 
            this.modificacionDeDatosToolStripMenuItem.Name = "modificacionDeDatosToolStripMenuItem";
            this.modificacionDeDatosToolStripMenuItem.Size = new System.Drawing.Size(345, 32);
            this.modificacionDeDatosToolStripMenuItem.Text = "Modificacion de datos";
            this.modificacionDeDatosToolStripMenuItem.Click += new System.EventHandler(this.modificacionDeDatosToolStripMenuItem_Click);
            // 
            // resevarToolStripMenuItem
            // 
            this.resevarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservarViajeToolStripMenuItem,
            this.historialDeReservasToolStripMenuItem});
            this.resevarToolStripMenuItem.Name = "resevarToolStripMenuItem";
            this.resevarToolStripMenuItem.Size = new System.Drawing.Size(119, 32);
            this.resevarToolStripMenuItem.Text = "Resevar";
            // 
            // reservarViajeToolStripMenuItem
            // 
            this.reservarViajeToolStripMenuItem.Name = "reservarViajeToolStripMenuItem";
            this.reservarViajeToolStripMenuItem.Size = new System.Drawing.Size(341, 32);
            this.reservarViajeToolStripMenuItem.Text = "Reservar viaje";
            this.reservarViajeToolStripMenuItem.Click += new System.EventHandler(this.reservarViajeToolStripMenuItem_Click);
            // 
            // historialDeReservasToolStripMenuItem
            // 
            this.historialDeReservasToolStripMenuItem.Name = "historialDeReservasToolStripMenuItem";
            this.historialDeReservasToolStripMenuItem.Size = new System.Drawing.Size(341, 32);
            this.historialDeReservasToolStripMenuItem.Text = "Historial de Reservas";
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rutasToolStripMenuItem,
            this.busesToolStripMenuItem,
            this.horariosToolStripMenuItem});
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(137, 32);
            this.consultarToolStripMenuItem.Text = "Consultar";
            // 
            // rutasToolStripMenuItem
            // 
            this.rutasToolStripMenuItem.Name = "rutasToolStripMenuItem";
            this.rutasToolStripMenuItem.Size = new System.Drawing.Size(195, 32);
            this.rutasToolStripMenuItem.Text = "Rutas";
            this.rutasToolStripMenuItem.Click += new System.EventHandler(this.rutasToolStripMenuItem_Click);
            // 
            // busesToolStripMenuItem
            // 
            this.busesToolStripMenuItem.Name = "busesToolStripMenuItem";
            this.busesToolStripMenuItem.Size = new System.Drawing.Size(195, 32);
            this.busesToolStripMenuItem.Text = "Buses";
            this.busesToolStripMenuItem.Click += new System.EventHandler(this.busesToolStripMenuItem_Click);
            // 
            // horariosToolStripMenuItem
            // 
            this.horariosToolStripMenuItem.Name = "horariosToolStripMenuItem";
            this.horariosToolStripMenuItem.Size = new System.Drawing.Size(195, 32);
            this.horariosToolStripMenuItem.Text = "Horarios";
            this.horariosToolStripMenuItem.Click += new System.EventHandler(this.horariosToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("MV Boli", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 62);
            this.label1.TabIndex = 1;
            this.label1.Text = "La Kazadora";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::proyecto_pII.Properties.Resources.imaK;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resevarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificacionDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservarViajeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeReservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rutasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horariosToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

