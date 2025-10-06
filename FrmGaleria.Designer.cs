namespace PortafolioDiseñadores
{
    partial class FrmGaleria
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
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblLikes = new System.Windows.Forms.Label();
            this.btnLike = new System.Windows.Forms.Button();
            this.lstComentarios = new System.Windows.Forms.ListBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnComentar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFiltrarLikes = new System.Windows.Forms.Button();
            this.btnBiografia = new System.Windows.Forms.Button();
            this.btnContacto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(43, 70);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(41, 14);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "label1";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(43, 113);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(165, 92);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "label2";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnterior.Location = new System.Drawing.Point(287, 324);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(87, 31);
            this.btnAnterior.TabIndex = 3;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Location = new System.Drawing.Point(431, 324);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(87, 31);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblLikes
            // 
            this.lblLikes.AutoSize = true;
            this.lblLikes.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLikes.Location = new System.Drawing.Point(225, 263);
            this.lblLikes.Name = "lblLikes";
            this.lblLikes.Size = new System.Drawing.Size(41, 14);
            this.lblLikes.TabIndex = 6;
            this.lblLikes.Text = "label1";
            // 
            // btnLike
            // 
            this.btnLike.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLike.Location = new System.Drawing.Point(83, 260);
            this.btnLike.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(75, 23);
            this.btnLike.TabIndex = 7;
            this.btnLike.Text = "Like";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // lstComentarios
            // 
            this.lstComentarios.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstComentarios.FormattingEnabled = true;
            this.lstComentarios.ItemHeight = 14;
            this.lstComentarios.Location = new System.Drawing.Point(628, 286);
            this.lstComentarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstComentarios.Name = "lstComentarios";
            this.lstComentarios.Size = new System.Drawing.Size(120, 74);
            this.lstComentarios.TabIndex = 8;
            // 
            // txtComentario
            // 
            this.txtComentario.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(628, 234);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(100, 22);
            this.txtComentario.TabIndex = 9;
            // 
            // btnComentar
            // 
            this.btnComentar.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComentar.Location = new System.Drawing.Point(628, 206);
            this.btnComentar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.Size = new System.Drawing.Size(88, 23);
            this.btnComentar.TabIndex = 10;
            this.btnComentar.Text = "Comentar";
            this.btnComentar.UseVisualStyleBackColor = true;
            this.btnComentar.Click += new System.EventHandler(this.btnComentar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(228, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 199);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnFiltrarLikes
            // 
            this.btnFiltrarLikes.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrarLikes.Location = new System.Drawing.Point(651, 55);
            this.btnFiltrarLikes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFiltrarLikes.Name = "btnFiltrarLikes";
            this.btnFiltrarLikes.Size = new System.Drawing.Size(136, 31);
            this.btnFiltrarLikes.TabIndex = 11;
            this.btnFiltrarLikes.Text = "Ordenar por Likes";
            this.btnFiltrarLikes.UseVisualStyleBackColor = true;
            this.btnFiltrarLikes.Click += new System.EventHandler(this.btnFiltrarLikes_Click);
            // 
            // btnBiografia
            // 
            this.btnBiografia.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBiografia.Location = new System.Drawing.Point(47, 409);
            this.btnBiografia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBiografia.Name = "btnBiografia";
            this.btnBiografia.Size = new System.Drawing.Size(88, 32);
            this.btnBiografia.TabIndex = 12;
            this.btnBiografia.Text = "Biografia";
            this.btnBiografia.UseVisualStyleBackColor = true;
            this.btnBiografia.Click += new System.EventHandler(this.btnBiografia_Click);
            // 
            // btnContacto
            // 
            this.btnContacto.Font = new System.Drawing.Font("Mongolian Baiti", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContacto.Location = new System.Drawing.Point(165, 409);
            this.btnContacto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnContacto.Name = "btnContacto";
            this.btnContacto.Size = new System.Drawing.Size(101, 32);
            this.btnContacto.TabIndex = 13;
            this.btnContacto.Text = "Contacto";
            this.btnContacto.UseVisualStyleBackColor = true;
            this.btnContacto.Click += new System.EventHandler(this.btnContacto_Click);
            // 
            // FrmGaleria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnContacto);
            this.Controls.Add(this.btnBiografia);
            this.Controls.Add(this.btnFiltrarLikes);
            this.Controls.Add(this.btnComentar);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.lstComentarios);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.lblLikes);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmGaleria";
            this.Text = "FrmGaleria";
            this.Load += new System.EventHandler(this.FrmGaleria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblLikes;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.ListBox lstComentarios;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnComentar;
        private System.Windows.Forms.Button btnFiltrarLikes;
        private System.Windows.Forms.Button btnBiografia;
        private System.Windows.Forms.Button btnContacto;
    }
}