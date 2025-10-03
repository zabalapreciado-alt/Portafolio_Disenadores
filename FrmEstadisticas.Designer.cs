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
            this.lblProyecto = new System.Windows.Forms.Label();
            this.pbProyecto = new System.Windows.Forms.PictureBox();
            this.dgvComentarios = new System.Windows.Forms.DataGridView();
            this.dgvEstadisticas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pbProyecto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComentarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadisticas)).BeginInit();
            this.SuspendLayout();
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
            // dgvComentarios
            // 
            this.dgvComentarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComentarios.Location = new System.Drawing.Point(72, 372);
            this.dgvComentarios.Name = "dgvComentarios";
            this.dgvComentarios.RowHeadersWidth = 51;
            this.dgvComentarios.RowTemplate.Height = 24;
            this.dgvComentarios.Size = new System.Drawing.Size(840, 150);
            this.dgvComentarios.TabIndex = 3;
            // 
            // dgvEstadisticas
            // 
            this.dgvEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadisticas.Location = new System.Drawing.Point(361, 75);
            this.dgvEstadisticas.Name = "dgvEstadisticas";
            this.dgvEstadisticas.RowHeadersWidth = 51;
            this.dgvEstadisticas.RowTemplate.Height = 24;
            this.dgvEstadisticas.Size = new System.Drawing.Size(533, 195);
            this.dgvEstadisticas.TabIndex = 4;
            this.dgvEstadisticas.SelectionChanged += new System.EventHandler(this.dgvEstadisticas_SelectionChanged);
            // 
            // FrmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(29)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(1014, 653);
            this.Controls.Add(this.dgvEstadisticas);
            this.Controls.Add(this.dgvComentarios);
            this.Controls.Add(this.pbProyecto);
            this.Controls.Add(this.lblProyecto);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmEstadisticas";
            this.Text = "FrmEstadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.pbProyecto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComentarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadisticas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblProyecto;
        private System.Windows.Forms.PictureBox pbProyecto;
        private System.Windows.Forms.DataGridView dgvComentarios;
        private System.Windows.Forms.DataGridView dgvEstadisticas;
    }
}