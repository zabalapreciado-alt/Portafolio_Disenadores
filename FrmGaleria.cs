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
using System.IO;



namespace PortafolioDiseñadores
{
    public partial class FrmGaleria : Form
    {
        private DataTable proyectos = new DataTable();
        private int index = 0;
        public FrmGaleria()
        {
            InitializeComponent();
        }
        private void FrmGaleria_Load(object sender, EventArgs e)
        {
            CargarProyectos();
            if (proyectos.Rows.Count > 0)
            {
                index = 0;
                MostrarProyecto(index);
            }
            else
            {
                lblTitulo.Text = "No hay proyectos disponibles";
                lblDescripcion.Text = "";
                lblLikes.Text = "Likes: 0";
                lstComentarios.DataSource = null;
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        private void CargarProyectos(bool ordenarPorLikes = false)
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql;

                    if (ordenarPorLikes)
                    {
                        sql = @"
                    SELECT p.Id, p.Titulo, p.Descripcion, p.RutaImagen,
                           p.DiseñadorId,
                           d.Nombre AS Diseñador,
                           ISNULL(l.TotalLikes, 0) AS LikesTotales
                    FROM Proyectos p
                    LEFT JOIN Diseñadores d ON p.DiseñadorId = d.Id
                    LEFT JOIN (
                        SELECT ProyectoId, COUNT(*) AS TotalLikes
                        FROM Likes
                        GROUP BY ProyectoId
                    ) l ON p.Id = l.ProyectoId
                    ORDER BY LikesTotales DESC, p.Id DESC";
                    }
                    else
                    {
                        // Orden normal (por fecha/ID descendente)
                        sql = @"
                        SELECT p.Id, p.Titulo, p.Descripcion, p.RutaImagen,
                               p.DiseñadorId,
                               d.Nombre AS Diseñador
                        FROM Proyectos p
                        LEFT JOIN Diseñadores d ON p.DiseñadorId = d.Id
                        ORDER BY p.Id DESC";
                    }

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    proyectos.Clear();
                    da.Fill(proyectos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando proyectos: " + ex.Message);
            }
        }


        private string ObtenerRutaCompletaImagen(string nombreArchivo)
        {
            if (string.IsNullOrEmpty(nombreArchivo)) return null;
            string carpeta = Path.Combine(Application.StartupPath, "Imagenes");
            return Path.Combine(carpeta, nombreArchivo);
        }

        private void MostrarProyecto(int i)
        {
            if (proyectos == null || proyectos.Rows.Count == 0) return;
            if (i < 0) i = 0;
            if (i > proyectos.Rows.Count - 1) i = proyectos.Rows.Count - 1;
            index = i;

            DataRow row = proyectos.Rows[index];
            lblTitulo.Text = row["Titulo"]?.ToString() ?? "";
            string desc = row["Descripcion"]?.ToString() ?? "";
            string diseñador = row["Diseñador"] == DBNull.Value ? "Desconocido" : row["Diseñador"].ToString();
            lblDescripcion.Text = desc + Environment.NewLine + "Diseñador: " + diseñador;

            // Imagen
            string nombreImg = row["RutaImagen"]?.ToString();
            string fullPath = ObtenerRutaCompletaImagen(nombreImg);
            if (pictureBox1.Image != null) { pictureBox1.Image.Dispose(); pictureBox1.Image = null; }

            if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
            {
                pictureBox1.Image = Image.FromFile(fullPath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.Image = null;
            }

            // Likes y comentarios
            CargarLikes();
            CargarComentarios();
        }

        private int ProyectoActualId()
        {
            if (proyectos.Rows.Count == 0) return 0;
            return Convert.ToInt32(proyectos.Rows[index]["Id"]);
        }

        // ================== LIKES ==================
        private void CargarLikes()
        {
            int proyectoId = ProyectoActualId();
            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Likes WHERE ProyectoId=@p", con);
                cmd.Parameters.AddWithValue("@p", proyectoId);
                int total = Convert.ToInt32(cmd.ExecuteScalar());
                lblLikes.Text = $"Likes: {total}";
            }
        }


        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (index < proyectos.Rows.Count - 1)
            {
                index++;
                MostrarProyecto(index);
            }
            else
            {
                MessageBox.Show("Último proyecto.");
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                MostrarProyecto(index);
            }
            else
            {
                MessageBox.Show("Primer proyecto.");
            }
        }



