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
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = @"
            SELECT p.Id, p.Titulo,
                   COUNT(DISTINCT l.Id) AS TotalLikes,
                   COUNT(DISTINCT c.Id) AS TotalComentarios
            FROM Proyectos p
            LEFT JOIN Likes l ON l.ProyectoId = p.Id
            LEFT JOIN Comentarios c ON c.ProyectoId = p.Id
            GROUP BY p.Id, p.Titulo
            ORDER BY TotalLikes DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                    MessageBox.Show("⚠ No se encontraron estadísticas. Revisa si ProyectoId en Likes/Comentarios coincide con Id en Proyectos.");

                dgvEstadisticas.DataSource = dt;
            }
        }

        private void CargarEstadisticas()
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = @"
                    SELECT p.Id, p.Titulo, p.RutaImagen,
                           COUNT(DISTINCT l.Id) AS TotalLikes,
                           COUNT(DISTINCT c.Id) AS TotalComentarios
                    FROM Proyectos p
                    LEFT JOIN Likes l ON l.ProyectoId = p.Id
                    LEFT JOIN Comentarios c ON c.ProyectoId = p.Id
                    GROUP BY p.Id, p.Titulo, p.RutaImagen
                    ORDER BY TotalLikes DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvEstadisticas.DataSource = dt;

                // Ocultar ruta si no quieres que se muestre
                if (dgvEstadisticas.Columns["RutaImagen"] != null)
                    dgvEstadisticas.Columns["RutaImagen"].Visible = false;
            }
        }

        private void dgvEstadisticas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int proyectoId = Convert.ToInt32(dgvEstadisticas.Rows[e.RowIndex].Cells["Id"].Value);
            string titulo = dgvEstadisticas.Rows[e.RowIndex].Cells["Titulo"].Value.ToString();
            string rutaImg = dgvEstadisticas.Rows[e.RowIndex].Cells["RutaImagen"].Value.ToString();

            lblProyecto.Text = $"Proyecto: {titulo}";
            MostrarImagen(rutaImg);
            CargarComentarios(proyectoId);
        }

        private void MostrarImagen(string nombreArchivo)
        {
            if (string.IsNullOrEmpty(nombreArchivo))
            {
                pbProyecto.Image = null;
                return;
            }

            string fullPath = Path.Combine(Application.StartupPath, "Imagenes", nombreArchivo);
            if (File.Exists(fullPath))
            {
                pbProyecto.Image = Image.FromFile(fullPath);
                pbProyecto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pbProyecto.Image = null;
            }
        }

        private void CargarComentarios(int proyectoId)
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = "SELECT Texto FROM Comentarios WHERE ProyectoId=@id";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@id", proyectoId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                lstComentarios.DataSource = dt;
                lstComentarios.DisplayMember = "Texto";
            }
        }
    }
}
