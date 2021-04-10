using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace DotNetTips._2021._001
{
    public enum BancoDadosTipo
    {
        SQLServer = 1,
        SQLite = 2
    }

    public class AcessoDados : IDisposable
    {
        private string sqlConn = ConfigurationManager.ConnectionStrings["ConexaoPadrao"].ToString();
        private string sqlConnSQLite = ConfigurationManager.AppSettings["ConexaoPadraoSQLite"].ToString();
        private SqlConnection conn;
        private SQLiteConnection connSQLite;
        private BancoDadosTipo _tipo;

        public AcessoDados(BancoDadosTipo tipo)
        {
            _tipo = tipo;
            if (_tipo == BancoDadosTipo.SQLServer)
            {
                conn = new SqlConnection(sqlConn);
                conn.Open();
            }
            else if (_tipo == BancoDadosTipo.SQLite)
            {
                connSQLite = new SQLiteConnection(sqlConnSQLite);
                connSQLite.Open();
            }
            else
            {
                throw new Exception("Banco de dados não reconhecido");
            }
        }

        public void executaComando(string comandoSql)
        {
            if (_tipo == BancoDadosTipo.SQLServer)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = comandoSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
            }
            else if (_tipo == BancoDadosTipo.SQLite)
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = connSQLite;
                cmd.CommandText = comandoSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Banco de dados não reconhecido");
            }
        }

        public DataSet listar()
        {
            DataSet ds = new DataSet();

            if (_tipo == BancoDadosTipo.SQLServer)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from usuario";
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            else if (_tipo == BancoDadosTipo.SQLite)
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = connSQLite;
                cmd.CommandText = "select * from usuario";
                cmd.CommandType = CommandType.Text;

                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            else
            {
                throw new Exception("Banco de dados não reconhecido");
            }

            return ds;
        }

        public void Dispose()
        {
            if (_tipo == BancoDadosTipo.SQLServer)
            {
                if (conn != null)
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
            else if (_tipo == BancoDadosTipo.SQLite)
            {
                if (connSQLite != null)
                {
                    if (connSQLite.State != ConnectionState.Closed)
                    {
                        connSQLite.Close();
                    }
                }
            }
            else
            {
                throw new Exception("Banco de dados não reconhecido");
            }
        }
    }
}