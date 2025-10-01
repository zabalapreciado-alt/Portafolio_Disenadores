namespace PortafolioDiseñadores
{
    partial class FrmDetalles
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnLike = new System.Windows.Forms.Button();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnComentar = new System.Windows.Forms.Button();
            this.lstComentarios = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(83, 61);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(44, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "label1";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(86, 133);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(44, 16);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "label2";
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(86, 260);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(75, 23);
            this.btnLike.TabIndex = 2;
            this.btnLike.Text = "Me gusta";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(197, 260);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(100, 29);
            this.txtComentario.TabIndex = 3;
            // 
            // btnComentar
            // 
            this.btnComentar.Location = new System.Drawing.Point(359, 260);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.Size = new System.Drawing.Size(114, 23);
            this.btnComentar.TabIndex = 4;
            this.btnComentar.Text = "Comentar";
            this.btnComentar.UseVisualStyleBackColor = true;
            this.btnComentar.Click += new System.EventHandler(this.btnComentar_Click);
            // 
            // lstComentarios
            // 
            this.lstComentarios.FormattingEnabled = true;
            this.lstComentarios.ItemHeight = 16;
            this.lstComentarios.Location = new System.Drawing.Point(570, 232);
            this.lstComentarios.Name = "lstComentarios";
            this.lstComentarios.Size = new System.Drawing.Size(120, 84);
            this.lstComentarios.TabIndex = 5;
            // 
            // FrmDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstComentarios);
            this.Controls.Add(this.btnComentar);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmDetalles";
            this.Text = "FrmDetalles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnComentar;
        private System.Windows.Forms.ListBox lstComentarios;
    }
}