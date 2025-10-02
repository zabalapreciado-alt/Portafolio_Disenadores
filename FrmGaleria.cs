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
                lblTitulo.Text = "";
                lblDescripcion.Text = "";
                pictureBox1.Image = null;
                MessageBox.Show("No hay proyectos en la galería.");
            }
        }

        private void CargarProyectos()
        {
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = "SELECT Id, Titulo, Descripcion, RutaImagen FROM Proyectos ORDER BY Id";
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
            if (proyectos.Rows.Count == 0) return;

            lblTitulo.Text = proyectos.Rows[i]["Titulo"].ToString();
            lblDescripcion.Text = proyectos.Rows[i]["Descripcion"].ToString();

            string nombreImg = proyectos.Rows[i]["RutaImagen"].ToString();
            string fullPath = ObtenerRutaCompletaImagen(nombreImg);

            if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(fullPath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                pictureBox1.Image = null; // o asigna una imagen por defecto
            }
        }


        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (proyectos.Rows.Count == 0) return;
            if (index < proyectos.Rows.Count - 1)
            {
                index++;
                MostrarProyecto(index);
            }
            else MessageBox.Show("Último proyecto.");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (proyectos.Rows.Count == 0) return;
            if (index > 0)
            {
                index--;
                MostrarProyecto(index);
            }
            else MessageBox.Show("Primer proyecto.");
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (proyectos.Rows.Count == 0) return;
            int proyectoId = Convert.ToInt32(proyectos.Rows[index]["Id"]);
            FrmDetalles f = new FrmDetalles(proyectoId);
            f.ShowDialog(); 
        }
    }
}
