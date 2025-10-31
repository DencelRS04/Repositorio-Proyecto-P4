namespace Inicio
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Mprovedores;
        private System.Windows.Forms.Button Btn_EntradaProduc;
        private System.Windows.Forms.Button Btn_MantrClientes;
        private System.Windows.Forms.Button btn_Compras;
        private System.Windows.Forms.Label label1;
    }
}