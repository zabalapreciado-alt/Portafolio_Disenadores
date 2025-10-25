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
            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sql;
                    SqlDataAdapter da;

                    if (FrmHome.Rol == "admin")
                    {
                        
                        sql = @"SELECT O.Id, 
                               R.Empresa AS Reclutador, 
                               O.Titulo, 
                               O.Descripcion, 
                               O.Contacto, 
                               O.Estado, 
                               O.Fecha
                        FROM OfertasTrabajo O
                        JOIN Reclutadores R ON O.ReclutadorId = R.Id
                        ORDER BY O.Fecha DESC";
                        da = new SqlDataAdapter(sql, con);
                    }
                    else if (FrmHome.Rol == "diseñador")
                    {
                        
                        string q = "SELECT Id FROM Diseñadores WHERE UsuarioId = @u";
                        using (SqlCommand cmd = new SqlCommand(q, con))
                        {
                            cmd.Parameters.AddWithValue("@u", FrmHome.UsuarioId);
                            object res = cmd.ExecuteScalar();
                            if (res == null)
                            {
                                MessageBox.Show("No se encontró diseñador asociado.");
                                return;
                            }
                            int diseñadorId = Convert.ToInt32(res);

                            sql = @"SELECT O.Id, 
                                   R.Empresa AS Reclutador, 
                                   O.Titulo, 
                                   O.Descripcion, 
                                   O.Contacto, 
                                   O.Estado, 
                                   O.Fecha
                            FROM OfertasTrabajo O
                            JOIN Reclutadores R ON O.ReclutadorId = R.Id
                            WHERE O.DiseñadorId = @d
                            ORDER BY O.Fecha DESC
                            ";
                            da = new SqlDataAdapter(sql, con);
                            da.SelectCommand.Parameters.AddWithValue("@d", diseñadorId);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No tienes permisos para ver ofertas.");
                        return;
                    }

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOfertas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando ofertas: " + ex.Message);
            }
        }

        //private void CambiarEstadoSeleccion(string nuevoEstado)
        //{
        //    if (dgvOfertas.CurrentRow == null)
        //    {
        //        MessageBox.Show("Seleccione una oferta.");
        //        return;
        //    }

        //    int id = Convert.ToInt32(dgvOfertas.CurrentRow.Cells["Id"].Value);

        //    try
        //    {
        //        using (SqlConnection con = new Conexion().Abrir())
        //        {
        //            // 🔹 1️⃣ Obtener datos necesarios
        //            string sqlInfo = @"
        //        SELECT 
        //            O.Titulo,
        //            R.Contacto AS CorreoReclutador,
        //            R.Empresa,
        //            D.Nombre AS NombreDiseñador
        //        FROM OfertasTrabajo O
        //        INNER JOIN Reclutadores R ON O.ReclutadorId = R.Id
        //        INNER JOIN Diseñadores D ON O.DiseñadorId = D.Id
        //        WHERE O.Id = @id";

        //            SqlCommand cmdInfo = new SqlCommand(sqlInfo, con);
        //            cmdInfo.Parameters.AddWithValue("@id", id);

        //            using (SqlDataReader reader = cmdInfo.ExecuteReader())
        //            {
        //                if (!reader.Read())
        //                {
        //                    MessageBox.Show("No se encontraron datos para la oferta seleccionada.");
        //                    return;
        //                }

        //                string titulo = reader["Titulo"].ToString();
        //                string correoReclutador = reader["CorreoReclutador"].ToString();
        //                string empresa = reader["Empresa"].ToString();
        //                string nombreDiseñador = reader["NombreDiseñador"].ToString();

        //                reader.Close();

        //                // 🔹 2️⃣ Actualizar estado
        //                string sql = "UPDATE OfertasTrabajo SET Estado=@e WHERE Id=@id";
        //                using (SqlCommand cmd = new SqlCommand(sql, con))
        //                {
        //                    cmd.Parameters.AddWithValue("@e", nuevoEstado);
        //                    cmd.Parameters.AddWithValue("@id", id);
        //                    cmd.ExecuteNonQuery();
        //                }

        //                // 🔹 3️⃣ Enviar correo de notificación al reclutador
        //                EnviarCorreoReclutador(correoReclutador, nombreDiseñador, titulo, nuevoEstado);
        //            }
        //        }

        //        MessageBox.Show("Oferta actualizada y notificación enviada.");
        //        CargarOfertas();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error cambiando estado: " + ex.Message);
        //    }
        //}
        private void CambiarEstadoSeleccion(string nuevoEstado)
        {
            if (dgvOfertas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una oferta para continuar.");
                return;
            }

            int id = Convert.ToInt32(dgvOfertas.CurrentRow.Cells["Id"].Value);
            string estadoActual = dgvOfertas.CurrentRow.Cells["Estado"].Value?.ToString();

            // 🔹 1️⃣ Evitar cambiar ofertas que ya no estén pendientes
            if (!estadoActual.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"No se puede cambiar una oferta que ya está {estadoActual}.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔹 2️⃣ Confirmar acción con el diseñador
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea marcar esta oferta como '{nuevoEstado}'?",
                "Confirmar acción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
            {
                MessageBox.Show("Operación cancelada por el usuario.");
                return;
            }

            try
            {
                using (SqlConnection con = new Conexion().Abrir())
                {
                    // 🔹 3️⃣ Obtener datos necesarios para enviar correo
                    string sqlInfo = @"
                SELECT 
                    O.Titulo,
                    R.Contacto AS CorreoReclutador,
                    R.Empresa,
                    D.Nombre AS NombreDiseñador
                FROM OfertasTrabajo O
                INNER JOIN Reclutadores R ON O.ReclutadorId = R.Id
                INNER JOIN Diseñadores D ON O.DiseñadorId = D.Id
                WHERE O.Id = @id";

                    SqlCommand cmdInfo = new SqlCommand(sqlInfo, con);
                    cmdInfo.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmdInfo.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("No se encontraron datos para la oferta seleccionada.");
                            return;
                        }

                        string titulo = reader["Titulo"].ToString();
                        string correoReclutador = reader["CorreoReclutador"].ToString();
                        string empresa = reader["Empresa"].ToString();
                        string nombreDiseñador = reader["NombreDiseñador"].ToString();

                        reader.Close();

                        // 🔹 4️⃣ Actualizar estado en base de datos
                        string sqlUpdate = "UPDATE OfertasTrabajo SET Estado=@e WHERE Id=@id";
                        using (SqlCommand cmd = new SqlCommand(sqlUpdate, con))
                        {
                            cmd.Parameters.AddWithValue("@e", nuevoEstado);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // 🔹 5️⃣ Enviar correo al reclutador
                        EnviarCorreoReclutador(correoReclutador, nombreDiseñador, titulo, nuevoEstado);
                    }
                }

                MessageBox.Show($"La oferta ha sido marcada como '{nuevoEstado}' y se notificó al reclutador.", "Operación exitosa");
                CargarOfertas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cambiando estado: " + ex.Message);
            }
        }


        private void EnviarCorreoReclutador(string correoDestino, string nombreDiseñador, string tituloOferta, string estado)
        {
            try
            {
                string remitente = "showart2025@gmail.com";
                string contraseña = "xiuy mrar lcqq jsiv";

                // 🔹 Obtener el correo del diseñador (desde la tabla Usuarios)
                string correoDiseñador = "";
                using (SqlConnection con = new Conexion().Abrir())
                {
                    string sqlCorreo = @"
                SELECT u.CorreoContacto 
                FROM Usuarios u
                INNER JOIN Diseñadores d ON u.Id = d.UsuarioId
                WHERE d.Nombre = @nombre";
                    SqlCommand cmd = new SqlCommand(sqlCorreo, con);
                    cmd.Parameters.AddWithValue("@nombre", nombreDiseñador);
                    object res = cmd.ExecuteScalar();
                    if (res != null)
                        correoDiseñador = res.ToString();
                }

                // 🔹 Crear mensaje base
                string cuerpo = $"Hola,\n\nTu oferta de trabajo \"{tituloOferta}\" ha sido {estado.ToUpper()} por el diseñador {nombreDiseñador}.";

                // 🔹 Si fue aceptada, agregar información de contacto
                if (estado.Equals("Aceptada", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(correoDiseñador))
                {
                    cuerpo += $"\n\nPara más detalles, comuníquese directamente al correo: {correoDiseñador}";
                }

                // 🔹 Construcción del mensaje
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(remitente, "Portafolio Diseñadores");
                mensaje.To.Add(correoDestino);
                mensaje.Subject = $"Actualización de tu oferta: {tituloOferta}";
                mensaje.Body = cuerpo;
                mensaje.IsBodyHtml = false;

                // 🔹 Configuración SMTP
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(remitente, contraseña);
                smtp.EnableSsl = true;

                smtp.Send(mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo al reclutador: " + ex.Message);
            }
        }




        private void btnAceptar_Click(object sender, EventArgs e) => CambiarEstadoSeleccion("Aceptada");


        private void btnRechazar_Click(object sender, EventArgs e) => CambiarEstadoSeleccion("Rechazada");

        private void dgvOfertas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOfertas.Columns[e.ColumnIndex].Name == "Estado")
            {
                string estado = e.Value?.ToString();
                if (estado == "Pendiente")
                    e.CellStyle.BackColor = Color.LightYellow;
                else if (estado == "Aceptada")
                    e.CellStyle.BackColor = Color.LightGreen;
                else if (estado == "Rechazada")
                    e.CellStyle.BackColor = Color.LightCoral;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

