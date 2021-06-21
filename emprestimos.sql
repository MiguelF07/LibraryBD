use p9g4;
--Indice Non Clustered que vai ordenar o ID do Membro na tabela emprestimo de forma ascendente
--Achamos este indice importante porque é mais frequente os emprestimos serem pesquisados pelo ID do Membro do que propriamente pelo ID do emprestimo
CREATE NONCLUSTERED INDEX idMemberIndex
ON BiblioBD.emprestimo(membro ASC)
GO

--Indice Non Clustered que vai ordenar o numero do emprestimo na tabela emprestimoItem de forma ascendente
CREATE NONCLUSTERED INDEX idEmpIndex
ON BiblioBD.emprestimoItem(numero ASC)
GO

-- Procedure para estender a data limite de um empréstimo (incrementa 15 dias)
CREATE PROCEDURE BiblioBD.EstenderEmprestimo(@num INT)
AS
DECLARE @emp AS DATE
DECLARE @daysToAdd AS INT
DECLARE @newDate AS DATE
DECLARE @counter AS INT

SELECT @counter=COUNT(*) FROM BiblioBD.emprestimo WHERE numero=@num

IF (@counter=0)
	RAISERROR('Não há nenhum empréstimo ativo com este número',16,1);
ELSE
	SELECT @emp=limite FROM BiblioBD.emprestimo WHERE numero=@num
	SELECT @daysToAdd = 15
	SELECT @newDate = DATEADD(day,15,@emp)

	UPDATE BiblioBD.emprestimo
	SET limite = @newDate
	WHERE numero = @num;

GO

-- Funçao que verifica se um item (@id) já está emprestado (retorna 0 se já estiver emprestado, e 1 se estiver disponivel)
CREATE FUNCTION BiblioBD.VerDisponibilidade(@id INT) RETURNS BIT
AS
BEGIN
DECLARE @ret as BIT
DECLARE @tabelaID AS INT
DECLARE @count AS INT
SELECT @count=COUNT(*) FROM BiblioBD.emprestimo JOIN BiblioBD.emprestimoItem ON BiblioBD.emprestimo.numero = BiblioBD.emprestimoItem.numero WHERE id=@id

IF(@count!=0)
BEGIN
	SET @ret = 0
END
ELSE
BEGIN
	SET @ret = 1
END
RETURN @ret
END
GO

--Funcao que verifica se utilizador pode fazer emprestimos (não pode fazer quando tem mais que 5 itens reservados) (retorna 0 se nao puder fazer mais reservas e 1 se puder)
CREATE FUNCTION BiblioBD.PodeReservar(@num INT) RETURNS BIT
AS
BEGIN
	DECLARE @numEmprestimos AS INT
	DECLARE @ret AS BIT
	SELECT @numEmprestimos = sum(CASE WHEN membro=@num then 1 else 0 end) FROM BiblioBD.emprestimo FULL OUTER JOIN BiblioBD.emprestimoItem ON BiblioBD.emprestimo.numero=BiblioBD.emprestimoItem.numero
	IF (@numEmprestimos>=5)
	BEGIN
		SET @ret = 0
	END
	ELSE
	BEGIN
		SET @ret = 1
	END
	RETURN @ret
END
GO

--Funcao que verifica se um dado utilizador tem algum emprestimo em atraso (0 se tiver atraso, 1 se nao tiver)
CREATE FUNCTION BiblioBD.TemAtraso(@num INT) RETURNS BIT
AS
BEGIN
	DECLARE @ret AS BIT
	DECLARE @empAtrasados AS INT
	DECLARE @todayDate AS DATE
	SET @todayDate = CAST( GETDATE() AS Date )
	SELECT @empAtrasados = COUNT(*) FROM BiblioBD.emprestimo JOIN BiblioBD.emprestimoItem ON BiblioBD.emprestimo.numero=BiblioBD.emprestimoItem.numero WHERE (limite < @todayDate AND membro = @num)
	IF (@empAtrasados>0)
	BEGIN
		SET @ret = 0
	END
	ELSE
	BEGIN
		SET @ret = 1
	END
	RETURN @ret
END
GO

--Funcao que verifica se um dado funcionario ainda trabalha na biblioteca (0 se nao trabalhar, 1 se trabalhar)
CREATE FUNCTION BiblioBD.Trabalha(@num INT) RETURNS BIT
AS
BEGIN
	DECLARE @ret AS BIT
	DECLARE @tabelaFunc AS INT
	SELECT @tabelaFunc = COUNT(*) FROM BiblioBD.funcionario WHERE (id=@num AND fim IS NULL)
	IF (@tabelaFunc = 0)
	BEGIN
	SET @ret = 0
	END
	ELSE
	BEGIN
	SET @ret = 1
	END
	RETURN @ret
END
GO

--Procedure que adiciona um empréstimo (este procedure vai chamar 3 funções definidas anteriormente) - retorna o nr de emprestimo
CREATE PROCEDURE BiblioBD.AddEmprestimo(@idF INT, @idM INT,@newnumero INT OUTPUT)
AS
BEGIN
	DECLARE @dataLimite AS DATE
	DECLARE @podeEmprestar AS BIT
	DECLARE @emAtraso AS BIT
	DECLARE @dataAtual AS DATE
	DECLARE @funcTrabalha AS BIT
	SET @podeEmprestar = BiblioBD.PodeReservar(@idM)
	SET @emAtraso = BiblioBD.TemAtraso(@idM)
	SET @funcTrabalha = BiblioBD.Trabalha(@idF)
	SET @dataAtual = CAST(GETDATE()AS DATE) 
	SELECT @newnumero=MAX(numero)+1 FROM BiblioBD.emprestimo 
	IF @funcTrabalha = 0
	BEGIN
		RAISERROR('ID de funcionário inválido. O funcionário já não trabalha na Biblioteca',16,1);
	END
	ELSE
	BEGIN
		IF @emAtraso=0
		BEGIN
			RAISERROR('O utilizador não pode efetuar reservas porque tem emprestimos em atraso.',16,1);
		END
		ELSE
		BEGIN
			IF @podeEmprestar=0
			BEGIN
				RAISERROR('O utilizador já tem 5 empréstimos ativos, não pode realizar mais nenhum.',16,1);
			END
			ELSE
			BEGIN
				SELECT @dataLimite = DATEADD(day,15,@dataAtual)
				INSERT INTO BiblioBD.emprestimo(numero,funcionario,biblioteca,membro,limite,emprestimo)
				VALUES (@newnumero,@idF,'Biblioteca Municipal',@idM,@dataLimite,@dataAtual)
			END
		END
	END
	RETURN @newnumero
