using DotNetTips._2021._002.Lib;
using System;
using System.IO;

namespace DotNetTips._2021._001
{
    public partial class deafult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string caminho = @"C:\Users\dssca\Documents\downloads2\output";

            string[] objs = FileSystemHelper.ListarArquivosPasta(caminho);
            foreach (string o in objs)
            {
                FileInfo f = FileSystemHelper.ObterInfosArquivo(o);
                Response.Write(f.Name + " - " + f.LastWriteTime + "</br>");
            }

            #region codigo legado

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

            //using (AcessoDados dados = new AcessoDados())
            //{
            //    string sqlInsert = @"INSERT INTO USUARIO (NOME, CPFCNPJ, TIPOPESSOA, EMAIL, SENHA, ATIVO)
            //            VALUES ('FULANO TESTE " + DateTime.Now.ToString("dd/MM/yyyyy HH:mm:ss.fff") + "', '', 'F', 'TESTE@HOTMAIL.COM', '123456', 0)";

            //    dados.executaComando(sqlInsert);

            //    DataSet dsUsuario = dados.listar();

            //    gvUsuarios.DataSource = dsUsuario;
            //    gvUsuarios.DataBind();
            //}

            #endregion codigo legado
        }
    }
}