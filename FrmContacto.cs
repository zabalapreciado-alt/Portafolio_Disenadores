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
            ActualizarEstadosBotones();
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
                }
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

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInstagram.Text) && string.IsNullOrWhiteSpace(txtWhatsapp.Text))
            {
                MessageBox.Show("Debes ingresar al menos un dato (Instagram o WhatsApp) para poder guardar.");
                return;
            }

            bool guardado = false;

            if (!string.IsNullOrWhiteSpace(txtInstagram.Text))
            {
                ActualizarCampo("Instagram", txtInstagram.Text.Trim());
                guardado = true;
            }

            if (!string.IsNullOrWhiteSpace(txtWhatsapp.Text))
            {
                ActualizarCampo("WhatsApp", txtWhatsapp.Text.Trim());
                guardado = true;
            }

            if (guardado)
            {
                MessageBox.Show("Datos guardados correctamente.");
                CargarContacto();
                ActualizarEstadosBotones();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string instagramActual = txtInstagram.Text.Trim();
            string whatsappActual = txtWhatsapp.Text.Trim();

            using (SqlConnection con = new Conexion().Abrir())
            {
                string sqlCheck = @"SELECT Instagram, WhatsApp FROM Usuarios WHERE Id = @u";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, con);
                cmdCheck.Parameters.AddWithValue("@u", usuarioId);
                SqlDataReader dr = cmdCheck.ExecuteReader();

                if (dr.Read())
                {
                    bool hayInstagramGuardado = !string.IsNullOrEmpty(dr["Instagram"].ToString());
                    bool hayWhatsappGuardado = !string.IsNullOrEmpty(dr["WhatsApp"].ToString());

                    if (!hayInstagramGuardado && !hayWhatsappGuardado)
                    {
                        MessageBox.Show("No hay información guardada para editar. Primero debes crearla.");
                        return;
                    }

                    bool editado = false;

                    if (hayInstagramGuardado && !string.IsNullOrWhiteSpace(instagramActual))
                    {
                        ActualizarCampo("Instagram", instagramActual);
                        editado = true;
                    }
                    else if (!hayInstagramGuardado && !string.IsNullOrWhiteSpace(instagramActual))
                    {
                        MessageBox.Show("No puedes editar Instagram porque aún no tienes uno guardado.");
                    }

                    if (hayWhatsappGuardado && !string.IsNullOrWhiteSpace(whatsappActual))
                    {
                        ActualizarCampo("WhatsApp", whatsappActual);
                        editado = true;
                    }
                    else if (!hayWhatsappGuardado && !string.IsNullOrWhiteSpace(whatsappActual))
                    {
                        MessageBox.Show("No puedes editar WhatsApp porque aún no tienes uno guardado.");
                    }

                    if (editado)
                    {
                        MessageBox.Show("Datos editados correctamente.");
                        CargarContacto();
                        ActualizarEstadosBotones();
                    }
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInstagram.Text) && string.IsNullOrEmpty(txtWhatsapp.Text))
            {
                MessageBox.Show("No hay información para borrar.");
                return;
            }

            DialogResult dr = MessageBox.Show("¿Seguro que deseas borrar tu información de contacto?",
                                              "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(txtInstagram.Text))
                    ActualizarCampo("Instagram", null);

                if (!string.IsNullOrEmpty(txtWhatsapp.Text))
                    ActualizarCampo("WhatsApp", null);

                txtInstagram.Clear();
                txtWhatsapp.Clear();

                MessageBox.Show("Información borrada correctamente.");
                ActualizarEstadosBotones();
            }


        }

        private void ActualizarEstadosBotones()
        {
            bool hayDatos = !string.IsNullOrWhiteSpace(txtInstagram.Text) || !string.IsNullOrWhiteSpace(txtWhatsapp.Text);

            btnCrear.Enabled = hayDatos;
            btnEditar.Enabled = hayDatos;
            btnBorrar.Enabled = hayDatos;
        }

        private void txtInstagram_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstadosBotones();
        }

        private void txtWhatsapp_TextChanged(object sender, EventArgs e)
        {
            ActualizarEstadosBotones();
        }
    }
}