END
GO

--Procedimento que adiciona um item a um certo emprestimo (este procedure utiliza funcoes definidas anteriormente)
CREATE PROCEDURE BiblioBD.AddItemEmprestimo(@num INT, @idItem INT)
AS
DECLARE @exist AS INT
DECLARE @itemDisp AS BIT
SET @itemDisp = BiblioBD.VerDisponibilidade(@idItem)
SELECT @exist = COUNT(*) FROM BiblioBD.emprestimo WHERE BiblioBD.emprestimo.numero=@num
IF @itemDisp=0
BEGIN
	RAISERROR('Este artigo já está emprestado',16,1);
END
ELSE
BEGIN
IF @exist=0
BEGIN
	RAISERROR('O empréstimo ao qual está a tentar adicionar o item não existe.',16,1);
END
ELSE
BEGIN
	INSERT INTO BiblioBD.emprestimoItem(biblioteca,numero,id)
	VALUES ('Biblioteca Municipal',@num,@idItem)
END
END
GO

--Procedimento que elimina um certo item emprestado da tabela de itens emprestados (funciona como entrega de um item)
CREATE PROCEDURE BiblioBD.EliminarItemEmprestimo (@item INT)
AS
DELETE FROM BiblioBD.emprestimoItem WHERE BiblioBD.emprestimoItem.id=@item
GO

--Procedimento que elimina um empréstimo da tabela de empréstimos, e todos os itens que estejam nesse empréstimo (funciona como entrega de todos os itens do empréstimo)
CREATE PROCEDURE BiblioBD.EliminarEmprestimo (@id INT)
AS
	DELETE FROM BiblioBD.emprestimoItem WHERE BiblioBD.emprestimoItem.numero = @id
	DELETE FROM BiblioBD.emprestimo WHERE BiblioBD.emprestimo.numero = @id
	
GO

--Trigger que, quando um empréstimo é apagado, o transfere para a tabela 'emprestimos_antigos' de forma a manter um historial de empréstimos
CREATE TRIGGER BiblioBD.GuardarOldEmp ON BiblioBD.emprestimo AFTER DELETE
AS
	BEGIN
		DECLARE @numero AS INT
		DECLARE @funcionario AS INT
		DECLARE @biblioteca AS VARCHAR(60)
		DECLARE @membro AS INT
		DECLARE @limite AS DATE
		DECLARE @emprestimo AS DATE


		IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_SCHEMA = 'BiblioBD' AND TABLE_NAME = 'emprestimos_antigos'))
		BEGIN
			CREATE TABLE BiblioBD.emprestimos_antigos (
				numero INT,
				funcionario INT,
				biblioteca VARCHAR(60),
				membro INT,
				limite DATE,
				emprestimo DATE,
				PRIMARY KEY (biblioteca,numero));
		END
		SELECT @numero=numero,@funcionario=funcionario,@biblioteca=biblioteca,@membro=membro,@limite=limite,@emprestimo=emprestimo FROM deleted
		INSERT BiblioBD.emprestimos_antigos VALUES (@numero,@funcionario,@biblioteca,@membro,@limite,@emprestimo)
		PRINT 'Log: Emprestimo transferido para Old Emprestimos'
	END
GO

-- Obter nome de item de acordo com o id
CREATE PROC BiblioBD.getItem(@id INT,@nome varchar(60) OUTPUT)
AS
	DECLARE @temp AS INT
	-- pesquisar nos livros
	SELECT @temp=COUNT(*) FROM BiblioBD.livro WHERE @id=id
	IF(@temp>0)
		SELECT @nome=titulo FROM BiblioBD.livro WHERE @id=id
	--pesquisar nos cds
	SELECT @temp=COUNT(*) FROM BiblioBD.cd WHERE @id=id
	IF(@temp>0)
		SELECT @nome=titulo FROM BiblioBD.cd WHERE @id=id
	--pesquisar nos filmes
	SELECT @temp=COUNT(*) FROM BiblioBD.filme WHERE @id=id
	IF(@temp>0)
		SELECT @nome=titulo FROM BiblioBD.filme WHERE @id=id
	--pesquisar nos revistas
	SELECT @temp=COUNT(*) FROM BiblioBD.revistas WHERE @id=id
	IF(@temp>0)
		SELECT @nome=marca FROM BiblioBD.revistas WHERE @id=id
	--pesquisar nos jornais
	SELECT @temp=COUNT(*) FROM BiblioBD.jornais WHERE @id=id
	IF(@temp>0)
		SELECT @nome=marca FROM BiblioBD.jornais WHERE @id=id
	--pesquisar nos perifericos
	SELECT @temp=COUNT(*) FROM BiblioBD.perifericos WHERE @id=id
	IF(@temp>0)
		SELECT @nome=tipo FROM BiblioBD.perifericos WHERE @id=id
GO
