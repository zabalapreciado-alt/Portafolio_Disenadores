namespace PortafolioDiseñadores
{
    partial class FrmHome
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnGaleria = new System.Windows.Forms.Button();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnAdminProyectos = new System.Windows.Forms.Button();
            this.btnOfertas = new System.Windows.Forms.Button();
            this.btnNuevaOferta = new System.Windows.Forms.Button();
            this.btnAcercaDe = new System.Windows.Forms.Button();
            this.btnContacto = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenida.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Location = new System.Drawing.Point(38, 27);
            this.lblBienvenida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(282, 33);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido invitado";
            this.lblBienvenida.Click += new System.EventHandler(this.lblBienvenida_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(44, 77);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(146, 28);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(834, 490);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(114, 24);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Visible = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnGaleria
            // 
            this.btnGaleria.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGaleria.ForeColor = System.Drawing.Color.Black;
            this.btnGaleria.Location = new System.Drawing.Point(164, 18);
            this.btnGaleria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGaleria.Name = "btnGaleria";
            this.btnGaleria.Size = new System.Drawing.Size(129, 28);
            this.btnGaleria.TabIndex = 3;
            this.btnGaleria.Text = "Galería";
            this.btnGaleria.UseVisualStyleBackColor = true;
            this.btnGaleria.Click += new System.EventHandler(this.btnGaleria_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadisticas.Location = new System.Drawing.Point(12, 520);
            this.btnEstadisticas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(86, 24);
            this.btnEstadisticas.TabIndex = 4;
            this.btnEstadisticas.Text = "Estadísticas";
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            this.btnEstadisticas.Visible = false;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // btnAdminProyectos
            // 
            this.btnAdminProyectos.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminProyectos.Location = new System.Drawing.Point(147, 520);
            this.btnAdminProyectos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdminProyectos.Name = "btnAdminProyectos";
            this.btnAdminProyectos.Size = new System.Drawing.Size(157, 24);
            this.btnAdminProyectos.TabIndex = 5;
            this.btnAdminProyectos.Text = "Gestionar Proyectos";
            this.btnAdminProyectos.UseVisualStyleBackColor = true;
            this.btnAdminProyectos.Visible = false;
            this.btnAdminProyectos.Click += new System.EventHandler(this.btnAdminProyectos_Click);
            // 
            // btnOfertas
            // 
            this.btnOfertas.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOfertas.Location = new System.Drawing.Point(376, 520);
            this.btnOfertas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOfertas.Name = "btnOfertas";
            this.btnOfertas.Size = new System.Drawing.Size(96, 24);
            this.btnOfertas.TabIndex = 6;
            this.btnOfertas.Text = "Ver Ofertas";
            this.btnOfertas.UseVisualStyleBackColor = true;
            this.btnOfertas.Visible = false;
            this.btnOfertas.Click += new System.EventHandler(this.btnOfertas_Click);
            // 
            // btnNuevaOferta
            // 
            this.btnNuevaOferta.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaOferta.ForeColor = System.Drawing.Color.Black;
            this.btnNuevaOferta.Location = new System.Drawing.Point(407, 316);
            this.btnNuevaOferta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevaOferta.Name = "btnNuevaOferta";
            this.btnNuevaOferta.Size = new System.Drawing.Size(129, 28);
            this.btnNuevaOferta.TabIndex = 7;
            this.btnNuevaOferta.Text = "Enviar Oferta";
            this.btnNuevaOferta.UseVisualStyleBackColor = true;
            this.btnNuevaOferta.Visible = false;
            this.btnNuevaOferta.Click += new System.EventHandler(this.btnNuevaOferta_Click);
            // 
            // btnAcercaDe
            // 
            this.btnAcercaDe.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcercaDe.ForeColor = System.Drawing.Color.Black;
            this.btnAcercaDe.Location = new System.Drawing.Point(20, 18);
            this.btnAcercaDe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAcercaDe.Name = "btnAcercaDe";
            this.btnAcercaDe.Size = new System.Drawing.Size(129, 28);
            this.btnAcercaDe.TabIndex = 8;
            this.btnAcercaDe.Text = "Acerca de Mí";
            this.btnAcercaDe.UseVisualStyleBackColor = true;
            this.btnAcercaDe.Click += new System.EventHandler(this.btnAcercaDe_Click);
            // 
            // btnContacto
            // 
            this.btnContacto.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContacto.ForeColor = System.Drawing.Color.Black;
            this.btnContacto.Location = new System.Drawing.Point(316, 18);
            this.btnContacto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnContacto.Name = "btnContacto";
            this.btnContacto.Size = new System.Drawing.Size(129, 28);
            this.btnContacto.TabIndex = 9;
            this.btnContacto.Text = "Contacto";
            this.btnContacto.UseVisualStyleBackColor = true;
            this.btnContacto.Click += new System.EventHandler(this.btnContacto_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.btnAcercaDe);
            this.panel1.Controls.Add(this.btnGaleria);
            this.panel1.Controls.Add(this.btnContacto);
            this.panel1.ForeColor = System.Drawing.Color.RosyBrown;
            this.panel1.Location = new System.Drawing.Point(141, 177);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 67);
            this.panel1.TabIndex = 10;
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1055, 561);
            this.Controls.Add(this.btnNuevaOferta);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOfertas);
            this.Controls.Add(this.btnAdminProyectos);
            this.Controls.Add(this.btnEstadisticas);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblBienvenida);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnGaleria;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnAdminProyectos;
        private System.Windows.Forms.Button btnOfertas;
        private System.Windows.Forms.Button btnNuevaOferta;
        private System.Windows.Forms.Button btnAcercaDe;
        private System.Windows.Forms.Button btnContacto;
        private System.Windows.Forms.Panel panel1;
    }
}

