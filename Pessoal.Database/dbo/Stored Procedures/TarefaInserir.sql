CREATE PROCEDURE [dbo].[TarefaInserir]
	@nome nvarchar(200),
	@prioridade int,
	@concluida bit,
	@observacao nvarchar(1000)
AS
BEGIN
INSERT INTO [dbo].[Tarefa]
           ([Nome]
           ,[Prioridade]
           ,[Concluida]
           ,[Observacao])
	 output inserted.Id
     VALUES
           (@nome
           ,@prioridade
           ,@concluida
           ,@observacao)
END
