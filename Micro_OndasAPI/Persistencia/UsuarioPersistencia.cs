using Micro_OndasAPI.Models;
using Micro_OndasAPI.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Micro_OndasAPI.Persistencia
{
    public class UsuarioPersistencia
    {

        public RetornoPadraoModel CriarUsuario(UsuarioModel usuModel) {
            var cmd = new SqlCommand();
            SqlDataReader dr;

            DataTable dt = new DataTable();

            string sql = "";
            string retornoMensagem = "";
            bool retornoStatus = false;
            try
            {

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(usuModel.senha);
                    byte[] hash = sha256.ComputeHash(bytes);

                    StringBuilder builder = new StringBuilder();
                    foreach (var b in hash)
                        builder.Append(b.ToString("x2"));

                    usuModel.senha = builder.ToString();
                }

                var conexao = Global.CriarConexao();

                conexao.Open();

                cmd = conexao.CreateCommand();

                sql = "insert into usuario (nome,login,senha) values (@nome,@login,@senha)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", usuModel.nome);
                cmd.Parameters.AddWithValue("@login", usuModel.login);
                cmd.Parameters.AddWithValue("@senha", usuModel.senha);


                dr = cmd.ExecuteReader();
                dr.Close();

                cmd = conexao.CreateCommand();

                sql = "Select id from usuario where login = @login";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@login", usuModel.login);
                dr = cmd.ExecuteReader();

                if (dr.HasRows) { 
                    dr.Read();
                    usuModel.id = dr.GetInt32(dr.GetOrdinal("id"));

                }

                retornoMensagem = "Usuario Criado com Sucesso";
                retornoStatus = true;
            }
            catch (Exception ex)
            {
                retornoMensagem = "Falha: "+ex.Message;
            }

            Global.FecharConexao();

            RetornoPadraoModel retorno = new RetornoPadraoModel();
            retorno.Data = usuModel;
            retorno.Mensagem = retornoMensagem;
            retorno.Status = retornoStatus;
            return retorno;

        }

        public RetornoPadraoModel Login(UsuarioLoginModel usuario) {
            var cmd = new SqlCommand();
            SqlDataReader dr;

            DataTable dt = new DataTable();

            string sql = "";
            string retornoMensagem = "";

            int usuario_id = 0;

            bool retornoStatus = false;

            try
            {

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(usuario.senha);
                    byte[] hash = sha256.ComputeHash(bytes);

                    StringBuilder builder = new StringBuilder();
                    foreach (var b in hash)
                        builder.Append(b.ToString("x2"));

                    usuario.senha = builder.ToString();
                }

                var conexao = Global.CriarConexao();

                conexao.Open();

                cmd = conexao.CreateCommand();

                sql = "select id from usuario where login = @login and senha = @senha";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@login", usuario.login);
                cmd.Parameters.AddWithValue("@senha", usuario.senha);


                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    usuario_id = dr.GetInt32(dr.GetOrdinal("id"));

                    retornoMensagem = "Login e Senha Corretos";
                    retornoStatus = true;
                }
                else {
                    retornoMensagem = "Login ou Senha Incorretos";
                }

                
            }
            catch (Exception ex)
            {
                retornoMensagem = "Falha: " + ex.Message;
            }

            Global.FecharConexao();

            RetornoPadraoModel retorno = new RetornoPadraoModel();
            retorno.Data = usuario_id;
            retorno.Mensagem = retornoMensagem;
            retorno.Status = retornoStatus;
            return retorno;
        }

    }
}