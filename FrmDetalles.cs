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
                SqlCommand cmd = new SqlCommand("SELECT Titulo, Descripcion FROM Proyectos WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", proyectoId);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblTitulo.Text = dr.GetString(0);
                    lblDescripcion.Text = dr.GetString(1);
                }
            }
        }

        private void CargarComentarios()
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Texto FROM Comentarios WHERE ProyectoId=@id", con);
                da.SelectCommand.Parameters.AddWithValue("@id", proyectoId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                lstComentarios.DataSource = dt;
                lstComentarios.DisplayMember = "Texto";
            }
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Likes (ProyectoId, UsuarioId) VALUES (@p, @u)", con);
                cmd.Parameters.AddWithValue("@p", proyectoId);
                cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId > 0 ? FrmHome.UsuarioId : (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Like agregado.");
        }

        private void btnComentar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtComentario.Text)) return;

            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Comentarios (ProyectoId, UsuarioId, Texto) VALUES (@p, @u, @t)", con);
                cmd.Parameters.AddWithValue("@p", proyectoId);
                cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId > 0 ? FrmHome.UsuarioId : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@t", txtComentario.Text.Trim());
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Comentario agregado.");
            txtComentario.Clear();
            CargarComentarios();
        }
    }
}
