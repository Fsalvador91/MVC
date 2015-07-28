using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace LojaUniararas.Conexao
{
    public class GerenciaConexao
    {
        private static GerenciaConexao gerencia;
        private NpgsqlConnection conexao;

        private GerenciaConexao(String local)
        {
            conexao = new NpgsqlConnection();
            string ConnectionStr = "Server=localhost;Port=5432;User Id=postgres;Password=1991+fms;Database=postgres;";
            conexao.ConnectionString = ConnectionStr;
        }

        public static GerenciaConexao GetInstance(String local)
        {
            if (gerencia == null)
                gerencia = new GerenciaConexao(local);

            return gerencia;
        }

        public NpgsqlConnection GetConexao()
        {
            try
            {
                if (conexao.State.Equals(ConnectionState.Closed))
                {
                    conexao.Open();
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro em tentativa de abrir uma conexão!");
            }
            return conexao;
        }

        public void FechaConexao()
        {
            try
            {
                if (conexao.State.Equals(ConnectionState.Open))
                {
                    conexao.Close();
                }

            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro em tentatica de fechar um conexão!");
            }
        }
    }
}