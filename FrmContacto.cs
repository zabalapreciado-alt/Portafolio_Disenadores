using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PortafolioDiseñadores
{
    public partial class FrmContacto : Form
    {
        private int usuarioId = 0;
        public FrmContacto()
        {
            InitializeComponent();
        }


        private void FrmContacto_Load(object sender, EventArgs e)
        {
            usuarioId = FrmHome.UsuarioId;
            CargarContacto();
        }

        private void CargarContacto()
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = @"SELECT Instagram, WhatsApp 
                                   FROM Usuarios 
                                   WHERE Id = @u";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@u", usuarioId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtInstagram.Text = dr["Instagram"]?.ToString();
                        txtWhatsapp.Text = dr["WhatsApp"]?.ToString();
                    }
                    else
                    {
                        txtInstagram.Clear();
                        txtWhatsapp.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de contacto: " + ex.Message);
            }
        }

        private void btnCrearInstagram_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInstagram.Text))
            {
                MessageBox.Show("Ingrese su usuario de Instagram.");
                return;
            }

            ActualizarCampo("Instagram", txtInstagram.Text.Trim());
        }

        private void btnEditarInstagram_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInstagram.Text))
            {
                MessageBox.Show("Ingrese el nuevo usuario de Instagram.");
                return;
            }

            ActualizarCampo("Instagram", txtInstagram.Text.Trim());
        }

        private void btnBorrarInstagram_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInstagram.Text))
            {
                MessageBox.Show("No hay usuario de Instagram que borrar.");
                return;
            }

            ActualizarCampo("Instagram", null);
            txtInstagram.Clear();
        }

        private void btnCrearWhatsapp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWhatsapp.Text))
            {
                MessageBox.Show("Ingrese el número de WhatsApp.");
                return;
            }

            ActualizarCampo("WhatsApp", txtWhatsapp.Text.Trim());
        }

        private void btnEditarWhatsapp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWhatsapp.Text))
            {
                MessageBox.Show("Ingrese el nuevo número de WhatsApp.");
                return;
            }

            ActualizarCampo("WhatsApp", txtWhatsapp.Text.Trim());
        }

        private void btnBorrarWhatsapp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWhatsapp.Text))
            {
                MessageBox.Show("No hay número de WhatsApp que borrar.");
                return;
            }

            ActualizarCampo("WhatsApp", null);
            txtWhatsapp.Clear();
        }



        private void ActualizarCampo(string campo, string valor)
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = $@"UPDATE Usuarios 
                                   SET {campo} = @v, FechaActualizacion = GETDATE()
                                   WHERE Id = @u";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@u", usuarioId);

                    if (valor == null)
                        cmd.Parameters.AddWithValue("@v", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@v", valor);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"{campo} actualizado correctamente.");
                }

                CargarContacto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el contacto: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

