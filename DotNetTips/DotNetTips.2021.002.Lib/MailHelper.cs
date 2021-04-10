using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace DotNetTips._2021._002.Lib
{
    public static class MailHelper
    {
        public static string Usuario { get; set; }
        public static string Senha { get; set; }
        public static string NomeRemetente { get; set; }
        public static string HostSmtp { get; set; }
        public static int PortaSmtp { get; set; }

        public static void enviarEmail(string corpo, string assunto, List<string> emailsPara,
            List<string> anexos = null, List<string> imagensAnexasCorpoEmail = null)
        {
            Usuario = ConfigurationManager.AppSettings["emailEnvio"];
            Senha = ConfigurationManager.AppSettings["senhaEnvio"];

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(Usuario, NomeRemetente);
            //msg.ReplyToList = new MailAddressCollection().Add(new MailAddress(responderPara));

            foreach (string email in emailsPara)
            {
                msg.To.Add(email);
            }

            if (anexos != null)
            {
                foreach (string anexo in anexos)
                {
                    Attachment _anexo = new Attachment(anexo);
                    msg.Attachments.Add(_anexo);
                }
            }

            if (imagensAnexasCorpoEmail != null)
            {
                foreach (string imageAnexo in imagensAnexasCorpoEmail)
                {
                    string[] caminhoImagem = imageAnexo.Split('\\');
                    var contentID = caminhoImagem[caminhoImagem.Length - 1];

                    var imgAnexo = new Attachment(imageAnexo);
                    imgAnexo.ContentId = contentID;
                    imgAnexo.ContentDisposition.Inline = true;
                    imgAnexo.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                    msg.Attachments.Add(imgAnexo);

                    corpo = corpo.Replace(imageAnexo, "cid:" + contentID);
                }
            }

            msg.Subject = assunto;
            msg.Body = corpo;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Host = HostSmtp;
            client.Port = PortaSmtp;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(Usuario, Senha);
            client.Timeout = 20000;

            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                msg.Dispose();
            }
        }

        public static void validarConfiguracoes()
        {
            bool valido = true;

            string mensagemErro = string.Empty;

            if (string.IsNullOrEmpty(Usuario))
            {
                valido = false;
                mensagemErro += "O parâmetro USUARIO do envio de e-mail não está cadastrado. ";
            }

            if (string.IsNullOrEmpty(Senha))
            {
                valido = false;
                mensagemErro += "O parâmetro SENHA do envio de e-mail não está cadastrado. ";
            }

            if (string.IsNullOrEmpty(NomeRemetente))
            {
                valido = false;
                mensagemErro += "O parâmetro NOME REMETENTE do envio de e-mail não está cadastrado. ";
            }

            if (!valido)
            {
                throw new Exception(mensagemErro);
            }
        }

        public static bool emailValido(string email, out string mensagemValidacao)
        {
            bool valido = true;

            mensagemValidacao = string.Empty;

            if (!string.IsNullOrEmpty(email))
            {
                if (!email.Contains('@') || (email.IndexOf('@') == 0 || email.LastIndexOf('@') == email.Length - 1))
                {
                    valido = false;
                    mensagemValidacao += "O endereço de e-mail " + email + " está com formato inválido. ";
                }
            }
            else
            {
                valido = false;
                mensagemValidacao += "Endereço de e-mail não informado. ";
            }

            return valido;
        }
    }
}