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
                // 1. Obtener el ReclutadorId real desde la tabla Reclutadores
                string q = "SELECT Id FROM Reclutadores WHERE UsuarioId = @u";
                SqlCommand cmdGet = new SqlCommand(q, con);
                cmdGet.Parameters.AddWithValue("@u", FrmHome.UsuarioId);
                object res = cmdGet.ExecuteScalar();

                if (res == null)
                {
                    MessageBox.Show("No se encontró un reclutador asociado a este usuario.");
                    return;
                }

                int reclutadorId = Convert.ToInt32(res);

                // 2. Insertar la oferta con el ReclutadorId correcto
                string sql = @"INSERT INTO OfertasTrabajo 
                       (ReclutadorId, DiseñadorId, Titulo, Descripcion, Contacto, Estado, Fecha) 
                       VALUES (@r, @d, @t, @desc, @c, 'Pendiente', GETDATE())";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@r", reclutadorId);
                cmd.Parameters.AddWithValue("@d", 2); // DiseñadorId de Maria Clara (o dinámico)
                cmd.Parameters.AddWithValue("@t", txtTitulo.Text.Trim());
                cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text.Trim());
                cmd.Parameters.AddWithValue("@c", txtContacto.Text.Trim());
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Oferta enviada correctamente.");
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
