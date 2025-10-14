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
    public partial class frmRegistrarse : Form
    {
        public frmRegistrarse()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistrarse_Load(object sender, EventArgs e)
        {
            cmbRol.Items.Add("diseñador");
            cmbRol.Items.Add("reclutador");
            cmbRol.SelectedIndex = 0;

            grbDiseñador.Visible = false;
            grbReclutador.Visible = false;
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rol = cmbRol.SelectedItem.ToString();

            if (rol == "diseñador")
            {
                grbDiseñador.Visible = true;
                grbReclutador.Visible = false;
            }
            else if (rol == "reclutador")
            {
                grbDiseñador.Visible = false;
                grbReclutador.Visible = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor complete los campos obligatorios.");
                return;
            }

            string rol = cmbRol.SelectedItem.ToString();

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                   
                    string sqlUsuario = "INSERT INTO Usuarios (NombreUsuario, Contraseña, Rol) " +
                                        "VALUES (@u, @p, @r); SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdUsuario = new SqlCommand(sqlUsuario, con);
                    cmdUsuario.Parameters.AddWithValue("@u", txtUsuario.Text.Trim());
                    cmdUsuario.Parameters.AddWithValue("@p", txtContraseña.Text.Trim());
                    cmdUsuario.Parameters.AddWithValue("@r", rol);

                    int nuevoUsuarioId = Convert.ToInt32(cmdUsuario.ExecuteScalar());

                   
                    if (rol == "diseñador")
                    {
                        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                            string.IsNullOrWhiteSpace(txtEspecialidad.Text))
                        {
                            MessageBox.Show("Por favor complete los campos del diseñador.");
                            return;
                        }

                        string sqlDis = "INSERT INTO Diseñadores (UsuarioId, Nombre, Especialidad) " +
                                        "VALUES (@idU, @n, @e)";
                        SqlCommand cmdDis = new SqlCommand(sqlDis, con);
                        cmdDis.Parameters.AddWithValue("@idU", nuevoUsuarioId);
                        cmdDis.Parameters.AddWithValue("@n", txtNombre.Text.Trim());
                        cmdDis.Parameters.AddWithValue("@e", txtEspecialidad.Text.Trim());
                        cmdDis.ExecuteNonQuery();
                    }
                    else if (rol == "reclutador")
                    {
                        if (string.IsNullOrWhiteSpace(txtEmpresa.Text) ||
                            string.IsNullOrWhiteSpace(txtContacto.Text))
                        {
                            MessageBox.Show("Por favor complete los campos del reclutador.");
                            return;
                        }

                        string sqlRec = "INSERT INTO Reclutadores (UsuarioId, Empresa, Contacto) " +
                                        "VALUES (@idU, @emp, @con)";
                        SqlCommand cmdRec = new SqlCommand(sqlRec, con);
                        cmdRec.Parameters.AddWithValue("@idU", nuevoUsuarioId);
                        cmdRec.Parameters.AddWithValue("@emp", txtEmpresa.Text.Trim());
                        cmdRec.Parameters.AddWithValue("@con", txtContacto.Text.Trim());
                        cmdRec.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuario registrado correctamente.");
                    LimpiarCampos();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtNombre.Clear();
            txtEspecialidad.Clear();
            txtEmpresa.Clear();
            txtContacto.Clear();
            cmbRol.SelectedIndex = 0;
            grbDiseñador.Visible = false;
            grbReclutador.Visible = false;
        }
    }
}