        private void btnLike_Click(object sender, EventArgs e)
        {
            int proyectoId = ProyectoActualId();
            if (proyectoId == 0) return;

            // Validar inicio de sesión
            if (FrmHome.UsuarioId <= 0)
            {
                MessageBox.Show("Debes iniciar sesión para dar like a un proyecto.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new Conexion().Abrir())
            {
                // Evitar likes repetidos
                SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Likes WHERE ProyectoId=@p AND UsuarioId=@u", con);
                check.Parameters.AddWithValue("@p", proyectoId);
                check.Parameters.AddWithValue("@u", FrmHome.UsuarioId);
                int existe = Convert.ToInt32(check.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("Ya diste like a este proyecto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Insertar nuevo like
                SqlCommand cmd = new SqlCommand("INSERT INTO Likes (ProyectoId, UsuarioId, Fecha) VALUES (@p, @u, GETDATE())", con);
                cmd.Parameters.AddWithValue("@p", proyectoId);
                cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("¡Gracias por apoyar este proyecto!", "Like registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarLikes();
        }
        
        // ================== COMENTARIOS ==================
        private void CargarComentarios()
        {
            int proyectoId = ProyectoActualId();
            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT u.NombreUsuario + ': ' + c.Texto AS Comentario
                    FROM Comentarios c
                    JOIN Usuarios u ON c.UsuarioId = u.Id
                    WHERE c.ProyectoId=@p
                    ORDER BY c.Fecha DESC", con);
                da.SelectCommand.Parameters.AddWithValue("@p", proyectoId);
                DataTable dt = new DataTable();
                da.Fill(dt);

                lstComentarios.DataSource = dt;
                lstComentarios.DisplayMember = "Comentario";
            }
        }

        private void btnComentar_Click(object sender, EventArgs e)
        {
            if (FrmHome.UsuarioId <= 0)
            {
                MessageBox.Show("Debes iniciar sesión para comentar un proyecto.", "Acceso restringido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtComentario.Text))
            {
                MessageBox.Show("Escribe un comentario antes de enviarlo.", "Comentario vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int proyectoId = ProyectoActualId();

            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Comentarios (ProyectoId, UsuarioId, Texto, Fecha) VALUES (@p, @u, @t, GETDATE())", con);
                cmd.Parameters.AddWithValue("@p", proyectoId);
                cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId);
                cmd.Parameters.AddWithValue("@t", txtComentario.Text.Trim());
                cmd.ExecuteNonQuery();
            }

            txtComentario.Clear();
            CargarComentarios();
            MessageBox.Show("Comentario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

        private void btnFiltrarLikes_Click(object sender, EventArgs e)
        {
            CargarProyectos(true); // true para ordenar por likes
            if (proyectos.Rows.Count > 0)
            {
                index = 0;
                MostrarProyecto(index);
            }
            else
            {
                lblTitulo.Text = "No hay proyectos disponibles";
                lblDescripcion.Text = "";
                lblLikes.Text = "Likes: 0";
                lstComentarios.DataSource = null;
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        private int ObtenerDiseñadorActualId()
        {
            if (proyectos.Rows.Count == 0) return 0;

            // Necesitamos el Id del diseñador, así que incluye DiseñadorId en la consulta de CargarProyectos
            return Convert.ToInt32(proyectos.Rows[index]["DiseñadorId"]);
        }

        private void btnBiografia_Click(object sender, EventArgs e)
        {
            int diseñadorId = ObtenerDiseñadorActualId();
            if (diseñadorId == 0)
            {
                MessageBox.Show("No se encontró el diseñador de este proyecto.");
                return;
            }

            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Biografia FROM Perfiles WHERE DiseñadorId=@d", con);
                cmd.Parameters.AddWithValue("@d", diseñadorId);

                object result = cmd.ExecuteScalar();
                string bio = result != null ? result.ToString() : "Sin biografía disponible.";

                MessageBox.Show(bio, "Biografía del Diseñador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnContacto_Click(object sender, EventArgs e)
        {
            
            int diseñadorId = ObtenerDiseñadorActualId();
            if (diseñadorId == 0)
            {
                MessageBox.Show("No se encontró el diseñador de este proyecto.");
                return;
            }

            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Instagram, Whatsapp, CorreoContacto FROM Perfiles WHERE DiseñadorId=@d", con);
                cmd.Parameters.AddWithValue("@d", diseñadorId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string insta = reader["Instagram"]?.ToString() ?? "No disponible";
                        string whatsapp = reader["Whatsapp"]?.ToString() ?? "No disponible";
                        string correo = reader["CorreoContacto"]?.ToString() ?? "No disponible";

                        string info = $"Instagram: {insta}\nWhatsapp: {whatsapp}\nCorreo: {correo}";
                        MessageBox.Show(info, "Contacto del Diseñador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la información de contacto para este diseñador.");
                    }
                }
            }
        }
    }
}
