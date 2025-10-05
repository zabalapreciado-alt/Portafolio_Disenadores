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
        private int perfilId = 0; // Guardará el Id del perfil si existe
        public FrmAcercaDe()
        {
            InitializeComponent();
        }

        private void FrmAcercaDe_Load(object sender, EventArgs e)
        {
            CargarBiografia();
        }

        private void CargarBiografia()
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = "SELECT Id, Biografia FROM Perfiles WHERE UsuarioId=@u";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        perfilId = Convert.ToInt32(dr["Id"]);
                        txtBiografia.Text = dr["Biografia"].ToString();
                        btnCrear.Enabled = false;    // Ya existe, no se crea otra
                        btnEditar.Enabled = true;
                        btnEliminar.Enabled = true;
                    }
                    else
                    {
                        perfilId = 0;
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
                    string sql = @"INSERT INTO Perfiles (UsuarioId, Biografia) 
                                   VALUES (@u, @b)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId);
                    cmd.Parameters.AddWithValue("@b", txtBiografia.Text.Trim());
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
            if (perfilId == 0)
            {
                MessageBox.Show("No hay biografía para editar.");
                return;
            }

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = @"UPDATE Perfiles 
                                   SET Biografia=@b, FechaActualizacion=GETDATE() 
                                   WHERE Id=@id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@b", txtBiografia.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", perfilId);
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
            if (perfilId == 0)
            {
                MessageBox.Show("No hay biografía para eliminar.");
                return;
            }

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
                        string sql = "DELETE FROM Perfiles WHERE Id=@id";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@id", perfilId);
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
    }
}
