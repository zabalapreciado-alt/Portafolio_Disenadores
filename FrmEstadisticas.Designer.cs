namespace PortafolioDiseñadores
{
    partial class FrmEstadisticas
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
            this.dgvEstadisticas = new System.Windows.Forms.DataGridView();
            this.lblProyecto = new System.Windows.Forms.Label();
            this.pbProyecto = new System.Windows.Forms.PictureBox();
            this.lstComentarios = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadisticas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProyecto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEstadisticas
            // 
            this.dgvEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadisticas.Location = new System.Drawing.Point(453, 75);
            this.dgvEstadisticas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvEstadisticas.Name = "dgvEstadisticas";
            this.dgvEstadisticas.RowHeadersWidth = 51;
            this.dgvEstadisticas.RowTemplate.Height = 24;
            this.dgvEstadisticas.Size = new System.Drawing.Size(455, 402);
            this.dgvEstadisticas.TabIndex = 0;
            this.dgvEstadisticas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstadisticas_CellContentClick);
            this.dgvEstadisticas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstadisticas_CellContentClick);
            // 
            // lblProyecto
            // 
            this.lblProyecto.AutoSize = true;
            this.lblProyecto.Location = new System.Drawing.Point(69, 75);
            this.lblProyecto.Name = "lblProyecto";
            this.lblProyecto.Size = new System.Drawing.Size(44, 16);
            this.lblProyecto.TabIndex = 1;
            this.lblProyecto.Text = "label1";
            // 
            // pbProyecto
            // 
            this.pbProyecto.Location = new System.Drawing.Point(93, 143);
            this.pbProyecto.Name = "pbProyecto";
            this.pbProyecto.Size = new System.Drawing.Size(212, 168);
            this.pbProyecto.TabIndex = 2;
            this.pbProyecto.TabStop = false;
            // 
            // lstComentarios
            // 
            this.lstComentarios.FormattingEnabled = true;
            this.lstComentarios.ItemHeight = 16;
            this.lstComentarios.Location = new System.Drawing.Point(115, 402);
            this.lstComentarios.Name = "lstComentarios";
            this.lstComentarios.Size = new System.Drawing.Size(230, 164);
            this.lstComentarios.TabIndex = 3;
            // 
            // FrmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(29)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1014, 653);
            this.Controls.Add(this.lstComentarios);
            this.Controls.Add(this.pbProyecto);
            this.Controls.Add(this.lblProyecto);
            this.Controls.Add(this.dgvEstadisticas);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmEstadisticas";
            this.Text = "FrmEstadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadisticas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProyecto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEstadisticas;
        private System.Windows.Forms.Label lblProyecto;
        private System.Windows.Forms.PictureBox pbProyecto;
        private System.Windows.Forms.ListBox lstComentarios;
    }
}