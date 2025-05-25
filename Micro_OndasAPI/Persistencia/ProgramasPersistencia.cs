using Micro_OndasAPI.Models;
using Micro_OndasAPI.Models.Programa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Micro_OndasAPI.Persistencia
{
    public class ProgramasPersistencia
    {

        public RetornoPadraoModel CriarPrograma(ProgramaModel p)
        {
            var cmd = new SqlCommand();
            SqlDataReader dr;

            DataTable dt = new DataTable();

            string sql = "";
            string retornoMensagem = "";
            bool retornoStatus = false;
            try
            {
                var conexao = Global.CriarConexao();

                conexao.Open();

                // valida se existe o caractere no banco
                cmd = conexao.CreateCommand();
                sql = "select * from programa where caractere_animacao = @caractere_animacao";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@caractere_animacao", p.caractere_animacao);
                dr = cmd.ExecuteReader();

                if (dr.HasRows) {
                    goto fim;
                }

                cmd = conexao.CreateCommand();

                sql = "insert into programa";
                sql += " (nome,alimento,potencia,caractere_animacao,tempo,descricao,usuario_id)";
                sql += " values";
                sql += " (@nome,@alimento,@potencia,@caractere_animacao,@tempo,@descricao,@usuario_id)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", p.nome);
                cmd.Parameters.AddWithValue("@alimento", p.alimento);
                cmd.Parameters.AddWithValue("@potencia", p.potencia);
                cmd.Parameters.AddWithValue("@caractere_animacao", p.caractere_animacao);
                cmd.Parameters.AddWithValue("@tempo", p.tempo);
                cmd.Parameters.AddWithValue("@descricao", p.descricao);
                cmd.Parameters.AddWithValue("@usuario_id", p.usuario_id);


                dr = cmd.ExecuteReader();

                retornoMensagem = "Programa cadastrado com Sucesso";
                retornoStatus = true;
            }
            catch (Exception ex)
            {
                retornoMensagem = "Falha: " + ex.Message;
            }
            fim:;
            Global.FecharConexao();

            RetornoPadraoModel retorno = new RetornoPadraoModel();
            retorno.Data = p;
            retorno.Mensagem = retornoMensagem;
            retorno.Status = retornoStatus;
            return retorno;

        }

        public RetornoPadraoModel Listar(int usuario_id)
        {
            var cmd = new SqlCommand();
            SqlDataReader dr;

            ProgramaModel p;

            List<ProgramaModel> listaP = new List<ProgramaModel>();

            DataTable dt = new DataTable();

            string sql = "";
            string retornoMensagem = "";
            bool retornoStatus = false;
            try
            {
                var conexao = Global.CriarConexao();

                conexao.Open();

                cmd = conexao.CreateCommand();
                sql = "select * from programa where usuario_id = "+usuario_id;
                cmd.CommandText = sql;
                dr = cmd.ExecuteReader();

                while (dr.Read()) { 
                    p = new ProgramaModel()
                    {
                        id = dr.GetInt32(dr.GetOrdinal("id")),
                        nome = dr.GetString(dr.GetOrdinal("nome")),
                        alimento = dr.GetString(dr.GetOrdinal("alimento")),
                        potencia = dr.GetInt32(dr.GetOrdinal("potencia")),
                        caractere_animacao = dr.GetString(dr.GetOrdinal("caractere_animacao")),
                        tempo = dr.GetInt32(dr.GetOrdinal("tempo")),
                        descricao = dr.GetString(dr.GetOrdinal("descricao")),
                        usuario_id = dr.GetInt32(dr.GetOrdinal("usuario_id")),
                    };

                    listaP.Add(p);
                }

                retornoStatus = true;
            }
            catch (Exception ex)
            {
                retornoMensagem = "Falha: " + ex.Message;
            }

            
            
            Global.FecharConexao();

            RetornoPadraoModel retorno = new RetornoPadraoModel();
            retorno.Data = listaP;
            retorno.Mensagem = retornoMensagem;
            retorno.Status = retornoStatus;
            return retorno;

        }

    }
}