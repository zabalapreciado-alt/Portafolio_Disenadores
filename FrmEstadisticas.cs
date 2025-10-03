using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PortafolioDiseñadores
{
    public partial class FrmEstadisticas : Form
    {
        public FrmEstadisticas()
        {
            InitializeComponent();
        }
        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
            CargarEstadisticas();
        }

        private void CargarEstadisticas()
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = @"
                        SELECT p.Id, p.Titulo, p.RutaImagen,
                               COUNT(DISTINCT l.Id) AS TotalLikes,
                               COUNT(DISTINCT c.Id) AS TotalComentarios
                        FROM Proyectos p
                        LEFT JOIN Likes l ON p.Id = l.ProyectoId
                        LEFT JOIN Comentarios c ON p.Id = c.ProyectoId
                        GROUP BY p.Id, p.Titulo, p.RutaImagen
                        ORDER BY TotalLikes DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvEstadisticas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando estadísticas: " + ex.Message);
            }
        }

        private void dgvEstadisticas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEstadisticas.CurrentRow == null) return;

            int proyectoId = Convert.ToInt32(dgvEstadisticas.CurrentRow.Cells["Id"].Value);
            string titulo = dgvEstadisticas.CurrentRow.Cells["Titulo"].Value.ToString();
            string rutaImg = dgvEstadisticas.CurrentRow.Cells["RutaImagen"].Value.ToString();

            lblProyecto.Text = "Proyecto: " + titulo;
            MostrarComentarios(proyectoId);
            MostrarImagen(rutaImg);
        }

        private void MostrarComentarios(int proyectoId)
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = @"
                    SELECT u.NombreUsuario, c.Texto, c.Fecha
                    FROM Comentarios c
                    JOIN Usuarios u ON c.UsuarioId = u.Id
                    WHERE c.ProyectoId = @p
                    ORDER BY c.Fecha DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@p", proyectoId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvComentarios.DataSource = dt;
            }
        }

        private void MostrarImagen(string rutaImg)
        {
            if (string.IsNullOrEmpty(rutaImg))
            {
                pbProyecto.Image = null;
                return;
            }

            string fullPath = Path.Combine(Application.StartupPath, "Imagenes", rutaImg);
            if (File.Exists(fullPath))
            {
                if (pbProyecto.Image != null)
                {
                    pbProyecto.Image.Dispose();
                    pbProyecto.Image = null;
                }
                pbProyecto.Image = Image.FromFile(fullPath);
                pbProyecto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pbProyecto.Image = null;
            }
        }
    }
}
