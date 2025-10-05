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
            this.btnDetalles = new System.Windows.Forms.Button();
            this.lblLikes = new System.Windows.Forms.Label();
            this.btnLike = new System.Windows.Forms.Button();
            this.lstComentarios = new System.Windows.Forms.ListBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnComentar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFiltrarLikes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(32, 57);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "label1";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(32, 92);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(35, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "label2";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(215, 263);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(65, 25);
            this.btnAnterior.TabIndex = 3;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(323, 263);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(65, 25);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnDetalles
            // 
            this.btnDetalles.Location = new System.Drawing.Point(534, 11);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(56, 19);
            this.btnDetalles.TabIndex = 5;
            this.btnDetalles.Text = "Detalles";
            this.btnDetalles.UseVisualStyleBackColor = true;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
            // 
            // lblLikes
            // 
            this.lblLikes.AutoSize = true;
            this.lblLikes.Location = new System.Drawing.Point(169, 214);
            this.lblLikes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLikes.Name = "lblLikes";
            this.lblLikes.Size = new System.Drawing.Size(35, 13);
            this.lblLikes.TabIndex = 6;
            this.lblLikes.Text = "label1";
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(62, 211);
            this.btnLike.Margin = new System.Windows.Forms.Padding(2);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(56, 19);
            this.btnLike.TabIndex = 7;
            this.btnLike.Text = "Like";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // lstComentarios
            // 
            this.lstComentarios.FormattingEnabled = true;
            this.lstComentarios.Location = new System.Drawing.Point(471, 232);
            this.lstComentarios.Margin = new System.Windows.Forms.Padding(2);
            this.lstComentarios.Name = "lstComentarios";
            this.lstComentarios.Size = new System.Drawing.Size(91, 69);
            this.lstComentarios.TabIndex = 8;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(471, 190);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(2);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(76, 20);
            this.txtComentario.TabIndex = 9;
            // 
            // btnComentar
            // 
            this.btnComentar.Location = new System.Drawing.Point(471, 167);
            this.btnComentar.Margin = new System.Windows.Forms.Padding(2);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.Size = new System.Drawing.Size(66, 19);
            this.btnComentar.TabIndex = 10;
            this.btnComentar.Text = "Comentar";
            this.btnComentar.UseVisualStyleBackColor = true;
            this.btnComentar.Click += new System.EventHandler(this.btnComentar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(171, 45);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 162);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnFiltrarLikes
            // 
            this.btnFiltrarLikes.Location = new System.Drawing.Point(488, 45);
            this.btnFiltrarLikes.Name = "btnFiltrarLikes";
            this.btnFiltrarLikes.Size = new System.Drawing.Size(102, 25);
            this.btnFiltrarLikes.TabIndex = 11;
            this.btnFiltrarLikes.Text = "Ordenar por Likes";
            this.btnFiltrarLikes.UseVisualStyleBackColor = true;
            this.btnFiltrarLikes.Click += new System.EventHandler(this.btnFiltrarLikes_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 332);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 26);
            this.button1.TabIndex = 12;
            this.button1.Text = "Biografia";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 336);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 22);
            this.button2.TabIndex = 13;
            this.button2.Text = "Contacto";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FrmGaleria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFiltrarLikes);
            this.Controls.Add(this.btnComentar);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.lstComentarios);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.lblLikes);
            this.Controls.Add(this.btnDetalles);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.Label lblLikes;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.ListBox lstComentarios;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnComentar;
        private System.Windows.Forms.Button btnFiltrarLikes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}