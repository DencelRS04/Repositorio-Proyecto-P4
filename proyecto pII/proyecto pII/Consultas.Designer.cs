namespace proyecto_pII
{
    partial class Consultas
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
            this.Btn_Rutas = new System.Windows.Forms.Button();
            this.Btn_Buses = new System.Windows.Forms.Button();
            this.Btn_Disp = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Rutas
            // 
            this.Btn_Rutas.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Rutas.Location = new System.Drawing.Point(426, 29);
            this.Btn_Rutas.Name = "Btn_Rutas";
            this.Btn_Rutas.Size = new System.Drawing.Size(328, 94);
            this.Btn_Rutas.TabIndex = 0;
            this.Btn_Rutas.Text = "Rutas";
            this.Btn_Rutas.UseVisualStyleBackColor = true;
            // 
            // Btn_Buses
            // 
            this.Btn_Buses.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Buses.Location = new System.Drawing.Point(426, 146);
            this.Btn_Buses.Name = "Btn_Buses";
            this.Btn_Buses.Size = new System.Drawing.Size(328, 94);
            this.Btn_Buses.TabIndex = 1;
            this.Btn_Buses.Text = "Buses";
            this.Btn_Buses.UseVisualStyleBackColor = true;
            // 
            // Btn_Disp
            // 
            this.Btn_Disp.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Disp.Location = new System.Drawing.Point(426, 299);
            this.Btn_Disp.Name = "Btn_Disp";
            this.Btn_Disp.Size = new System.Drawing.Size(328, 94);
            this.Btn_Disp.TabIndex = 2;
            this.Btn_Disp.Text = "Disponibilidad";
            this.Btn_Disp.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(377, 371);
            this.dataGridView1.TabIndex = 3;
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Btn_Disp);
            this.Controls.Add(this.Btn_Buses);
            this.Controls.Add(this.Btn_Rutas);
            this.Name = "Consultas";
            this.Text = "Consultas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Rutas;
        private System.Windows.Forms.Button Btn_Buses;
        private System.Windows.Forms.Button Btn_Disp;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}