using DotNetTips._2021._002.Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;

namespace DotNetTips._2021._001
{
    public static class ExtensionsHelper
    {
        public static IJavaScriptExecutor Scripts(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }
    }

    public partial class deafult : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            #region selenium ações
            //string pathDownloadPadrao = @"D:\dados\";
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddUserProfilePreference("download.default_directory", pathDownloadPadrao);

            //IWebDriver drive = new ChromeDriver(chromeOptions);
            //drive.Manage().Window.Minimize();

            //drive.Navigate().GoToUrl("https://www.infomoney.com.br/cotacoes/petrobras-petr4/historico/");

            //drive.Scripts().ExecuteScript("document.getElementsByTagName('cookies-policy')[0].remove()");
            //drive.Scripts().ExecuteScript("document.getElementsByClassName('after-header')[0].remove()");

            //drive.FindElement(By.CssSelector("#quotes_history_wrapper button")).Click();

            //Thread.Sleep(5000);

            ////drive.Navigate().GoToUrl("https://www.infomoney.com.br/cotacoes/petrobras-petr4/");

            //try
            //{
            //    var p_value = drive.FindElement(By.CssSelector(".quotes-header-info .value p")).Text;
            //    var span_date_update = drive.FindElement(By.CssSelector(".quotes-header-info .date-update span")).Text;

            //    Response.Write("p_value:" + p_value + "</br>");
            //    Response.Write("span_date_update:" + span_date_update + "</br>");

            //    MailHelper.NomeRemetente = "INFORMAÇÕES ATUALIZADAS DAS SUAS AÇÕES";
            //    MailHelper.HostSmtp = "smtp.gmail.com";
            //    MailHelper.PortaSmtp = 587;

            //    string corpo = "<p>A sua ação PETR4 está com o valor de "+ p_value + "</p>";
            //    corpo += "<p>Informações atualizada em "+ span_date_update + "</p>";

            //    string assunto = "CHEGARAM SUAS INFORMAÇÕES ATUALIZADAS SOBRE A PETR4!!!";
            //    List<string> anexos = null;

            //    foreach (var f in System.IO.Directory.GetFiles(pathDownloadPadrao))
            //    {
            //        anexos = new List<string>() { f };
            //    }

            //    MailHelper.enviarEmail(corpo, 
            //        assunto, 
            //        new List<string>() { "jogandocasualmente@gmail.com" },
            //        anexos);

            //    Response.Write("e-mail enviado com sucesso!");

            //    foreach (var f in System.IO.Directory.GetFiles(pathDownloadPadrao))
            //    {
            //        File.Delete(f);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("Erro ao tentar coletar informações");
            //}

            //drive.Close();
            //drive.Dispose();
            //drive = null;

            #endregion

            #region tips 2
            //string caminho = @"C:\Users\dssca\Documents\downloads2\output";

            //string[] objs = FileSystemHelper.ListarArquivosPasta(caminho);
            //foreach (string o in objs)
            //{
            //    FileInfo f = FileSystemHelper.ObterInfosArquivo(o);
            //    Response.Write(f.Name + " - " + f.LastWriteTime + "</br>");
            //}

            #endregion

            #region maninupulação de arquivos

            //Carro unoA = new Carro();
            //unoA.AnoFabricacao = 1995;
            //unoA.Modelo = "Fiat Uno";
            //unoA.Chassi = "abcdef";

            //Carro classic = new Carro();
            //classic.AnoFabricacao = 2010;
            //classic.Modelo = "GM Classic";
            //classic.Chassi = "1q2w3e4r";

            //unoA = (Carro)XmlHelper.deserializarObjeto(typeof(Carro), caminho + @"\" + "unoA.xml");
            //classic = (Carro)XmlHelper.deserializarObjeto(typeof(Carro), caminho + @"\" + "classic.xml");

            //XmlHelper.serializarObjeto(typeof(Carro), unoA, "unoA.xml", caminho);
            //XmlHelper.serializarObjeto(typeof(Carro), classic, "classic.xml", caminho);

            //Log log = new Log();
            //log.RegistrarLog(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

            //string texto = log.LerArquivo(@"C:\Users\dssca\Documents\downloads2\output\log.txt");

            //texto = texto.Replace("\r\n", "</br>");

            //Response.Write(texto);
            #endregion  maninupulação de arquivos

            #region acesso a dados

            using (AcessoDados dados = new AcessoDados(BancoDadosTipo.SQLServer))
            {
                string sqlInsert = @"INSERT INTO USUARIO (NOME, CPFCNPJ, TIPOPESSOA, EMAIL, SENHA, ATIVO)
                        VALUES ('FULANO TESTE " + DateTime.Now.ToString("dd/MM/yyyyy HH:mm:ss.fff") + "', '', 'F', 'TESTE@HOTMAIL.COM', '123456', 0)";

                dados.executaComando(sqlInsert);

                DataSet dsUsuario = dados.listar();

                gvUsuarios.DataSource = dsUsuario;
                gvUsuarios.DataBind();
            }

            #endregion
        }
    }
}