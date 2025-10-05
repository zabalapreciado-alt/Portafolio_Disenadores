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
        private int perfilId = 0; // ID del registro en Perfiles
        public FrmContacto()
        {
            InitializeComponent();
        }

        private void FrmContacto_Load(object sender, EventArgs e)
        {
            CargarContacto();
            this.Load += FrmContacto_Load; // asegura que el evento Load esté suscrito
        }

        private void CargarContacto()
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = "SELECT Id, Instagram, Whatsapp, Correo FROM Perfiles WHERE UsuarioId=@u";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        perfilId = Convert.ToInt32(dr["Id"]);
                        txtInstagram.Text = dr["Instagram"]?.ToString();
                        txtWhatsapp.Text = dr["Whatsapp"]?.ToString();
                        txtCorreo.Text = dr["Correo"]?.ToString();
                    }
                    else
                    {
                        perfilId = 0;
                        txtInstagram.Clear();
                        txtWhatsapp.Clear();
                        txtCorreo.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el contacto: " + ex.Message);
            }
        }

        private void btnCrearInstagram_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInstagram.Text))
            {
                MessageBox.Show("Ingrese el usuario de Instagram.");
                return;
            }

            if (perfilId == 0)
                CrearPerfil("Instagram", txtInstagram.Text);
            else
                ActualizarCampo("Instagram", txtInstagram.Text);
        }

        private void btnEditarInstagram_Click(object sender, EventArgs e)
        {
            if (perfilId == 0)
            {
                MessageBox.Show("No hay registro existente para editar. Use el botón Crear.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInstagram.Text))
            {
                MessageBox.Show("Ingrese el nuevo usuario de Instagram.");
                return;
            }

            ActualizarCampo("Instagram", txtInstagram.Text);
        }

        private void btnBorrarInstagram_Click(object sender, EventArgs e)
        {
            if (perfilId == 0 || string.IsNullOrEmpty(txtInstagram.Text))
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

            if (perfilId == 0)
                CrearPerfil("Whatsapp", txtWhatsapp.Text);
            else
                ActualizarCampo("Whatsapp", txtWhatsapp.Text);
        }

        private void btnEditarWhatsapp_Click(object sender, EventArgs e)
        {
            if (perfilId == 0)
            {
                MessageBox.Show("No hay registro existente para editar. Use el botón Crear.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtWhatsapp.Text))
            {
                MessageBox.Show("Ingrese el nuevo número de WhatsApp.");
                return;
            }

            ActualizarCampo("Whatsapp", txtWhatsapp.Text);
        }

        private void btnBorrarWhatsapp_Click(object sender, EventArgs e)
        {
            if (perfilId == 0 || string.IsNullOrEmpty(txtWhatsapp.Text))
            {
                MessageBox.Show("No hay número de WhatsApp que borrar.");
                return;
            }

            ActualizarCampo("Whatsapp", null);
            txtWhatsapp.Clear();
        }

        private void btnCrearCorreo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese el correo electrónico.");
                return;
            }

            if (perfilId == 0)
                CrearPerfil("Correo", txtCorreo.Text);
            else
                ActualizarCampo("Correo", txtCorreo.Text);
        }

        private void btnEditarCorreo_Click(object sender, EventArgs e)
        {
            if (perfilId == 0)
            {
                MessageBox.Show("No hay registro existente para editar. Use el botón Crear.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese el nuevo correo electrónico.");
                return;
            }

            ActualizarCampo("Correo", txtCorreo.Text);
        }

        private void btnBorrarCorreo_Click(object sender, EventArgs e)
        {
            if (perfilId == 0 || string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("No hay correo electrónico que borrar.");
                return;
            }

            ActualizarCampo("Correo", null);
            txtCorreo.Clear();
        }

        private void CrearPerfil(string campo, string valor)
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string insert = $@"INSERT INTO Perfiles (UsuarioId, {campo})
                                       VALUES (@u, @v);
                                       SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId);
                    cmd.Parameters.AddWithValue("@v", valor);

                    perfilId = Convert.ToInt32(cmd.ExecuteScalar());
                    MessageBox.Show($"{campo} creado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el contacto: " + ex.Message);
            }
        }

        private void ActualizarCampo(string campo, string valor)
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string update = $@"UPDATE Perfiles
                                       SET {campo} = @v
                                       WHERE Id = @id";

                    SqlCommand cmd = new SqlCommand(update, con);
                    cmd.Parameters.AddWithValue("@id", perfilId);

                    if (valor == null)
                        cmd.Parameters.AddWithValue("@v", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@v", valor);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"{campo} actualizado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el contacto: " + ex.Message);
            }
        }
    }
    
}

