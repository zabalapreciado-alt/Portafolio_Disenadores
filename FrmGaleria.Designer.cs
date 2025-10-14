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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnNuevaOferta = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Impact", 10F);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(3, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(42, 18);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "label1";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Impact", 10F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(3, 60);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(124, 75);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "label2";
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnterior.FlatAppearance.BorderSize = 0;
            this.btnAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnterior.Font = new System.Drawing.Font("Impact", 13F);
            this.btnAnterior.Location = new System.Drawing.Point(141, 212);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(65, 33);
            this.btnAnterior.TabIndex = 3;
            this.btnAnterior.Text = "🡸";
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Impact", 13F);
            this.btnSiguiente.Location = new System.Drawing.Point(268, 212);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(65, 33);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "🡺";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblLikes
            // 
            this.lblLikes.AutoSize = true;
            this.lblLikes.Font = new System.Drawing.Font("Impact", 10F);
            this.lblLikes.ForeColor = System.Drawing.Color.White;
            this.lblLikes.Location = new System.Drawing.Point(129, 178);
            this.lblLikes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLikes.Name = "lblLikes";
            this.lblLikes.Size = new System.Drawing.Size(42, 18);
            this.lblLikes.TabIndex = 6;
            this.lblLikes.Text = "label1";
            // 
            // btnLike
            // 
            this.btnLike.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLike.FlatAppearance.BorderSize = 0;
            this.btnLike.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnLike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLike.Font = new System.Drawing.Font("Impact", 13F);
            this.btnLike.Location = new System.Drawing.Point(66, 167);
            this.btnLike.Margin = new System.Windows.Forms.Padding(2);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(55, 37);
            this.btnLike.TabIndex = 7;
            this.btnLike.Text = "👍";
            this.btnLike.UseVisualStyleBackColor = false;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // lstComentarios
            // 
            this.lstComentarios.BackColor = System.Drawing.Color.Teal;
            this.lstComentarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstComentarios.Font = new System.Drawing.Font("Impact", 10F);
            this.lstComentarios.ForeColor = System.Drawing.Color.White;
            this.lstComentarios.FormattingEnabled = true;
            this.lstComentarios.ItemHeight = 17;
            this.lstComentarios.Location = new System.Drawing.Point(374, 143);
            this.lstComentarios.Margin = new System.Windows.Forms.Padding(2);
            this.lstComentarios.Name = "lstComentarios";
            this.lstComentarios.Size = new System.Drawing.Size(102, 102);
            this.lstComentarios.TabIndex = 8;
            // 
            // txtComentario
            // 
            this.txtComentario.BackColor = System.Drawing.Color.Gainsboro;
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComentario.Font = new System.Drawing.Font("Impact", 10F);
            this.txtComentario.Location = new System.Drawing.Point(374, 83);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(2);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(102, 17);
            this.txtComentario.TabIndex = 9;
            // 
            // btnComentar
            // 
            this.btnComentar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnComentar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComentar.FlatAppearance.BorderSize = 0;
            this.btnComentar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnComentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComentar.Font = new System.Drawing.Font("Impact", 11F);
            this.btnComentar.ForeColor = System.Drawing.Color.White;
            this.btnComentar.Location = new System.Drawing.Point(374, 104);
            this.btnComentar.Margin = new System.Windows.Forms.Padding(2);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.Size = new System.Drawing.Size(102, 31);
            this.btnComentar.TabIndex = 10;
            this.btnComentar.Text = "Comentar";
            this.btnComentar.UseVisualStyleBackColor = false;
            this.btnComentar.Click += new System.EventHandler(this.btnComentar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(132, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 162);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnFiltrarLikes
            // 
            this.btnFiltrarLikes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnFiltrarLikes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrarLikes.FlatAppearance.BorderSize = 0;
            this.btnFiltrarLikes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnFiltrarLikes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrarLikes.Font = new System.Drawing.Font("Impact", 10F);
            this.btnFiltrarLikes.ForeColor = System.Drawing.Color.White;
            this.btnFiltrarLikes.Location = new System.Drawing.Point(374, 16);
            this.btnFiltrarLikes.Name = "btnFiltrarLikes";
            this.btnFiltrarLikes.Size = new System.Drawing.Size(102, 26);
            this.btnFiltrarLikes.TabIndex = 11;
            this.btnFiltrarLikes.Text = "ordenar";
            this.btnFiltrarLikes.UseVisualStyleBackColor = false;
            this.btnFiltrarLikes.Click += new System.EventHandler(this.btnFiltrarLikes_Click);
            // 
            // btnBiografia
            // 
            this.btnBiografia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnBiografia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBiografia.FlatAppearance.BorderSize = 0;
            this.btnBiografia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnBiografia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBiografia.Font = new System.Drawing.Font("Impact", 13F);
            this.btnBiografia.ForeColor = System.Drawing.Color.White;
            this.btnBiografia.Location = new System.Drawing.Point(44, 310);
            this.btnBiografia.Margin = new System.Windows.Forms.Padding(2);
            this.btnBiografia.Name = "btnBiografia";
            this.btnBiografia.Size = new System.Drawing.Size(97, 32);
            this.btnBiografia.TabIndex = 12;
            this.btnBiografia.Text = "Biografia";
            this.btnBiografia.UseVisualStyleBackColor = false;
            this.btnBiografia.Click += new System.EventHandler(this.btnBiografia_Click);
            // 
            // btnContacto
            // 
            this.btnContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnContacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContacto.FlatAppearance.BorderSize = 0;
            this.btnContacto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContacto.Font = new System.Drawing.Font("Impact", 13F);
            this.btnContacto.ForeColor = System.Drawing.Color.White;
            this.btnContacto.Location = new System.Drawing.Point(145, 310);
            this.btnContacto.Margin = new System.Windows.Forms.Padding(2);
            this.btnContacto.Name = "btnContacto";
            this.btnContacto.Size = new System.Drawing.Size(87, 32);
            this.btnContacto.TabIndex = 13;
            this.btnContacto.Text = "Contacto";
            this.btnContacto.UseVisualStyleBackColor = false;
            this.btnContacto.Click += new System.EventHandler(this.btnContacto_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Impact", 13F);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(445, 312);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(102, 30);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnNuevaOferta
            // 
            this.btnNuevaOferta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnNuevaOferta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaOferta.FlatAppearance.BorderSize = 0;
            this.btnNuevaOferta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnNuevaOferta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaOferta.Font = new System.Drawing.Font("Impact", 13F);
            this.btnNuevaOferta.ForeColor = System.Drawing.Color.White;
            this.btnNuevaOferta.Location = new System.Drawing.Point(236, 311);
            this.btnNuevaOferta.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevaOferta.Name = "btnNuevaOferta";
            this.btnNuevaOferta.Size = new System.Drawing.Size(115, 31);
            this.btnNuevaOferta.TabIndex = 15;
            this.btnNuevaOferta.Text = "Enviar Oferta";
            this.btnNuevaOferta.UseVisualStyleBackColor = false;
            this.btnNuevaOferta.Click += new System.EventHandler(this.btnNuevaOferta_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.btnFiltrarLikes);
            this.panel1.Controls.Add(this.btnComentar);
            this.panel1.Controls.Add(this.txtComentario);
            this.panel1.Controls.Add(this.lstComentarios);
            this.panel1.Controls.Add(this.btnLike);
            this.panel1.Controls.Add(this.lblLikes);
            this.panel1.Controls.Add(this.btnSiguiente);
            this.panel1.Controls.Add(this.btnAnterior);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(44, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 267);
            this.panel1.TabIndex = 16;
            // 
            // FrmGaleria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(574, 366);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNuevaOferta);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnContacto);
            this.Controls.Add(this.btnBiografia);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmGaleria";
            this.Text = "Proyectos";
            this.Load += new System.EventHandler(this.FrmGaleria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnNuevaOferta;
        private System.Windows.Forms.Panel panel1;
    }
}