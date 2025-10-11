using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortafolioDiseñadores
{
    public partial class FrmHome : Form
    {
        public static int UsuarioId = 0;
        public static string NombreUsuario = "";
        public static string Rol = "";
        public FrmHome()
        {
            InitializeComponent();
        }
        private void FrmHome_Load(object sender, EventArgs e)
        {
            
            ActualizarUI();
        }

        private void ActualizarUI()
        {
            lblBienvenida.Text = "Bienvenido " + (UsuarioId > 0 ? NombreUsuario : "Invitado");


            btnLogin.Visible = (UsuarioId == 0);
            btnCerrarSesion.Visible = (UsuarioId > 0);

            btnAcercaDe.Visible = (Rol == "admin" || Rol == "diseñador");
            btnContacto.Visible = (Rol == "admin" || Rol == "diseñador");
            btnAdminProyectos.Visible = (Rol == "admin" || Rol == "diseñador");
            btnOfertas.Visible = (Rol == "admin" || Rol == "diseñador");
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmLogin f = new FrmLogin();
            f.ShowDialog();
            ActualizarUI();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            UsuarioId = 0;
            NombreUsuario = "";
            Rol = "";
            ActualizarUI();
        }

        private void btnGaleria_Click(object sender, EventArgs e)
        {
            FrmGaleria f = new FrmGaleria();
            f.ShowDialog();
        }


        private void btnAdminProyectos_Click(object sender, EventArgs e)
        {
            FrmAdminProyectos f = new FrmAdminProyectos();
            f.ShowDialog();
        }

        private void btnOfertas_Click(object sender, EventArgs e)
        {
            FrmOfertasTrabajo f = new FrmOfertasTrabajo();
            f.ShowDialog();
        }


        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            FrmAcercaDe f = new FrmAcercaDe();
            f.ShowDialog();
        }

        private void btnContacto_Click(object sender, EventArgs e)
        {
            FrmContacto f = new FrmContacto();
            f.ShowDialog();
        }

        private void lblBienvenida_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmHome_Load_1(object sender, EventArgs e)
        {

        }


        private void btnBuscarDiseñador_Click(object sender, EventArgs e)
        {
            frmBuscarDiseñador f = new frmBuscarDiseñador();
            f.ShowDialog();
        }
    }
}
