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
    public partial class FrmDetalles : Form
    {
        private int proyectoId;

        public FrmDetalles(int id)
        {
            InitializeComponent();
            proyectoId = id;
        }
        private void FrmDetalles_Load(object sender, EventArgs e)
        {
            CargarDetalles();
            CargarComentarios();
        }

        
            private void CargarDetalles()
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = "SELECT Titulo, Descripcion, RutaImagen FROM Proyectos WHERE Id=@id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", proyectoId);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        lblTitulo.Text = dr["Titulo"]?.ToString() ?? "(Sin título)";
                        lblDescripcion.Text = dr["Descripcion"]?.ToString() ?? "(Sin descripción)";

                        string nombreImg = dr["RutaImagen"]?.ToString();
                        if (!string.IsNullOrEmpty(nombreImg))
                        {
                            string fullPath = Path.Combine(Application.StartupPath, "Imagenes", nombreImg);
                            if (File.Exists(fullPath))
                            {
                                // liberar imagen previa antes de asignar
                                if (pbImagen.Image != null)
                                {
                                    pbImagen.Image.Dispose();
                                    pbImagen.Image = null;
                                }
                                pbImagen.Image = Image.FromFile(fullPath);
                                pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                            else
                            {
                                pbImagen.Image = null;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el proyecto con Id " + proyectoId);
                    }
                }
            }
        }
        

        private void CargarComentarios()
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = @"SELECT u.NombreUsuario + ': ' + c.Texto AS Comentario
                       FROM Comentarios c
                       JOIN Usuarios u ON c.UsuarioId = u.Id
                       WHERE c.ProyectoId=@id
                       ORDER BY c.Fecha DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.SelectCommand.Parameters.AddWithValue("@id", proyectoId);
                DataTable dt = new DataTable();
                da.Fill(dt);

                lstComentarios.DataSource = dt;
                lstComentarios.DisplayMember = "Comentario";
            }
        }



        private void btnLike_Click(object sender, EventArgs e)
        {
            if (FrmHome.UsuarioId <= 0)
            {
                MessageBox.Show("Debes iniciar sesión para dar like.");
                return;
            }

            using (SqlConnection con = new Conexion().Abrir())
            {
                // validar duplicado
                string check = "SELECT COUNT(*) FROM Likes WHERE ProyectoId=@p AND UsuarioId=@u";
                SqlCommand cmdCheck = new SqlCommand(check, con);
                cmdCheck.Parameters.AddWithValue("@p", proyectoId);
                cmdCheck.Parameters.AddWithValue("@u", FrmHome.UsuarioId);

                int existe = (int)cmdCheck.ExecuteScalar();

                if (existe > 0)
                {
                    MessageBox.Show("Ya diste like a este proyecto.");
                    return;
                }

                string insert = "INSERT INTO Likes (ProyectoId, UsuarioId, Fecha) VALUES (@p, @u, GETDATE())";
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.AddWithValue("@p", proyectoId);
                cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Like agregado.");
        }

        private void btnComentar_Click(object sender, EventArgs e)
        {
            if (FrmHome.UsuarioId <= 0)
            {
                MessageBox.Show("Debes iniciar sesión para comentar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtComentario.Text)) return;

            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = "INSERT INTO Comentarios (ProyectoId, UsuarioId, Texto, Fecha) VALUES (@p, @u, @t, GETDATE())";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@p", proyectoId);
                cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId);
                cmd.Parameters.AddWithValue("@t", txtComentario.Text.Trim());
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Comentario agregado.");
            txtComentario.Clear();
            CargarComentarios(); // refrescar inmediatamente
        }
    }
    }

    

