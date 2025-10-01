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
    public partial class FrmNuevaOferta : Form
    {
        public FrmNuevaOferta()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = "INSERT INTO OfertasTrabajo (ReclutadorId, DiseñadorId, Titulo, Descripcion, Contacto, Estado, Fecha) VALUES (@r, @d, @t, @desc, @c, 'Pendiente', GETDATE())";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@r", FrmHome.UsuarioId);
                cmd.Parameters.AddWithValue("@d", 1); // el diseñador principal
                cmd.Parameters.AddWithValue("@t", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@c", txtContacto.Text);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Oferta enviada.");
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
