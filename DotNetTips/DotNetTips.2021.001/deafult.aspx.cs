using System;
using System.Data;

namespace DotNetTips._2021._001
{
    public partial class deafult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (AcessoDados dados = new AcessoDados())
            {
                string sqlInsert = @"INSERT INTO USUARIO (NOME, CPFCNPJ, TIPOPESSOA, EMAIL, SENHA, ATIVO)
                        VALUES ('FULANO TESTE " + DateTime.Now.ToString("dd/MM/yyyyy HH:mm:ss.fff") + "', '', 'F', 'TESTE@HOTMAIL.COM', '123456', 0)";

                dados.executaComando(sqlInsert);

                DataSet dsUsuario = dados.listar();

                gvUsuarios.DataSource = dsUsuario;
                gvUsuarios.DataBind();
            }
        }
    }
}