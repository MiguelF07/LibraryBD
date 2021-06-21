use Projeto;

-- Procurar reservas de um membro
GO
CREATE FUNCTION BiblioBD.ProcurarReservasMembro(@id INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE membro=@id)

-- Trigger para verificar datas do funcionario
GO
CREATE TRIGGER checkDates ON BiblioBD.funcionario AFTER INSERT AS
DECLARE @d1 AS DATE
DECLARE @d2 AS DATE
DECLARE @dn AS DATE
SELECT @d1=inicio,@d2=fim,@dn=nascimento FROM inserted
IF (@d1>@d2 OR @dn>@d1)
	BEGIN
	RAISERROR('Datas incorretas, tente de novo.', 16, 1);
	ROLLBACK TRAN;
	END

-- Trigger para verificar datas do gerente
GO
CREATE TRIGGER checkDatesMngr ON BiblioBD.gerente INSTEAD OF INSERT AS
DECLARE @inicio AS DATE
DECLARE @fim AS DATE
DECLARE @d1 AS DATE
DECLARE @d2 AS DATE
DECLARE @compare1 AS DATE
DECLARE @compare2 AS DATE
DECLARE @flag AS INT
SELECT @d1=inicio,@d2=fim FROM inserted
SELECT @flag=0
SELECT @inicio=BiblioBD.funcionario.inicio,@fim=BiblioBD.funcionario.fim FROM BiblioBD.funcionario JOIN inserted ON BiblioBD.funcionario.id=inserted.id
IF(@d1<@inicio or @d2>@fim)
	BEGIN
	RAISERROR('Um funcionário só pode ser gerente se já trabalhar para a biblioteca.', 16, 1);
	SELECT @flag=1
	END
DECLARE c CURSOR
FOR SELECT inicio,fim FROM BiblioBD.gerente;
OPEN c
FETCH c INTO @compare1,@compare2
WHILE @@FETCH_STATUS = 0
BEGIN
	if (@d2<@compare1 or @d1>@compare2)
		FETCH c INTO @compare1,@compare2
	else
		BEGIN
		RAISERROR('Apenas podemos ter um gerente de cada vez', 16, 1);
		SELECT @flag=1
		BREAK;
		END
END
CLOSE c;
DEALLOCATE c;
IF (@flag=0)
	INSERT INTO BiblioBD.gerente SELECT * FROM inserted;

-- Procurar membro por id
GO
CREATE FUNCTION BiblioBD.ProcurarMembro(@id INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.membro WHERE id=@id)

-- Procurar membro por nome
GO
CREATE FUNCTION BiblioBD.ProcurarMembroNome(@nome varchar(60)) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.membro WHERE nome LIKE  '%' + @nome + '%')

-- Adicionar membro (id é incrementado automaticamente)
GO
CREATE PROCEDURE BiblioBD.AdicionarMembro(@nome varchar(60),@email varchar(60),@morada varchar(60),@nascimento date,@NIF int)
AS
DECLARE @newid AS INT
SELECT @newid=MAX(id)+1 FROM BiblioBD.membro 
INSERT INTO BiblioBD.membro VALUES('Biblioteca Municipal',@newid,@email,@morada,@nome,@nascimento,@NIF)

-- Adicionar funcionario (id é incrementado automaticamente)
GO
CREATE PROCEDURE BiblioBD.AdicionarFunc(@nome varchar(60),@email varchar(60),@morada varchar(60),@nascimento date,@NIF int,@ssn int,@inicio date,@fim date)
AS
DECLARE @newid AS INT
SELECT @newid=MAX(id)+1 FROM BiblioBD.funcionario
INSERT INTO BiblioBD.funcionario VALUES('Biblioteca Municipal',@newid,@ssn,@email,@morada,@nome,@nascimento,@NIF,@inicio,@fim)

-- Eliminar membro por id
GO
CREATE PROCEDURE BiblioBD.EliminarMembro(@id INT)
AS 
	DELETE FROM BiblioBD.membro WHERE id=@id

--Eliminar funcionário por id
GO
CREATE PROCEDURE BiblioBD.EliminarFunc(@id INT)
AS 
	DELETE FROM BiblioBD.funcionario WHERE id=@id

-- Eliminar item por id
GO
CREATE PROCEDURE BiblioBD.EliminarItem(@id INT)
AS
DECLARE @count AS INT
SELECT @count=COUNT(id) FROM BiblioBD.emprestimoItem JOIN BiblioBD.emprestimo ON BiblioBD.emprestimo.numero=BiblioBD.emprestimoItem.numero WHERE id=@id AND limite>GETDATE()
IF (@count>0)
	RAISERROR('Não pode eliminar este item, ele está num emprestimo',16,1);
ELSE
BEGIN
	DELETE FROM BiblioBD.item WHERE id=@id
END

-- Procurar emprestimo por numero, idf, idm e todas as combinações possiveis

GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoNum(@num INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE numero=@num)

GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoIDM(@idm INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE membro=@idm)
	
GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoIDF(@idf INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE funcionario=@idf)

GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoNumIDF(@num INT,@idf INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE numero=@num and funcionario=@idf)

GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoNumIDM(@num INT,@idm INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE numero=@num and membro=@idm)

GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoIDMIDF(@idm INT,@idf INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE membro=@idm and funcionario=@idf)

GO
CREATE FUNCTION BiblioBD.ProcurarEmprestimoNumIDMIDF(@num INT,@idm INT,@idf INT) RETURNS TABLE
AS
	RETURN (SELECT * FROM BiblioBD.emprestimo WHERE numero=@num and membro=@idm and funcionario=@idf)

-- Editar um membro
GO
CREATE PROCEDURE BiblioBD.EditarMembro(@id INT,@nome varchar(60),@email varchar(60),@morada varchar(60),@nascimento date,@NIF int)
AS
UPDATE BiblioBD.membro SET nome=@nome,email=@email,morada=@morada,nascimento=@nascimento,NIF=@nif WHERE id=@id

-- Verificar disponibilidade de um item por id
GO
CREATE PROC BiblioBD.Disponivel(@id INT,@disp varchar(3) OUTPUT)
AS 
DECLARE @count INT
SELECT @count=COUNT(*) FROM BiblioBD.emprestimo JOIN BiblioBD.emprestimoItem ON BiblioBD.emprestimo.numero = BiblioBD.emprestimoItem.numero WHERE id=@id
IF @count>0
	SELECT @disp='Não'
ELSE
	SELECT @disp='Sim'

