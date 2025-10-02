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
            this.lblTitulo.Location = new System.Drawing.Point(62, 50);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "label1";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(64, 108);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(35, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "label2";
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(64, 211);
            this.btnLike.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(56, 19);
            this.btnLike.TabIndex = 2;
            this.btnLike.Text = "Me gusta";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(148, 211);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(76, 24);
            this.txtComentario.TabIndex = 3;
            // 
            // btnComentar
            // 
            this.btnComentar.Location = new System.Drawing.Point(269, 211);
            this.btnComentar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.Size = new System.Drawing.Size(86, 19);
            this.btnComentar.TabIndex = 4;
            this.btnComentar.Text = "Comentar";
            this.btnComentar.UseVisualStyleBackColor = true;
            this.btnComentar.Click += new System.EventHandler(this.btnComentar_Click);
            // 
            // lstComentarios
            // 
            this.lstComentarios.FormattingEnabled = true;
            this.lstComentarios.Location = new System.Drawing.Point(428, 188);
            this.lstComentarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstComentarios.Name = "lstComentarios";
            this.lstComentarios.Size = new System.Drawing.Size(91, 69);
            this.lstComentarios.TabIndex = 5;
            // 
            // FrmDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(90)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.lstComentarios);
            this.Controls.Add(this.btnComentar);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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