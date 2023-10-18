using BE;
using MPP;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using System.Threading;

namespace BLL
{
    public class BLLBalneario
    {
        MPPBalneario mPPBalneario = new MPPBalneario();
        BLLBitacora oBit = new BLLBitacora();
        public bool incribir_balneario(BEBalneario balneario, List<BECarpa> carpas, byte[] imageData, int idUser)
        {
            try
            {
                return mPPBalneario.incribir_balneario(balneario, carpas, imageData, idUser);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }
        public DataTable get_messages(int balneario, DateTime inicio, DateTime fin)
        {
            try
            {
                return mPPBalneario.get_messages(balneario, inicio, fin);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }
        public DataTable get_stars(int balneario, DateTime inicio, DateTime fin)
        {
            try
            {
                return mPPBalneario.get_stars(balneario, inicio, fin);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }

        public DataTable get_revenue(int balneario, DateTime inicio, DateTime fin)
        {
            try
            {
                return mPPBalneario.get_revenue(balneario, inicio, fin);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }

        public IList<BEBalneario> GetAllBalnearios(int idUser, int pag)
        {
            try
            {
                return mPPBalneario.GetAllBalnearios(idUser, pag);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }

        public void eliminar_balneario(int id)
        {
            try
            {
                DataTable data = mPPBalneario.busca_eliminar_balneario(id);
                IList<BEEalquiler> GetAllAlquileres;
                if(data.Rows.Count > 0)
                {
                    foreach(DataRow row in data.Rows)
                    {
                        
                        SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
                        {
                            Port = 587,
                            Credentials = new NetworkCredential("inntent@hotmail.com", "carpas2023"),
                            EnableSsl = true,
                        };



                        // Crear el mensaje de correo
                        MailMessage mailMessage = new MailMessage();
                        mailMessage.From = new MailAddress("inntent@hotmail.com");
                        mailMessage.To.Add(row["Email"].ToString());
                        mailMessage.Subject = "Devolucion";
                        mailMessage.Body = "Por este medio le realizamos la devolucion de " + row["precio"].ToString() + " pesos, con el motivo de la cancelacion de la reserva " + row["idAlquiler"].ToString() + " del dia " + row["fechaInicio"].ToString() + ".";
                        smtpClient.Send(mailMessage);
                    }
                }
                mPPBalneario.eliminar_balneario(id);
            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }
        public bool eliminar_reserva(int id)
        {
            try
            {
                return mPPBalneario.eliminar_reserva(id);
            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }
        public bool crear_feedback(int balneario, int usuario, string mensaje, DateTime fecha, int estrellas) { 
            
            try
            {
                return mPPBalneario.crear_feedback( balneario,  usuario,  mensaje,  fecha,  estrellas);
            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }
        public IList<BEEalquiler> GetAllAlquileres(int id, DateTime fecha, int past, int pagina) // si past es 1 me trae los alquileres pasados
        {
            try
            {
                return mPPBalneario.GetAllAlquileres(id, fecha, past, pagina);
            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }
        public IList<BEEalquiler> GetAllAlquileresD(int id, DateTime fecha, int past, int pagina, int dueno) // si past es 1 me trae los alquileres pasados
        {
            try
            {
                return mPPBalneario.GetAllAlquileresD(id, fecha, past, pagina,  dueno);
            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }
        public IList<BEBalneario> GetAllBalneariosNoP()
        {
            try
            {
                return mPPBalneario.GetAllBalneariosNoP();
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<BECarpa> GetAllCarpas(int id, DateTime inicio, DateTime fin)
        {
            try
            {
                return mPPBalneario.GetAllCarpas(id, inicio, fin);
            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }

        public IList<BEBalneario> GetFIlterBalnearios(int pag, string nombre, int permiteninos, int permitemascotas, string extras)
        {
            try
            {
                return mPPBalneario.GetFIlterBalnearios(pag, nombre,permiteninos, permitemascotas, extras);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }

        public bool incribir_alquiler(BEBalneario balneario, IList<BECarpa> carpas, DateTime inicio, DateTime fin, int id, int total)
        {

            try
            {
                return mPPBalneario.incribir_alquiler(balneario,carpas,inicio,fin, id,  total);

            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }


        public async void enviarMail(BEUsuario user, BEEalquiler alquiler)
        {
            try
            {
                string test = "Por este medio le realizamos la devolucion de " + alquiler.precio + " pesos, con el motivo de la cancelacion de la reserva " + alquiler.Id + " del dia " + alquiler.fechaInicio + ", ya que el balneario estara fuera de funcionamiento.";
               
                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("inntent@hotmail.com", "carpas2023"),
                    EnableSsl = true,
                };

                // Crear el mensaje de correo
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("inntent@hotmail.com"),
                    Subject = "Cancelacion de reserva",
                    Body = test,
                    IsBodyHtml = true,  // Si el cuerpo es HTML
                };

                mailMessage.To.Add(user.email);

                // Enviar el correo electrónico
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                oBit.guardar_accion(ex.Message, 1);
                throw ex;
            }
        }
    }
}
