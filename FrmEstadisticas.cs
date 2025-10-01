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
    public partial class FrmEstadisticas : Form
    {
        public FrmEstadisticas()
        {
            InitializeComponent();
        }
        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = @"
                    SELECT p.Id, p.Titulo,
                           (SELECT COUNT(*) FROM Likes l WHERE l.ProyectoId = p.Id) AS TotalLikes,
                           (SELECT COUNT(*) FROM Comentarios c WHERE c.ProyectoId = p.Id) AS TotalComentarios
                    FROM Proyectos p";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvEstadisticas.DataSource = dt;
            }
        }
    }
}
