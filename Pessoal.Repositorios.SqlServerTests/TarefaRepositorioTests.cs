using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pessoal.Dominio;
using Pessoal.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class TarefaRepositorioTests
    {
        private TarefaRepositorio _tarefaRepositorio = new TarefaRepositorio();

        [TestMethod()]
        public void InserirTest()
        {
            var tarefa = new Tarefa();
            tarefa.Concluida = false;
            tarefa.Nome = "Trocar lâmpada";
            tarefa.Obervacao = "Obs";
            tarefa.Prioridade = Prioridade.Alta;

            var id = _tarefaRepositorio.Inserir(tarefa);

            Assert.IsTrue(id != 0);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var tarefa = new Tarefa();
            tarefa.Id = 1;
            tarefa.Concluida = true;
            tarefa.Nome = "Trocar lâmpada Editado";
            tarefa.Obervacao = "Obs editado";
            tarefa.Prioridade = Prioridade.Media;

            _tarefaRepositorio.Atualizar(tarefa);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var tarefas = _tarefaRepositorio.Selecionar();

            Assert.IsTrue(tarefas.Count != 0);
        }

        [TestMethod()]
        public void SelecionarPorIdTest()
        {
            var tarefa = _tarefaRepositorio.Selecionar(1);

            Assert.IsNotNull(tarefa);
        }

        [TestMethod()]
        public void ExcluirTest()
        {
            _tarefaRepositorio.Excluir(1);

            var tarefa = _tarefaRepositorio.Selecionar(1);

            Assert.IsNull(tarefa);
        }
    }
}