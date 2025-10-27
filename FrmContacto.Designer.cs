namespace PortafolioDiseñadores
{
    partial class FrmContacto
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
            this.txtInstagram = new System.Windows.Forms.TextBox();
            this.txtWhatsapp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInstagram
            // 
            this.txtInstagram.Font = new System.Drawing.Font("Impact", 13F);
            this.txtInstagram.Location = new System.Drawing.Point(122, 33);
            this.txtInstagram.Name = "txtInstagram";
            this.txtInstagram.Size = new System.Drawing.Size(261, 29);
            this.txtInstagram.TabIndex = 0;
            this.txtInstagram.TextChanged += new System.EventHandler(this.txtInstagram_TextChanged);
            // 
            // txtWhatsapp
            // 
            this.txtWhatsapp.Font = new System.Drawing.Font("Impact", 13F);
            this.txtWhatsapp.Location = new System.Drawing.Point(122, 81);
            this.txtWhatsapp.Name = "txtWhatsapp";
            this.txtWhatsapp.Size = new System.Drawing.Size(261, 29);
            this.txtWhatsapp.TabIndex = 1;
            this.txtWhatsapp.TextChanged += new System.EventHandler(this.txtWhatsapp_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 13F);
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Instagram";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 13F);
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Whatsapp";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Impact", 11F);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(299, 160);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(84, 24);
            this.btnVolver.TabIndex = 15;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Impact", 11F);
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(119, 125);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(84, 24);
            this.btnCrear.TabIndex = 16;
            this.btnCrear.Text = "Guardar";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Impact", 11F);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(209, 125);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(84, 24);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(62)))), ((int)(((byte)(140)))));
            this.btnBorrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrar.FlatAppearance.BorderSize = 0;
            this.btnBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(116)))), ((int)(((byte)(166)))));
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Font = new System.Drawing.Font("Impact", 11F);
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.Location = new System.Drawing.Point(299, 125);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(84, 24);
            this.btnBorrar.TabIndex = 18;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // FrmContacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(406, 196);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWhatsapp);
            this.Controls.Add(this.txtInstagram);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmContacto";
            this.Text = "Contacto";
            this.Load += new System.EventHandler(this.FrmContacto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInstagram;
        private System.Windows.Forms.TextBox txtWhatsapp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnBorrar;
    }
}