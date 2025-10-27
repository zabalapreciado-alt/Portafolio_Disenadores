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
    public partial class FrmAcercaDe : Form
    {
        private int usuarioId = 0; 
        public FrmAcercaDe()
        {
            InitializeComponent();
        }
        

        private void FrmAcercaDe_Load(object sender, EventArgs e)
        {
            usuarioId = FrmHome.UsuarioId; 
            CargarBiografia();
        }

        
        private void CargarBiografia()
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = "SELECT Biografia FROM Usuarios WHERE Id=@u";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@u", usuarioId);

                    object bio = cmd.ExecuteScalar();

                    if (bio != null && !Convert.IsDBNull(bio) && !string.IsNullOrWhiteSpace(bio.ToString()))
                    {
                        txtBiografia.Text = bio.ToString();
                        btnCrear.Enabled = false;
                        btnEditar.Enabled = true;
                        btnEliminar.Enabled = true;
                    }
                    else
                    {
                        txtBiografia.Clear();
                        btnCrear.Enabled = true;
                        btnEditar.Enabled = false;
                        btnEliminar.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando biografía: " + ex.Message);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBiografia.Text))
            {
                MessageBox.Show("Escribe una biografía antes de crear.");
                return;
            }

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = "UPDATE Usuarios SET Biografia=@b, FechaActualizacion=GETDATE() WHERE Id=@u";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@b", txtBiografia.Text.Trim());
                    cmd.Parameters.AddWithValue("@u", usuarioId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Biografía creada con éxito.");
                CargarBiografia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la biografía: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBiografia.Text))
            {
                MessageBox.Show("Escribe una biografía antes de guardar los cambios.");
                return;
            }

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = "UPDATE Usuarios SET Biografia=@b, FechaActualizacion=GETDATE() WHERE Id=@u";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@b", txtBiografia.Text.Trim());
                    cmd.Parameters.AddWithValue("@u", usuarioId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Biografía actualizada con éxito.");
                CargarBiografia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la biografía: " + ex.Message);
            }
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "¿Estás seguro de eliminar tu biografía?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new Conexion().Abrir())
                    {
                        string sql = "UPDATE Usuarios SET Biografia=NULL, FechaActualizacion=GETDATE() WHERE Id=@u";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@u", usuarioId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Biografía eliminada.");
                    CargarBiografia();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la biografía: " + ex.Message);
                }
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
