using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace PortafolioDiseñadores
{
    public partial class FrmOfertasTrabajo : Form
    {
        public FrmOfertasTrabajo()
        {
            InitializeComponent();
        }
        private void FrmOfertasTrabajo_Load(object sender, EventArgs e)
        {
            CargarOfertas();
        }


        private void CargarOfertas()
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql;
                    SqlDataAdapter da;

                    if (FrmHome.Rol == "admin")
                    {
                        
                        sql = @"SELECT O.Id, 
                               R.Empresa AS Reclutador, 
                               O.Titulo, 
                               O.Descripcion, 
                               O.Contacto, 
                               O.Estado, 
                               O.Fecha
                        FROM OfertasTrabajo O
                        JOIN Reclutadores R ON O.ReclutadorId = R.Id
                        ORDER BY O.Fecha DESC";
                        da = new SqlDataAdapter(sql, con);
                    }
                    else if (FrmHome.Rol == "diseñador")
                    {
                        
                        string q = "SELECT Id FROM Diseñadores WHERE UsuarioId = @u";
                        using (SqlCommand cmd = new SqlCommand(q, con))
                        {
                            cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId);
                            object res = cmd.ExecuteScalar();
                            if (res == null)
                            {
                                MessageBox.Show("No se encontró diseñador asociado.");
                                return;
                            }
                            int diseñadorId = Convert.ToInt32(res);

                            sql = @"SELECT O.Id, 
                                   R.Empresa AS Reclutador, 
                                   O.Titulo, 
                                   O.Descripcion, 
                                   O.Contacto, 
                                   O.Estado, 
                                   O.Fecha
                            FROM OfertasTrabajo O
                            JOIN Reclutadores R ON O.ReclutadorId = R.Id
                            WHERE O.DiseñadorId = @d
                            ORDER BY O.Fecha DESC
                            ";
                            da = new SqlDataAdapter(sql, con);
                            da.SelectCommand.Parameters.AddWithValue("@d", diseñadorId);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tienes permisos para ver ofertas.");
                        return;
                    }

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOfertas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando ofertas: " + ex.Message);
            }
        }

        private void CambiarEstadoSeleccion(string nuevoEstado)
        {
            if (dgvOfertas.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvOfertas.CurrentRow.Cells["Id"].Value);

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = "UPDATE OfertasTrabajo SET Estado=@e WHERE Id=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@e", nuevoEstado);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Oferta actualizada.");
                CargarOfertas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cambiando estado: " + ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e) => CambiarEstadoSeleccion("Aceptada");


        private void btnRechazar_Click(object sender, EventArgs e) => CambiarEstadoSeleccion("Rechazada");

        private void dgvOfertas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOfertas.Columns[e.ColumnIndex].Name == "Estado")
            {
                string estado = e.Value?.ToString();
                if (estado == "Pendiente")
                    e.CellStyle.BackColor = Color.LightYellow;
                else if (estado == "Aceptada")
                    e.CellStyle.BackColor = Color.LightGreen;
                else if (estado == "Rechazada")
                    e.CellStyle.BackColor = Color.LightCoral;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

