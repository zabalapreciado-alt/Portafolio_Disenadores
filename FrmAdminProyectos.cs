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
    public partial class FrmAdminProyectos : Form
    {
        private string rutaImagenNombre = ""; // guardamos solo el nombre del archivo, no la ruta completa
        public FrmAdminProyectos()
        {
            InitializeComponent();
        }

        private void CargarProyectos()
        {
            

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    

                    // Obtenemos el ID del diseñador vinculado al usuario
                    int disenadorId = ObtenerDisenadorId(con, FrmHome.UsuarioId);

                    

                    string sql = @"SELECT p.Id, d.Nombre AS Diseñador, p.Titulo, p.Descripcion, p.Categoria, p.RutaImagen
                           FROM Proyectos p
                           JOIN Diseñadores d ON p.DiseñadorId = d.Id
                           WHERE p.DiseñadorId = @disenadorId";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.SelectCommand.Parameters.AddWithValue("@disenadorId", disenadorId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProyectos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando proyectos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    int disenadorId = ObtenerDisenadorId(con, FrmHome.UsuarioId);
                    if (disenadorId == 0)
                    {
                        MessageBox.Show("No se encontró ficha de diseñador.");
                        return;
                    }

                    string sql = @"INSERT INTO Proyectos (DiseñadorId, Titulo, Descripcion, Categoria, RutaImagen) 
                                   VALUES (@d, @t, @desc, @c, @r)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@d", disenadorId);
                        cmd.Parameters.AddWithValue("@t", txtTitulo.Text.Trim());
                        cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@c", txtCategoria.Text.Trim());
                        cmd.Parameters.AddWithValue("@r", rutaImagenNombre);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Proyecto agregado.");
                CargarProyectos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProyectos.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvProyectos.CurrentRow.Cells["Id"].Value);

            
            string tituloOriginal = dgvProyectos.CurrentRow.Cells["Titulo"].Value?.ToString();
            string descripcionOriginal = dgvProyectos.CurrentRow.Cells["Descripcion"].Value?.ToString();
            string categoriaOriginal = dgvProyectos.CurrentRow.Cells["Categoria"].Value?.ToString();
            string rutaImagenOriginal = dgvProyectos.CurrentRow.Cells["RutaImagen"].Value?.ToString();

            
            string nuevoTitulo = txtTitulo.Text.Trim();
            string nuevaDescripcion = txtDescripcion.Text.Trim();
            string nuevaCategoria = txtCategoria.Text.Trim();
            string nuevaRutaImagen = rutaImagenNombre;

            
            if (string.IsNullOrEmpty(nuevaRutaImagen))
            {
                nuevaRutaImagen = rutaImagenOriginal;
            }

            // ✅ Verificamos si hay cambios
            bool huboCambios =
                nuevoTitulo != tituloOriginal ||
                nuevaDescripcion != descripcionOriginal ||
                nuevaCategoria != categoriaOriginal ||
                nuevaRutaImagen != rutaImagenOriginal;

            if (!huboCambios)
            {
                MessageBox.Show("No se detectaron cambios para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql = @"UPDATE Proyectos 
                           SET Titulo=@t, Descripcion=@d, Categoria=@c, RutaImagen=@r 
                           WHERE Id=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@t", nuevoTitulo);
                        cmd.Parameters.AddWithValue("@d", nuevaDescripcion);
                        cmd.Parameters.AddWithValue("@c", nuevaCategoria);
                        cmd.Parameters.AddWithValue("@r", nuevaRutaImagen);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Proyecto actualizado correctamente.");
                CargarProyectos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProyectos.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvProyectos.CurrentRow.Cells["Id"].Value);

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Proyectos WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Proyecto eliminado.");
                CargarProyectos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string imagesFolder = Path.Combine(Application.StartupPath, "Imagenes");
                    Directory.CreateDirectory(imagesFolder);

                    string fileName = Path.GetFileName(ofd.FileName);
                    string destPath = Path.Combine(imagesFolder, fileName);

                    if (File.Exists(destPath))
                    {
                        string newName = $"{DateTime.Now.Ticks}_{fileName}";
                        destPath = Path.Combine(imagesFolder, newName);
                        fileName = newName;
                    }

                    File.Copy(ofd.FileName, destPath);
                    rutaImagenNombre = fileName;
                    pbImagen.ImageLocation = destPath;
                }
            }
        }
        private int ObtenerDisenadorId(SqlConnection con, int usuarioId)
        {
            

            string sql = "SELECT Id FROM Diseñadores WHERE UsuarioId = @u";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@u", usuarioId);
            object res = cmd.ExecuteScalar();
            return (res == null) ? 0 : Convert.ToInt32(res);

        }


        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtDescripcion.Clear();
            txtCategoria.Clear();
            pbImagen.Image = null;
            rutaImagenNombre = "";
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmAdminProyectos_Load_1(object sender, EventArgs e)
        {
            CargarProyectos();
        }

        private void dgvProyectos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            DataGridViewRow row = dgvProyectos.Rows[e.RowIndex];

            
            txtTitulo.Text = row.Cells["Titulo"].Value?.ToString();
            txtDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();
            txtCategoria.Text = row.Cells["Categoria"].Value?.ToString();

            
            string nombreImagen = row.Cells["RutaImagen"].Value?.ToString();

            if (!string.IsNullOrEmpty(nombreImagen))
            {
                string rutaCompleta = Path.Combine(Application.StartupPath, "Imagenes", nombreImagen);
                if (File.Exists(rutaCompleta))
                {
                    pbImagen.Image = Image.FromFile(rutaCompleta);
                    pbImagen.SizeMode = PictureBoxSizeMode.Zoom; 
                }
                else
                {
                    pbImagen.Image = null;
                    MessageBox.Show("La imagen no se encontró en la carpeta del proyecto.");
                }
            }
            else
            {
                pbImagen.Image = null;
            }
        }
    }
}

