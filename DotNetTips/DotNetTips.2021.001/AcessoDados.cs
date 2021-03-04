using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DotNetTips._2021._001
{
    public class AcessoDados : IDisposable
    {
        private string sqlConn = ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();
        private SqlConnection conn;

        public AcessoDados()
        {
            conn = new SqlConnection(sqlConn);
            conn.Open();
        }

        public void executaComando(string comandoSql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = comandoSql;
            cmd.CommandType = CommandType.Text;

            cmd.ExecuteNonQuery();
        }

        public DataSet listar()
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from usuario";
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }

        public void Dispose()
        {
            if (conn != null)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}