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
            // Cargamos y mostramos sólo si hay resultados
            CargarProyectos();
            if (proyectos.Rows.Count > 0)
            {
                index = 0;
                MostrarProyecto(index);
            }
            else
            {
                // Muestra un mensaje claro y limpia UI
                lblTitulo.Text = "No hay proyectos disponibles";
                lblDescripcion.Text = "";
                if (pictureBox1.Image != null) { pictureBox1.Image.Dispose(); pictureBox1.Image = null; }
            }
        }

        private void CargarProyectos()
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    // Usamos LEFT JOIN para incluir proyectos aunque falte ficha de diseñador
                    string sql = @"
                        SELECT p.Id, p.Titulo, p.Descripcion, p.RutaImagen,
                               d.Nombre AS Diseñador
                        FROM Proyectos p
                        LEFT JOIN Diseñadores d ON p.DiseñadorId = d.Id
                        ORDER BY p.Id DESC"; // o por FechaCreacion si la tienes
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

            string nombreImg = row["RutaImagen"]?.ToString();
            string fullPath = ObtenerRutaCompletaImagen(nombreImg);

            // Manejo seguro de imágenes (liberar antes)
            try
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
                {
                    pictureBox1.Image = Image.FromFile(fullPath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pictureBox1.Image = null; // imagen por defecto si quieres
                }
            }
            catch (Exception ex)
            {
                // No detener la app por error de imagen
                pictureBox1.Image = null;
                Console.WriteLine("Error mostrando imagen: " + ex.Message);
            }
        }


        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (proyectos == null || proyectos.Rows.Count == 0) return;
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
            if (proyectos == null || proyectos.Rows.Count == 0) return;
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

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (proyectos == null || proyectos.Rows.Count == 0) return;
            int proyectoId = Convert.ToInt32(proyectos.Rows[index]["Id"]);
            FrmDetalles f = new FrmDetalles(proyectoId);
            f.ShowDialog();
            // después de cerrar detalles podrías recargar si quieres:
            // CargarProyectos(); MostrarProyecto(index);
        }
    }
}
