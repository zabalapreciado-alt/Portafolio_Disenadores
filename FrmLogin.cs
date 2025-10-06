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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new Conexion().Abrir())
            {
                string sql = "SELECT Id, NombreUsuario, Rol FROM Usuarios WHERE NombreUsuario=@u AND Contraseña=@p";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@u", txtUsuario.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtContraseña.Text.Trim());

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    FrmHome.UsuarioId = dr.GetInt32(0);
                    FrmHome.NombreUsuario = dr.GetString(1);
                    FrmHome.Rol = dr.GetString(2);

                    MessageBox.Show("Login correcto.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    

