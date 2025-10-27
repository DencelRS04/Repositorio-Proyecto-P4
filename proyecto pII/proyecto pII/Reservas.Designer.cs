namespace proyecto_pII
{
    partial class Reservas
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
            this.Btn_AR = new System.Windows.Forms.Button();
            this.Btn_MR = new System.Windows.Forms.Button();
            this.dataGridViewReser = new System.Windows.Forms.DataGridView();
            this.lbl_idR = new System.Windows.Forms.Label();
            this.lbl_Ruta = new System.Windows.Forms.Label();
            this.txt_Hora = new System.Windows.Forms.TextBox();
            this.txt_Ruta = new System.Windows.Forms.TextBox();
            this.Fechas = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_IdR = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReser)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_AR
            // 
            this.Btn_AR.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AR.Location = new System.Drawing.Point(558, 52);
            this.Btn_AR.Name = "Btn_AR";
            this.Btn_AR.Size = new System.Drawing.Size(209, 47);
            this.Btn_AR.TabIndex = 0;
            this.Btn_AR.Text = "Agregar Reserva";
            this.Btn_AR.UseVisualStyleBackColor = true;
            this.Btn_AR.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_MR
            // 
            this.Btn_MR.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_MR.Location = new System.Drawing.Point(558, 119);
            this.Btn_MR.Name = "Btn_MR";
            this.Btn_MR.Size = new System.Drawing.Size(209, 47);
            this.Btn_MR.TabIndex = 1;
            this.Btn_MR.Text = "Modificar Reserva";
            this.Btn_MR.UseVisualStyleBackColor = true;
            this.Btn_MR.Click += new System.EventHandler(this.Btn_MR_Click);
            // 
            // dataGridViewReser
            // 
            this.dataGridViewReser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReser.Location = new System.Drawing.Point(27, 25);
            this.dataGridViewReser.Name = "dataGridViewReser";
            this.dataGridViewReser.RowHeadersWidth = 51;
            this.dataGridViewReser.RowTemplate.Height = 24;
            this.dataGridViewReser.Size = new System.Drawing.Size(485, 222);
            this.dataGridViewReser.TabIndex = 2;
            // 
            // lbl_idR
            // 
            this.lbl_idR.AutoSize = true;
            this.lbl_idR.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_idR.Location = new System.Drawing.Point(37, 266);
            this.lbl_idR.Name = "lbl_idR";
            this.lbl_idR.Size = new System.Drawing.Size(123, 22);
            this.lbl_idR.TabIndex = 4;
            this.lbl_idR.Text = "Identificacion";
            // 
            // lbl_Ruta
            // 
            this.lbl_Ruta.AutoSize = true;
            this.lbl_Ruta.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ruta.Location = new System.Drawing.Point(298, 266);
            this.lbl_Ruta.Name = "lbl_Ruta";
            this.lbl_Ruta.Size = new System.Drawing.Size(49, 22);
            this.lbl_Ruta.TabIndex = 5;
            this.lbl_Ruta.Text = "Ruta";
            // 
            // txt_Hora
            // 
            this.txt_Hora.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Hora.Location = new System.Drawing.Point(498, 311);
            this.txt_Hora.Name = "txt_Hora";
            this.txt_Hora.Size = new System.Drawing.Size(175, 29);
            this.txt_Hora.TabIndex = 7;
            // 
            // txt_Ruta
            // 
            this.txt_Ruta.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ruta.Location = new System.Drawing.Point(253, 311);
            this.txt_Ruta.Name = "txt_Ruta";
            this.txt_Ruta.Size = new System.Drawing.Size(175, 29);
            this.txt_Ruta.TabIndex = 8;
            // 
            // Fechas
            // 
            this.Fechas.Location = new System.Drawing.Point(518, 183);
            this.Fechas.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.Fechas.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.Fechas.Name = "Fechas";
            this.Fechas.Size = new System.Drawing.Size(279, 22);
            this.Fechas.TabIndex = 9;
            this.Fechas.Value = new System.DateTime(2025, 3, 7, 0, 0, 0, 0);
            this.Fechas.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(514, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Hora";
            // 
            // txt_IdR
            // 
            this.txt_IdR.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IdR.Location = new System.Drawing.Point(27, 311);
            this.txt_IdR.Name = "txt_IdR";
            this.txt_IdR.Size = new System.Drawing.Size(175, 29);
            this.txt_IdR.TabIndex = 11;
            // 
            // Reservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_IdR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Fechas);
            this.Controls.Add(this.txt_Ruta);
            this.Controls.Add(this.txt_Hora);
            this.Controls.Add(this.lbl_Ruta);
            this.Controls.Add(this.lbl_idR);
            this.Controls.Add(this.dataGridViewReser);
            this.Controls.Add(this.Btn_MR);
            this.Controls.Add(this.Btn_AR);
            this.Name = "Reservas";
            this.Text = "Reservas";
            this.Load += new System.EventHandler(this.Reservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_AR;
        private System.Windows.Forms.Button Btn_MR;
        private System.Windows.Forms.DataGridView dataGridViewReser;
        private System.Windows.Forms.Label lbl_idR;
        private System.Windows.Forms.Label lbl_Ruta;
        private System.Windows.Forms.TextBox txt_Hora;
        private System.Windows.Forms.TextBox txt_Ruta;
        private System.Windows.Forms.DateTimePicker Fechas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_IdR;
    }
}