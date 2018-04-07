Create PROCEDURE TarefaSelecionar
	@id int = null
AS
BEGIN

SELECT [Id]
      ,[Nome]
      ,[Prioridade]
      ,[Concluida]
      ,[Observacao]
  FROM [dbo].[Tarefa]
  Where Id = ISNULL(@id, Id)
  Order by Concluida, Prioridade
END
