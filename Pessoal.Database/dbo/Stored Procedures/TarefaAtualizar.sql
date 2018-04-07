Create PROCEDURE TarefaAtualizar
	@id int,
	@nome nvarchar(200),
	@prioridade int,
	@concluida bit,
	@observacao nvarchar(1000)
AS
BEGIN

	Update Tarefa
	Set Nome = @nome,
		Prioridade = @prioridade,
		Concluida = @concluida,
		Observacao = @observacao
	Where Id = @id

END
