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
    public partial class FrmAdminProyectos : Form
    {
        private string rutaImagen = "";
        public FrmAdminProyectos()
        {
            InitializeComponent();
        }
        private void FrmAdminProyectos_Load(object sender, EventArgs e)
        {
            CargarProyectos();
        }

        private void CargarProyectos()
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Proyectos", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProyectos.DataSource = dt;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = "INSERT INTO Proyectos (DiseñadorId, Titulo, Descripcion, Categoria, RutaImagen) VALUES (@i, @t, @d, @c, @r)";
                SqlCommand cmd = new SqlCommand(sql, con);
                int diseñadorid = 1;
                cmd.Parameters.AddWithValue("@i", diseñadorid);
                cmd.Parameters.AddWithValue("@t", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@d", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@c", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@r", rutaImagen);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Proyecto agregado.");
            CargarProyectos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProyectos.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvProyectos.CurrentRow.Cells["Id"].Value);

            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = "UPDATE Proyectos SET Titulo=@t, Descripcion=@d, Categoria=@c, RutaImagen=@r WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@t", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@d", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@c", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@r", rutaImagen);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Proyecto actualizado.");
            CargarProyectos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProyectos.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvProyectos.CurrentRow.Cells["Id"].Value);

            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Proyectos WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Proyecto eliminado.");
            CargarProyectos();
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagen = ofd.FileName;
                    pbImagen.ImageLocation = rutaImagen;
                }
            }
        }
    }
}
