using System;
using System.Data.SqlClient;

namespace Micro_OndasAPI.Persistencia
{
    public class Global
    {
        private static SqlConnection conexao;

        public static SqlConnection CriarConexao()
        {
            if (conexao == null)
            {
                string conexaoString = @"Server=localhost\MSSQLSERVER01;Database=MicroOndasDB;Trusted_Connection=True;";
                conexao = new SqlConnection(conexaoString);
            }

            return conexao;
        }

        public static void FecharConexao()
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
    }
}
