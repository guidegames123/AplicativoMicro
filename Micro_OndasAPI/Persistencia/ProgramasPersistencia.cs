using Micro_OndasAPI.Models;
using Micro_OndasAPI.Models.Programa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common;
using System.Data.SqlClient;
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


            if (p.alimento == "") {
                retornoMensagem = "O campo de alimento esta vazio";
                goto fim;
            } else if (p.caractere_animacao == "") {
                retornoMensagem = "O campo de caractere de animação esta vazio";
                goto fim;
            } else if (p.potencia <= 0 || p.potencia > 10) {
                retornoMensagem = "O campo de potencia tem que estar entre 0 e 10";
                goto fim;
            } else if (p.nome == "") {
                retornoMensagem = "O campo de caractere de nome esta vazio";
                goto fim;
            } else if (p.tempo <= 0 || p.tempo.ToString().Length > 4) {
                retornoMensagem = "O campo de tempo tem que ser maior que 0 e menor que 4 digitos";
                goto fim;
            }

            if (p.caractere_animacao == "." || p.caractere_animacao == "0" || p.caractere_animacao == "1" || p.caractere_animacao == "2" || p.caractere_animacao == "3" || p.caractere_animacao == "4") {
                retornoMensagem = "Já existe um alimento com esse caractere de animação";
                goto fim;
            }

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

                    if (dr.HasRows)
                    {
                        retornoMensagem = "Já existe um alimento com esse caractere de animação";
                        goto fim;
                    }
                    dr.Close();
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