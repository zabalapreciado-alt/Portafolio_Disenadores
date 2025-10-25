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
using System.Net;
using System.Net.Mail;


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
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    // 1️⃣ Obtener ID del reclutador
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

                    // 2️⃣ Validar diseñador
                    if (DiseñadorId <= 0)
                    {
                        MessageBox.Show("No se encontró el diseñador para esta oferta.");
                        return;
                    }

                    // 3️⃣ Insertar oferta
                    string sql = @"INSERT INTO OfertasTrabajo 
                           (ReclutadorId, DiseñadorId, Titulo, Descripcion, Contacto, Estado, Fecha) 
                           VALUES (@r, @d, @t, @desc, @c, 'Pendiente', GETDATE())";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@r", reclutadorId);
                    cmd.Parameters.AddWithValue("@d", DiseñadorId);
                    cmd.Parameters.AddWithValue("@t", txtTitulo.Text.Trim());
                    cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text.Trim());
                    cmd.Parameters.AddWithValue("@c", txtContacto.Text.Trim());
                    cmd.ExecuteNonQuery();

                    // 4️⃣ Obtener correo del diseñador
                    string sqlCorreo = @"SELECT U.CorreoContacto 
                                 FROM Diseñadores D
                                 INNER JOIN Usuarios U ON D.UsuarioId = U.Id
                                 WHERE D.Id = @idD";
                    SqlCommand cmdCorreo = new SqlCommand(sqlCorreo, con);
                    cmdCorreo.Parameters.AddWithValue("@idD", DiseñadorId);

                    object correoObj = cmdCorreo.ExecuteScalar();
                    if (correoObj != null && correoObj != DBNull.Value)
                    {
                        string correoDestino = correoObj.ToString();

                        // 5️⃣ Enviar correo de notificación
                        EnviarCorreoNotificacion(correoDestino, txtTitulo.Text.Trim());
                    }
                }

                MessageBox.Show("Oferta enviada correctamente y notificación enviada.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar la oferta: " + ex.Message);
            }
        }
        public int DiseñadorId { get; set; } //Recibe el diseñador desde frmGaleria

        private void EnviarCorreoNotificacion(string correoDestino, string tituloOferta)
        {
            try
            {
                string remitente = "showart2025@gmail.com";
                string contraseña = "xiuy mrar lcqq jsiv"; 

                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(remitente, "Portafolio Diseñadores");
                mensaje.To.Add(correoDestino);
                mensaje.Subject = "Nueva oferta de trabajo recibida";
                mensaje.Body = $"Has recibido una nueva oferta de trabajo: \"{tituloOferta}\".\n\nPor favor, entra a la aplicación para revisarla.";
                mensaje.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(remitente, contraseña);
                smtp.EnableSsl = true;

                smtp.Send(mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo de notificación: " + ex.Message);
            }
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
