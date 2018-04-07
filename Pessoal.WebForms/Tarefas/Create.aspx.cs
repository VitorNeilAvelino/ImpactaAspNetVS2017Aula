using Pessoal.Dominio;
using Pessoal.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tarefas_Create : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void gravarButton_Click(object sender, EventArgs e)
    {
        var tarefa = new Tarefa();

        tarefa.Concluida = concluidaCheckBox.Checked;
        tarefa.Nome = nomeTextBox.Text;
        tarefa.Obervacao = observacaoTextBox.Text;

        Enum.TryParse(prioridadeDropDownList.SelectedValue, 
            out Prioridade prioridadeSelecionada);

        tarefa.Prioridade = prioridadeSelecionada;

        new TarefaRepositorio().Inserir(tarefa);

        Response.Redirect("Default");
    }
}