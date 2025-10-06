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
        private int perfilId = 0;         // ID del registro en Perfiles
        private int diseñadorId = 0;      // ID del diseñador actual
        public FrmContacto()
        {
            InitializeComponent();
        }


        private void FrmContacto_Load(object sender, EventArgs e)
        {

            // Obtener el DiseñadorId
            diseñadorId = ObtenerDiseñadorId(FrmHome.UsuarioId);

            //if (diseñadorId == 0)
            //{
            //    MessageBox.Show("Solo los diseñadores pueden gestionar la información de contacto.");
            //    this.Close();
            //    return;
            //}

            CargarContacto();
        }

        private void CargarContacto()
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = @"SELECT Id, Instagram, WhatsApp, CorreoContacto
                                   FROM Perfiles
                                   WHERE DiseñadorId = @d";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@d", diseñadorId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        perfilId = Convert.ToInt32(dr["Id"]);
                        txtInstagram.Text = dr["Instagram"]?.ToString();
                        txtWhatsapp.Text = dr["WhatsApp"]?.ToString();
                        txtCorreo.Text = dr["CorreoContacto"]?.ToString();
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
                CrearPerfil("WhatsApp", txtWhatsapp.Text);
            else
                ActualizarCampo("WhatsApp", txtWhatsapp.Text);
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

            ActualizarCampo("WhatsApp", txtWhatsapp.Text);
        }

        private void btnBorrarWhatsapp_Click(object sender, EventArgs e)
        {
            if (perfilId == 0 || string.IsNullOrEmpty(txtWhatsapp.Text))
            {
                MessageBox.Show("No hay número de WhatsApp que borrar.");
                return;
            }

            ActualizarCampo("WhatsApp", null);
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
                CrearPerfil("CorreoContacto", txtCorreo.Text);
            else
                ActualizarCampo("CorreoContacto", txtCorreo.Text);
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

            ActualizarCampo("CorreoContacto", txtCorreo.Text);
        }

        private void btnBorrarCorreo_Click(object sender, EventArgs e)
        {
            if (perfilId == 0 || string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("No hay correo electrónico que borrar.");
                return;
            }

            ActualizarCampo("CorreoContacto", null);
            txtCorreo.Clear();
        }

        private void CrearPerfil(string campo, string valor)
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string insert = $@"INSERT INTO Perfiles (DiseñadorId, {campo})
                                       VALUES (@d, @v);
                                       SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.Parameters.AddWithValue("@d", diseñadorId);
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
                                       SET {campo} = @v, FechaActualizacion = GETDATE()
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
        //private bool EsDiseñador(int usuarioId)
        //{
        //    using (SqlConnection con = new Conexion().Abrir())
        //    {
        //        SqlCommand cmd = new SqlCommand(
        //            "SELECT COUNT(*) FROM Diseñadores WHERE UsuarioId=@u", con);
        //        cmd.Parameters.AddWithValue("@u", usuarioId);

        //        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        //    }
        //}
        private int ObtenerDiseñadorId(int usuarioId)
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = "SELECT Id FROM Diseñadores WHERE UsuarioId=@u";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@u", usuarioId);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }


    }

}

