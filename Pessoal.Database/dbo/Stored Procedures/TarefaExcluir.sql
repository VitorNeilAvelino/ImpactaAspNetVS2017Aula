Create PROCEDURE TarefaExcluir
	@id int
AS
BEGIN

	Delete Tarefa where Id = @id

END
