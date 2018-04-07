using Pessoal.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Repositorios.SqlServer
{
    public class TarefaRepositorio
    {
        private string _stringConexao = ConfigurationManager.ConnectionStrings["pessoalConnectionString"].ConnectionString;

        public int Inserir(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                const string nomeProcedure = "TarefaInserir";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(tarefa));

                    return (int)comando.ExecuteScalar();
                }

                //conexao.Close();
            }
        }

        public void Atualizar(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                const string nomeProcedure = "TarefaAtualizar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(tarefa));
                    comando.ExecuteNonQuery();
                }

                //conexao.Close();
            }
        }

        public List<Tarefa> Selecionar()
        {
            var tarefas = new List<Tarefa>();

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                const string nomeProcedure = "TarefaSelecionar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            tarefas.Add(Mapear(registro));
                        }
                    }
                }

                //conexao.Close();
            }

            return tarefas;
        }

        public Tarefa Selecionar(int id)
        {
            Tarefa tarefa = null;

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                const string nomeProcedure = "TarefaSelecionar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("Id", id);

                    using (var registro = comando.ExecuteReader())
                    {
                        if (registro.Read())
                        {
                            tarefa = Mapear(registro);
                        }
                    }
                }                
            }

            return tarefa;
        }

        public void Excluir(int id)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                const string nomeProcedure = "TarefaExcluir";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("Id", id);
                    comando.ExecuteNonQuery();
                }                
            }
        }

        private Tarefa Mapear(SqlDataReader registro)
        {
            var tarefa = new Tarefa();

            tarefa.Id = Convert.ToInt32(registro["Id"]);
            tarefa.Nome = registro["Nome"].ToString();
            tarefa.Prioridade = (Prioridade)registro["Prioridade"];
            tarefa.Concluida = Convert.ToBoolean(registro["Concluida"]);
            tarefa.Obervacao = Convert.ToString(registro["Observacao"]);

            return tarefa;
        }

        private SqlParameter[] Mapear(Tarefa tarefa)
        {
            var parametros = new List<SqlParameter>();

            if (tarefa.Id != 0)
            {
                parametros.Add(new SqlParameter("@id", tarefa.Id));
            }

            parametros.Add(new SqlParameter("@nome", tarefa.Nome));
            parametros.Add(new SqlParameter("@prioridade", tarefa.Prioridade));
            parametros.Add(new SqlParameter("@concluida", tarefa.Concluida));
            parametros.Add(new SqlParameter("@observacao", tarefa.Obervacao));

            return parametros.ToArray();
        }
    }
}
