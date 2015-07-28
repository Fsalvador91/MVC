using LojaUniararas.Conexao;
using LojaUniararas.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LojaUniararas.DAO
{
    public class CategoriaProdutoDAO
    {

        public List<CategoriaProduto> ConsultaCategoriaProduto()
        {

            GerenciaConexao gerencia = GerenciaConexao.GetInstance("FELIPE-PC");
            NpgsqlConnection conexao = gerencia.GetConexao();
            NpgsqlCommand comando = new NpgsqlCommand();
            NpgsqlDataReader leitor;
            List<CategoriaProduto> lista = new List<CategoriaProduto>();

            comando.Connection = conexao;
            comando.CommandText = "select * from categoriaproduto";

            try
            {
                leitor = comando.ExecuteReader();

                while (leitor.Read())
                {

                    int id = leitor.GetInt32(0);
                    string nome = leitor.GetString(1);
                    string descricao = leitor.GetString(2);
                    CategoriaProduto c = new CategoriaProduto()
                    {
                        Id = id,
                        Nome = nome,
                        Descricao = descricao
                    };
                    lista.Add(c);
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro no execução do comando SQL!");
            }
            finally
            {
                gerencia.FechaConexao();
            }
            return lista;
        }
    }
}