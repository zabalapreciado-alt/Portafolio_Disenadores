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
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(54, 37);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(125, 16);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido invitado";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(49, 81);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(130, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(29, 428);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(150, 23);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Visible = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnGaleria
            // 
            this.btnGaleria.Location = new System.Drawing.Point(57, 159);
            this.btnGaleria.Name = "btnGaleria";
            this.btnGaleria.Size = new System.Drawing.Size(75, 23);
            this.btnGaleria.TabIndex = 3;
            this.btnGaleria.Text = "Galería";
            this.btnGaleria.UseVisualStyleBackColor = true;
            this.btnGaleria.Click += new System.EventHandler(this.btnGaleria_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Location = new System.Drawing.Point(749, 37);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(106, 23);
            this.btnEstadisticas.TabIndex = 4;
            this.btnEstadisticas.Text = "Estadísticas";
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            this.btnEstadisticas.Visible = false;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // btnAdminProyectos
            // 
            this.btnAdminProyectos.Location = new System.Drawing.Point(734, 97);
            this.btnAdminProyectos.Name = "btnAdminProyectos";
            this.btnAdminProyectos.Size = new System.Drawing.Size(148, 23);
            this.btnAdminProyectos.TabIndex = 5;
            this.btnAdminProyectos.Text = "Gestionar Proyectos";
            this.btnAdminProyectos.UseVisualStyleBackColor = true;
            this.btnAdminProyectos.Visible = false;
            this.btnAdminProyectos.Click += new System.EventHandler(this.btnAdminProyectos_Click);
            // 
            // btnOfertas
            // 
            this.btnOfertas.Location = new System.Drawing.Point(734, 212);
            this.btnOfertas.Name = "btnOfertas";
            this.btnOfertas.Size = new System.Drawing.Size(118, 23);
            this.btnOfertas.TabIndex = 6;
            this.btnOfertas.Text = "Ver Ofertas";
            this.btnOfertas.UseVisualStyleBackColor = true;
            this.btnOfertas.Visible = false;
            this.btnOfertas.Click += new System.EventHandler(this.btnOfertas_Click);
            // 
            // btnNuevaOferta
            // 
            this.btnNuevaOferta.Location = new System.Drawing.Point(734, 159);
            this.btnNuevaOferta.Name = "btnNuevaOferta";
            this.btnNuevaOferta.Size = new System.Drawing.Size(123, 23);
            this.btnNuevaOferta.TabIndex = 7;
            this.btnNuevaOferta.Text = "Enviar Oferta";
            this.btnNuevaOferta.UseVisualStyleBackColor = true;
            this.btnNuevaOferta.Visible = false;
            this.btnNuevaOferta.Click += new System.EventHandler(this.btnNuevaOferta_Click);
            // 
            // btnAcercaDe
            // 
            this.btnAcercaDe.Location = new System.Drawing.Point(57, 224);
            this.btnAcercaDe.Name = "btnAcercaDe";
            this.btnAcercaDe.Size = new System.Drawing.Size(116, 23);
            this.btnAcercaDe.TabIndex = 8;
            this.btnAcercaDe.Text = "Acerca de Mí";
            this.btnAcercaDe.UseVisualStyleBackColor = true;
            this.btnAcercaDe.Click += new System.EventHandler(this.btnAcercaDe_Click);
            // 
            // btnContacto
            // 
            this.btnContacto.Location = new System.Drawing.Point(57, 282);
            this.btnContacto.Name = "btnContacto";
            this.btnContacto.Size = new System.Drawing.Size(95, 23);
            this.btnContacto.TabIndex = 9;
            this.btnContacto.Text = "Contacto";
            this.btnContacto.UseVisualStyleBackColor = true;
            this.btnContacto.Click += new System.EventHandler(this.btnContacto_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 505);
            this.Controls.Add(this.btnContacto);
            this.Controls.Add(this.btnAcercaDe);
            this.Controls.Add(this.btnNuevaOferta);
            this.Controls.Add(this.btnOfertas);
            this.Controls.Add(this.btnAdminProyectos);
            this.Controls.Add(this.btnEstadisticas);
            this.Controls.Add(this.btnGaleria);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblBienvenida);
            this.Name = "FrmHome";
            this.Text = "FrmHome";
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
    }
}

