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
    public partial class FrmOfertasTrabajo : Form
    {
        public FrmOfertasTrabajo()
        {
            InitializeComponent();
        }
        private void FrmOfertasTrabajo_Load(object sender, EventArgs e)
        {
            CargarOfertas();
        }

        private void CargarOfertas()
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM OfertasTrabajo", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOfertas.DataSource = dt;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvOfertas.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvOfertas.CurrentRow.Cells["Id"].Value);

            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlCommand cmd = new SqlCommand("UPDATE OfertasTrabajo SET Estado='Aceptada' WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Oferta aceptada.");
            CargarOfertas();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (dgvOfertas.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvOfertas.CurrentRow.Cells["Id"].Value);

            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlCommand cmd = new SqlCommand("UPDATE OfertasTrabajo SET Estado='Rechazada' WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Oferta rechazada.");
            CargarOfertas();
        }
    }
}

