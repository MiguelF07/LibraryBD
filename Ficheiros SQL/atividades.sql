use p9g4;

-- Adicionar atividade
GO
CREATE PROC BiblioBD.adicionarAtividade(@nome varchar(60),
	@tipo varchar(60),
	@dataAti date,
	@horario time)
AS
	DECLARE @count INT
	SELECT @count=count(*) FROM BiblioBD.atividade WHERE @tipo=tipo and @dataAti=dataAti
	IF @count=0
		INSERT INTO BiblioBD.atividade VALUES ('Biblioteca Municipal',@nome,@tipo,@dataAti,@horario)
	ELSE
		RAISERROR('ERRO: j� existe uma atividade desse tipo nesse dia.',16,1);
GO
-- Obter atividades

CREATE FUNCTION BiblioBD.obterAtividades() RETURNS TABLE
AS
	RETURN SELECT * FROM BiblioBD.atividade WHERE dataAti>=GETDATE()
GO
-- Obter membros de atividade pelo nome da atividade 

CREATE FUNCTION BiblioBD.membrosAtividade(@nome varchar(60)) RETURNS TABLE
AS
	RETURN SELECT membro,id,email,morada,BiblioBD.membro.nome,nascimento,NIF FROM BiblioBD.atividadeMembro JOIN BiblioBD.membro ON membro=id WHERE BiblioBD.atividadeMembro.nome=@nome
GO
-- Eliminar atividades por nome

CREATE PROC BiblioBD.eliminarAtividade(@nome varchar(60))
AS
DELETE FROM BiblioBD.atividade WHERE nome=@nome
GO
-- Obter atividades de um membro pelo id do membro

CREATE FUNCTION BiblioBD.obterAtividadesMembro(@id INT) RETURNS TABLE
AS
	RETURN SELECT BiblioBD.atividade.nome,tipo,dataAti,horario FROM BiblioBD.atividade JOIN BiblioBD.atividadeMembro ON BiblioBD.atividade.nome=BiblioBD.atividadeMembro.nome where dataAti>=GETDATE() and membro=@id
GO
-- Obter atividades de um membro pelo id do membro e tipo de atividade

CREATE FUNCTION BiblioBD.obterAtividadesMembroTipo(@id INT,@tipo varchar(60)) RETURNS TABLE
AS
	RETURN SELECT BiblioBD.atividade.nome,tipo,dataAti,horario FROM BiblioBD.atividade JOIN BiblioBD.atividadeMembro ON BiblioBD.atividade.nome=BiblioBD.atividadeMembro.nome where dataAti>=GETDATE() and membro=@id and tipo=@tipo
GO
-- Obter atividades por tipo

CREATE FUNCTION BiblioBD.obterAtividadesTipo(@tipo varchar(60)) RETURNS TABLE
AS
	RETURN SELECT * FROM BiblioBD.atividade where dataAti>=GETDATE() and tipo=@tipo
GO
-- Adiciontar membro a uma atividade

CREATE PROCEDURE BiblioBD.adicionarMembroAtividade(@id INT,@nome varchar(60))
AS
	DECLARE @count INT
	DECLARE @data DATE
	SELECT @data=dataAti FROM BiblioBD.atividade WHERE nome=@nome
	SELECT @count=COUNT(*) FROM BiblioBD.atividadeMembro JOIN BiblioBD.atividade ON BiblioBD.atividadeMembro.nome=BiblioBD.atividade.nome WHERE membro=@id and dataAti=@data
	IF @count=0
		INSERT INTO BiblioBD.atividadeMembro VALUES ('Biblioteca Municipal',@id,@nome)
	ELSE
		RAISERROR('ERRO: O membro j� participa numa atividade nesse dia.',16,1);
GO
-- Remover membro de uma atividade

CREATE PROCEDURE BiblioBD.removerMembroAtividade(@id INT,@nome varchar(60))
AS
	DELETE FROM BiblioBD.atividadeMembro WHERE @id=membro and @nome=nome
GO	

