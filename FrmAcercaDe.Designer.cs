namespace PortafolioDiseñadores
{
    partial class FrmAcercaDe
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMail = new System.Windows.Forms.Button();
            this.btnWhatsapp = new System.Windows.Forms.Button();
            this.btnInstagram = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMail);
            this.panel1.Controls.Add(this.btnWhatsapp);
            this.panel1.Controls.Add(this.btnInstagram);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(59, 170);
            this.panel1.TabIndex = 0;
            // 
            // btnMail
            // 
            this.btnMail.BackColor = System.Drawing.Color.Transparent;
            this.btnMail.BackgroundImage = global::PortafolioDiseñadores.Properties.Resources._732026;
            this.btnMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMail.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMail.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMail.Location = new System.Drawing.Point(0, 90);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(59, 45);
            this.btnMail.TabIndex = 2;
            this.btnMail.UseVisualStyleBackColor = false;
            // 
            // btnWhatsapp
            // 
            this.btnWhatsapp.BackColor = System.Drawing.Color.Transparent;
            this.btnWhatsapp.BackgroundImage = global::PortafolioDiseñadores.Properties.Resources.png_clipart_whatsapp_computer_icons_whatsapp_text_whatsapp_icon_thumbnail;
            this.btnWhatsapp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWhatsapp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWhatsapp.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhatsapp.Location = new System.Drawing.Point(0, 45);
            this.btnWhatsapp.Name = "btnWhatsapp";
            this.btnWhatsapp.Size = new System.Drawing.Size(59, 45);
            this.btnWhatsapp.TabIndex = 1;
            this.btnWhatsapp.UseVisualStyleBackColor = false;
            // 
            // btnInstagram
            // 
            this.btnInstagram.BackColor = System.Drawing.Color.Transparent;
            this.btnInstagram.BackgroundImage = global::PortafolioDiseñadores.Properties.Resources.instagram_black_logo_on_transparent_background_free_vector;
            this.btnInstagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInstagram.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInstagram.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstagram.Location = new System.Drawing.Point(0, 0);
            this.btnInstagram.Name = "btnInstagram";
            this.btnInstagram.Size = new System.Drawing.Size(59, 45);
            this.btnInstagram.TabIndex = 0;
            this.btnInstagram.UseVisualStyleBackColor = false;
            // 
            // FrmAcercaDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(480, 171);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmAcercaDe";
            this.Text = "FrmAcercaDe";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInstagram;
        private System.Windows.Forms.Button btnWhatsapp;
        private System.Windows.Forms.Button btnMail;
    }
}