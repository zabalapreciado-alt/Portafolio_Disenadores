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
    public partial class FrmGaleria : Form
    {
        private DataTable proyectos;
        private int index = 0;
        public FrmGaleria()
        {
            InitializeComponent();
        }
        private void FrmGaleria_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Proyectos", con);
                proyectos = new DataTable();
                da.Fill(proyectos);
            }
            MostrarProyecto();
        }

        private void MostrarProyecto()
        {
            if (proyectos.Rows.Count == 0) return;

            lblTitulo.Text = proyectos.Rows[index]["Titulo"].ToString();
            lblDescripcion.Text = proyectos.Rows[index]["Descripcion"].ToString();
            pictureBox1.ImageLocation = proyectos.Rows[index]["RutaImagen"].ToString();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (index < proyectos.Rows.Count - 1) index++;
            MostrarProyecto();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (index > 0) index--;
            MostrarProyecto();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(proyectos.Rows[index]["Id"]);
            FrmDetalles f = new FrmDetalles(id);
            f.ShowDialog();
        }
    }
}
