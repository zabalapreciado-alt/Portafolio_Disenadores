using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            btnEstadisticas.Visible = (Rol == "admin");
            btnAdminProyectos.Visible = (Rol == "admin");
            btnOfertas.Visible = (Rol == "admin" || Rol == "diseñador");
            btnNuevaOferta.Visible = (Rol == "reclutador");
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

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            FrmEstadisticas f = new FrmEstadisticas();
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

        private void btnNuevaOferta_Click(object sender, EventArgs e)
        {
            FrmNuevaOferta f = new FrmNuevaOferta();
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
    }
}
