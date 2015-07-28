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
    public class ProdutoDAO
    {
        public void Adiciona(Produto produto)
        {
            GerenciaConexao gerencia = GerenciaConexao.GetInstance("FELIPE-PC");
            NpgsqlConnection conexao = gerencia.GetConexao();
            NpgsqlCommand comando = new NpgsqlCommand();

            comando.Connection = conexao;
            comando.CommandText = "insert into produto(nome, preco, categoriaId, descricao, quantidade)";
            comando.CommandText += " values(" + "'" + produto.Nome + "'" + "," + produto.Preco + "," + produto.CategoriaID + "," +
                "'" + produto.Descricao + "'" + "," + produto.Quantidade + ")";
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (NpgsqlException erro)
            {
                throw;
            }
            finally
            {
                gerencia.FechaConexao();
            }
            
        }

        public void RemoveProduto(int id)
        {
            GerenciaConexao gerencia = GerenciaConexao.GetInstance("FELIPE-PC");
            NpgsqlConnection conexao = gerencia.GetConexao();
            NpgsqlCommand comando = new NpgsqlCommand();

            comando.Connection = conexao;
            comando.CommandText = "delete from produto where id = "+ id;

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (NpgsqlException erro)
            {
                throw;
            }
            finally
            {
                gerencia.FechaConexao();
            }
        }
        public List<Produto> ConsultaProduto()
        {

            GerenciaConexao gerencia = GerenciaConexao.GetInstance("ACACIO-ASUS");
            NpgsqlConnection conexao = gerencia.GetConexao();
            NpgsqlCommand comando = new NpgsqlCommand();
            NpgsqlDataReader leitor;
            List<Produto> lista = new List<Produto>();

            comando.Connection = conexao;
            comando.CommandText = "select * from Produto";
            
            try
            {
                leitor = comando.ExecuteReader();

                while (leitor.Read())
                {

                    int id = leitor.GetInt32(0);
                    string nome = leitor.GetString(1);
                    decimal preco = leitor.GetDecimal(2);
                    int categoriaId = leitor.GetInt32(3);
                    string descricao = leitor.GetString(4);
                    int quantidade = leitor.GetInt32(5);
                    Produto p = new Produto()
                    {
                        Id = id,
                        Nome = nome,
                        Preco = preco,
                        CategoriaID = categoriaId,
                        Descricao = descricao,
                        Quantidade = quantidade
                    };
                    lista.Add(p);
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