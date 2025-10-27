using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortafolioDiseñadores
{
    public partial class frmBuscarDiseñador : Form
    {
        private DataTable proyectos = new DataTable();
        private int index = 0;
        public int DiseñadorIdBuscado { get; set; }
        public frmBuscarDiseñador()
        {
            InitializeComponent();

            btnNuevaOferta.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(nombreUsuario))
            {
                MessageBox.Show("Por favor, ingrese el nombre de usuario del diseñador.");
                return;
            }

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    
                    SqlCommand cmdId = new SqlCommand(@"
                        SELECT d.Id 
                        FROM Diseñadores d
                        JOIN Usuarios u ON d.UsuarioId = u.Id
                        WHERE u.NombreUsuario = @n", con);
                    cmdId.Parameters.AddWithValue("@n", nombreUsuario);

                    object result = cmdId.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("No se encontró ningún diseñador con ese nombre de usuario.");
                        return;
                    }

                    DiseñadorIdBuscado = Convert.ToInt32(result);

                    
                    SqlCommand cmdPerfil = new SqlCommand(@"
                        SELECT 
                            u.NombreUsuario,
                            u.Biografia,
                            u.Instagram,
                            u.WhatsApp,
                            u.CorreoContacto
                        FROM Diseñadores d
                        JOIN Usuarios u ON d.UsuarioId = u.Id
                        WHERE d.Id = @id", con);
                    cmdPerfil.Parameters.AddWithValue("@id", DiseñadorIdBuscado);

                    using (SqlDataReader reader = cmdPerfil.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblUsuario.Text = reader["NombreUsuario"]?.ToString() ?? "No disponible";
                            lblBio.Text = reader["Biografia"]?.ToString() ?? "Sin biografía.";
                            lblInstagram.Text = reader["Instagram"]?.ToString() ?? "No disponible";
                            lblWhatsapp.Text = reader["WhatsApp"]?.ToString() ?? "No disponible";
                            lblCorreo.Text = reader["CorreoContacto"]?.ToString() ?? "No disponible";
                        }
                        else
                        {
                            lblUsuario.Text = lblBio.Text = lblInstagram.Text = lblWhatsapp.Text = lblCorreo.Text = "";
                            MessageBox.Show("No se encontró información del perfil de este diseñador.");
                        }
                    }

                    
                    SqlCommand cmdOfertas = new SqlCommand(@"
                        SELECT COUNT(*) 
                        FROM OfertasTrabajo 
                        WHERE DiseñadorId = @id", con);
                    cmdOfertas.Parameters.AddWithValue("@id", DiseñadorIdBuscado);

                    int totalOfertas = Convert.ToInt32(cmdOfertas.ExecuteScalar());
                    lblOfertasRecibidas.Text = $"Ofertas Recibidas: {totalOfertas}";

                    
                    CargarProyectosDelDiseñador(con);
                }

                
                if (proyectos.Rows.Count > 0)
                {
                    index = 0;
                    MostrarProyecto(index);
                }
                else
                {
                    lblTitulo.Text = "No hay proyectos de este diseñador.";
                    lblDescripcion.Text = "";
                    lblLikes.Text = "Likes: 0";
                    if (picProyectos.Image != null) picProyectos.Image.Dispose();
                    picProyectos.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar diseñador: " + ex.Message);
            }

            
            if ((FrmHome.Rol == "reclutador" || FrmHome.Rol == "admin") && DiseñadorIdBuscado > 0)
            {
                btnNuevaOferta.Visible = true;
            }
            else
            {
                btnNuevaOferta.Visible = false;
            }
        }


        private void CargarProyectosDelDiseñador(SqlConnection con)
        {
            try
            {
                string sql = @"
                    SELECT p.Id, p.Titulo, p.Descripcion, p.RutaImagen,
                           p.DiseñadorId, d.Nombre AS Diseñador
                    FROM Proyectos p
                    LEFT JOIN Diseñadores d ON p.DiseñadorId = d.Id
                    WHERE p.DiseñadorId = @d
                    ORDER BY p.Id DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@d", DiseñadorIdBuscado);

                proyectos.Clear();
                da.Fill(proyectos);
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
            string diseñador = row["Diseñador"]?.ToString() ?? "Desconocido";
            lblDescripcion.Text = desc + Environment.NewLine + "Diseñador: " + diseñador;

            string nombreImg = row["RutaImagen"]?.ToString();
            string fullPath = ObtenerRutaCompletaImagen(nombreImg);

            if (picProyectos.Image != null)
            {
                picProyectos.Image.Dispose();
                picProyectos.Image = null;
            }

            if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
            {
                picProyectos.Image = Image.FromFile(fullPath);
                picProyectos.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                picProyectos.Image = null;
            }

            CargarLikes();
        }

        private int ProyectoActualId()
        {
            if (proyectos.Rows.Count == 0) return 0;
            return Convert.ToInt32(proyectos.Rows[index]["Id"]);
        }
        private void CargarLikes()
        {
            int proyectoId = ProyectoActualId();
            if (proyectoId == 0)
            {
                lblLikes.Text = "Likes: 0";
                return;
            }

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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaOferta_Click(object sender, EventArgs e)
        {
            if (DiseñadorIdBuscado <= 0)
            {
                MessageBox.Show("Debe buscar un diseñador antes de crear una oferta.");
                return;
            }

            
            FrmNuevaOferta frm = new FrmNuevaOferta();
            frm.DiseñadorId = DiseñadorIdBuscado;
            frm.ShowDialog();
        }
    }
}

